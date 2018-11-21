using System;

namespace SwapiApiChallenge.Exceptions
{
    public class ConsumableFormatNotFoundException : Exception
    {
        public ConsumableFormatNotFoundException()
        {
        }

        public ConsumableFormatNotFoundException(string message) : base(message)
        {
        }

        public ConsumableFormatNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}