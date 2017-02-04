using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApiSeed.Api.Infrastructure.Results
{
    public class StreamResult : IHttpActionResult
    {
        private readonly Stream _data;
        private readonly string _contentType;

        public StreamResult(Stream data, string contentType = null)
        {
            if (data == null)
                throw new ArgumentNullException("data");

            _data = data;
            _contentType = contentType ?? "application/octet-stream";
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(_data)
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(_contentType);
            return Task.FromResult(response);
        }
    }
}