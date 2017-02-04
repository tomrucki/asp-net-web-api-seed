using System;

namespace ApiSeed.Services.Exceptions
{
    public class ValidationException : Exception
    {
        public Enum ErrorCode { get; protected set; }

        public ValidationException(Enum code, string message = "Request validation") : base(message)
        {
            if (code == null)
            {
                throw new ArgumentNullException(nameof(code));
            }
            this.ErrorCode = code;
        }
    }
}