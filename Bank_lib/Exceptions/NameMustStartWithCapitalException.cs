using System.Runtime.Serialization;

namespace bank.lib.Exceptions
{
    [Serializable]
    public class NameMustStartWithCapitalException : Exception
    {
        public NameMustStartWithCapitalException()
        {
        }

        public NameMustStartWithCapitalException(string? message) : base(message)
        {
        }

        public NameMustStartWithCapitalException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NameMustStartWithCapitalException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}