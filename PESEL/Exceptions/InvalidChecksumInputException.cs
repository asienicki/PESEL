using System;

namespace PESEL.Exceptions
{
    public sealed class InvalidChecksumInputException : Exception
    {
        public InvalidChecksumInputException()
            : base("Weights array length must be greater or equal to text length.")
        {
        }
    }
}
