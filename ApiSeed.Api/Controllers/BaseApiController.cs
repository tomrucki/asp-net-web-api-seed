using ApiSeed.Api.Infrastructure;
using System;
using System.Net;
using System.Web.Http;

namespace ApiSeed.Api.Controllers
{
    public class BaseApiController : ApiController
    {
        protected IHttpActionResult AsOk(object data = null)
        {
            return Content(HttpStatusCode.OK, new OkResponse(data));
        }

        protected IHttpActionResult AsFail(Enum statusCode = null, object data = null)
        {
            return Content(HttpStatusCode.BadRequest, new FailResponse(statusCode, data));
        }

        protected IHttpActionResult AsError(string message, object data = null)
        {
            return Content(HttpStatusCode.InternalServerError, new ErrorResponse(message, data));
        }
    }
}