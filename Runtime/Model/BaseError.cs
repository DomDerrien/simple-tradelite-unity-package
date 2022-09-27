using System;
using System.Collections.Generic;

namespace Tradelite.SDK.Model
{
    [Serializable]
    public class BaseError
    {
        public string message;
        public Exception cause;

        public BaseError(string message)
        {
            this.message = message;
        }

        public BaseError(string message, Exception cause)
        {
            this.message = message;
            this.cause = cause;
        }

        public override string ToString()
        {
            List<string> output = new List<string>();
            if (!string.IsNullOrEmpty(message)) output.Add($"message: `{message}`");
            if (cause != null) output.Add($"cause: `{cause.ToString()}`");
            return String.Join(", ", output);
        }
    }
}