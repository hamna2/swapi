using System;

namespace SwapiApiChallenge.Exceptions
{
    public class ConsumableConversionExecption : Exception
    {
        public ConsumableConversionExecption()
        {
        }

        public ConsumableConversionExecption(string message) : base(message)
        {
        }

        public ConsumableConversionExecption(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}