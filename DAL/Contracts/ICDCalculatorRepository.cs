using Domain.Integrity;
using System.Collections.Generic;

namespace DAL.Contracts
{
    public interface ICDCalculatorRepository
    {
        bool IsValid(IHorizontalCheckDigit entity);
        byte[] CalculateCheckDigitForEntity(IHorizontalCheckDigit entity);
        byte[] CalculateCheckDigitFromMultipleDigits(IEnumerable<byte[]> crcs);
    }
}
