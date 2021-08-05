using System;

namespace Telephony.Exceptions
{
    public class InvalidURLException : Exception
    {
        private const string INVALID_URL_EXCEPTION_MSG = "Invalid URL!";

        public InvalidURLException()
            : base(INVALID_URL_EXCEPTION_MSG)
        {
        }
    }
}
