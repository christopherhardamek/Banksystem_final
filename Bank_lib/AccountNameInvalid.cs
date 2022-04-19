using System.Runtime.Serialization;

namespace Banksystem
{
    [Serializable]
    public class AccountNameInvalid : Exception
    {
        public AccountNameInvalid()
        {
        }

        public AccountNameInvalid(string? message) : base(message)
        {
        }

        public AccountNameInvalid(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected AccountNameInvalid(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}