using System;

namespace ApiSeed.Models.Common.StatusCodes
{
    public class StatusResult
    {
        public Enum StatusCode { get; private set; }
        public string Message { get; set; }

        public StatusResult(Enum statusCode, string message = "")
        {
            this.StatusCode = statusCode;
            this.Message = message;
        }

        private static StatusResult _ok = new StatusResult(SuccessCodes.Common.OK);

        public static StatusResult OK
        {
            get { return _ok; }
        }
    }
}