using System;

namespace Tradelite.SDK.Model 
{
    [Serializable]
    public class BaseError
    {
        public string message;
        public Exception cause;

        public BaseError(string message, Exception cause)
        {
            this.message = message;
            this.cause = cause;
        }
    }
}