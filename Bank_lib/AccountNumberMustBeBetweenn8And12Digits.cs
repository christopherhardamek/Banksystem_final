using System.Runtime.Serialization;

namespace Banksystem
{
    [Serializable]
    public class AccountNumberMustBeBetweenn8And12Digits : Exception
    {
        public AccountNumberMustBeBetweenn8And12Digits()
        {
            
        }

        public AccountNumberMustBeBetweenn8And12Digits(string? message) : base(message)
        {
        }

        public AccountNumberMustBeBetweenn8And12Digits(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected AccountNumberMustBeBetweenn8And12Digits(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}