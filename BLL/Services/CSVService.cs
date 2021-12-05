using BLL.Contracts;
using Domain;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    internal sealed class CSVService : SaveApplicationLog, ICSVService
    {
        public void Create(List<CSV> CSV)
        {
            Voucher voucher = null;
            List<Voucher> vouchers = new();
            int line = 0, count = 0;

            foreach (var invoice in CSV)
            {
                line += 1;
                count++;
                Guid Article_ID = Factory.Factory.GetInstance().ArticleService.GetByFS(invoice.FsCode).ID;
                if (voucher != null && voucher.InvoiceClientNumber.Equals(invoice.InvoiceNumber))
                {
                    voucher.VoucherDetails.Add(GetVoucherDetail(invoice, Article_ID, line));
                    if (count.Equals(CSV.Count)) vouchers.Add(voucher);
                    continue;
                }
                else
                {
                    line = 1;
                    if (voucher != null) vouchers.Add(voucher);
                }
                voucher = GetVoucher(invoice);
                List<VoucherDetail> voucherDetails = new();
                voucherDetails.Add(GetVoucherDetail(invoice, Article_ID, line));
                voucher.VoucherDetails = voucherDetails;
                if (count.Equals(CSV.Count)) vouchers.Add(voucher);
            }
            vouchers.ForEach(x => Factory.Factory.GetInstance().VoucherService.Create(x));
            try
            {
                CSV.ForEach(x => DAL.Factory.Factory.Current.CSVRepository.Create(x));
                DAL.Factory.Factory.Current.SaveChanges();
            }
            catch (Exception ex)
            {
                SaveException(ex);
            }
        }
        private VoucherDetail GetVoucherDetail(CSV invoice, Guid Article_ID, int line)
        {
            return new VoucherDetail()
            {
                ID = Guid.NewGuid(),
                Article_ID = Article_ID,
                Quantity = invoice.Packages,
                Line = line
            };
        }
        private Voucher GetVoucher(CSV CSV)
        {
            return new Voucher()
            {
                ID = Guid.NewGuid(),
                Client_ID = Factory.Factory.GetInstance().ClientService.GetByCuit(CSV.Cuit).ID,
                Addressee = new Addressee()
                {
                    ID = Guid.NewGuid(),
                    LastName = CSV.AddresseeLastName,
                    Name = CSV.AddresseeName,
                    CellPhoneNumber = CSV.AddresseeCellPhoneNumber,
                    ZipCode = CSV.AddresseeZipCode,
                    DocumentNumber = CSV.DocNumber,
                    Address = CSV.AddresseeAddress,
                    Mail = CSV.AddresseeMail,
                    PhoneNumber = CSV.AddresseePhoneNumber,
                    DocumentType = CSV.DocType
                },
                VoucherDate = CSV.InvoiceDate,
                VoucherType = VoucherType.SPK,
                Letter = CSV.Letter,
                InvoiceClientNumber = CSV.InvoiceNumber,
                Branch = Convert.ToInt32(CSV.Branch),
            };
        }
    }
}
