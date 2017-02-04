using ApiSeed.Models.Common.StatusCodes;
using System;

namespace ApiSeed.Api.Infrastructure
{
    public abstract class ApiResponseContent
    {
        public string Status { get; protected set; }
        public int StatusCode { get; protected set; }
        public object Data { get; protected set; }
        public string Message { get; protected set; }
    }

    public class ApiResponseStatus
    {
        public const string OK = "ok";
        public const string Fail = "fail";
        public const string Error = "error";
    }

    /// <summary>
    /// Success
    /// </summary>
    public class OkResponse : ApiResponseContent
    {
        public OkResponse(object data = null, StatusResult status = null)
        {
            this.Data = data;
            this.Status = ApiResponseStatus.OK;
            if (status != null)
            {
                this.Message = status.Message;
                this.StatusCode = Convert.ToInt32(status.StatusCode);
            }
        }
    }

    /// <summary>
    /// Client side error (invalid request, input, etc.)
    /// </summary>
    public class FailResponse : ApiResponseContent
    {
        public FailResponse(Enum statusCode = null, object data = null)
        {
            this.StatusCode = statusCode == null ? 0 : Convert.ToInt32(statusCode);
            this.Data = data;
            this.Status = ApiResponseStatus.Fail;
        }
    }

    /// <summary>
    /// Server side error (something went down)
    /// </summary>
    public class ErrorResponse : ApiResponseContent
    {
        public ErrorResponse(string message, object data = null)
        {
            this.Data = data;
            this.Message = message;
            this.Status = ApiResponseStatus.Error;
        }
    }
}