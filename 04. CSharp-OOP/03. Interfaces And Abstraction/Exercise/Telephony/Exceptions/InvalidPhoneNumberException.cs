using System;

namespace Telephony.Exceptions
{
    public class InvalidPhoneNumberException : Exception
    {
        private const string INVALID_PHONE_NUMBER_EXCEPTION_MSG = "Invalid number!";

        public InvalidPhoneNumberException()
            : base(INVALID_PHONE_NUMBER_EXCEPTION_MSG)
        {
        }
    }
}
