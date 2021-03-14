using System.Net.Http;
using System.Net;

namespace ConsumeThirdPartyAPIs.Exceptions
{
    public class ServiceException : HttpRequestException
    {
        public HttpStatusCode StatusCode { get; set; }

        public ServiceException(HttpStatusCode StatusCode) : base() {
            this.StatusCode = StatusCode;
        }

        public ServiceException(HttpStatusCode StatusCode, string Message) : base(Message) {
            this.StatusCode = StatusCode;
        }
    }
}