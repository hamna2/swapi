using System;

namespace SwapiApiChallenge.Exceptions
{
    public class DependencyException :Exception
    {
        public DependencyException()
        {
        }

        public DependencyException(string message) : base(message)
        {
        }

        public DependencyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}