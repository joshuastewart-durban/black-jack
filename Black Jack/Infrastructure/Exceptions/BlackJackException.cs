namespace Black_Jack.Infrastructure.Exceptions
{
    using System;

    public class BlackJackException : Exception
    {
        public BlackJackException(string message, Exception innerException)
    : base(message, innerException)
        {
        }

        public BlackJackException(Exception innerException)
            : base(string.Empty, innerException)
        {
        }
    }
}
