using BLL.Contracts;
using Domain;
using Services.BLL.Contracts;
using Services.Domain.Logger;
using Services.Factory;
using Services.Services.ModelValidator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    internal sealed class VoucherService : SaveApplicationLog, IVoucherService
    {
        private readonly IUserTranslator _userTranslator;
        public VoucherService()
        {
            _userTranslator = ApplicationServices.GetInstance().GetUserTranslator;
        }
        public Voucher Create(Voucher voucher)
        {
            Numerator numerator;
            if (voucher.VoucherDate < DateTime.Today) throw new Exception(_userTranslator.Translate("ErrorFechaMenAct"));
            try
            {
                numerator =
                    DAL.Factory.Factory.Current.NumeratorRepository
                    .Get(filter: x => x.VoucherType == voucher.VoucherType &&
                    x.Letter == voucher.Letter &&
                    x.Branch == voucher.Branch)
                    .SingleOrDefault()
                    ?? DAL.Factory.Factory.Current.NumeratorRepository.Create
                (
                    new Numerator()
                    {
                        ID = Guid.NewGuid(),
                        VoucherType = voucher.VoucherType,
                        Letter = voucher.Letter,
                        Branch = voucher.Branch,
                        Number = 0
                    }
                );

                numerator.Number += 1;
                voucher.Number = numerator.Number;

                DAL.Factory.Factory.Current.SaveChanges();

                if (voucher.VoucherType.Equals(VoucherType.SIR)) voucher.Labels = GetLabels(voucher);

                voucher = DAL.Factory.Factory.Current.VoucherRepository.Create(voucher);
                DAL.Factory.Factory.Current.NumeratorRepository.Update(numerator);
                DAL.Factory.Factory.Current.SaveChanges();

                SaveLog(Event.ComprobanteGenerado, Severity.Informative, voucher.Description);
            }
            catch (Exception ex)
            {
                SaveException(ex);
            }
            return voucher;
        }
        public IEnumerable<Voucher> GetPickingVoucher()
        {
            IEnumerable<Voucher> C = null;
            try
            {
                C = DAL.Factory.Factory.Current.VoucherRepository
                .Get(
                filter: x => x.VoucherType == VoucherType.SPK &&
                x.Closure.Equals(null) ||
                x.Closure == "I"
                )
                .OrderByDescending(
                x => x.CreatedOn
                );
            }
            catch (Exception ex)
            {
                SaveException(ex);
            }
            if (!C.Any()) throw new Exception(_userTranslator.Translate("ErrorSinRegistros"));
            return C;
        }
        public IEnumerable<Voucher> GetScanVoucher()
        {
            IEnumerable<Voucher> C = null;
            try
            {
                C = DAL.Factory.Factory.Current.VoucherRepository
                .Get(
                filter: x =>
                x.VoucherType == VoucherType.SPK && x.Closure.Equals("C") ||
                x.VoucherType == VoucherType.SIR && x.Closure.Equals(null) ||
                x.VoucherType == VoucherType.SIR && !x.Closure.Equals("D")
                )
                .OrderByDescending(
                x => x.CreatedOn
                );
            }
            catch (Exception ex)
            {
                SaveException(ex);
            }
            if (!C.Any()) throw new Exception(_userTranslator.Translate("ErrorSinRegistros"));
            return C;
        }
        public RejectionType[] GetRejectionTypes()
        {
            var RejectionTypes = DAL.Factory.Factory.Current.VoucherRepository.GetRejectionTypes();

            foreach (var item in RejectionTypes)
                item.Description = _userTranslator.Translate(item.Description);

            return RejectionTypes;
        }
        public IEnumerable<Voucher> GetTransferVoucher()
        {
            IEnumerable<Voucher> C = null;
            try
            {
                C = DAL.Factory.Factory.Current.VoucherRepository
                .Get(
                filter: x => x.VoucherType == (VoucherType.SIS) &&
                x.Closure == "D"
                )
                .OrderByDescending(
                x => x.CreatedOn
                );
            }
            catch (Exception ex)
            {
                SaveException(ex);
            }
            if (!C.Any()) throw new Exception(_userTranslator.Translate("ErrorSinRegistros"));
            return C;
        }
        public void Update(Voucher voucher)
        {
            try
            {
                DAL.Factory.Factory.Current.VoucherRepository.Update(voucher);
                DAL.Factory.Factory.Current.SaveChanges();
                SaveLog(Event.ComprobanteActualizado, Severity.Informative, voucher.Description);
            }
            catch (Exception ex)
            {
                SaveException(ex);
            }
        }
        private static List<Label> GetLabels(Voucher voucher)
        {
            List<Label> labels = new();

            foreach (var cbtedet in voucher.VoucherDetails)
            {
                for (int i = 1; i <= cbtedet.Quantity; i++)
                {
                    labels.Add(new Label()
                    {
                        ID = Guid.NewGuid(),
                        Voucher_ID = voucher.ID,
                        Article_ID = cbtedet.Article_ID,
                        LabelNumber = i,
                        TotalLabels = cbtedet.Quantity
                    });
                }
            }
            return labels;
        }
    }
}
