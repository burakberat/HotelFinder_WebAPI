using Microsoft.Extensions.Logging;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace HotelFİnder.API.MiddleWares
{
    public class RequestResponseMiddleware
    {
        public RequestResponseMiddleware(RequestDelegate Next, ILogger<RequestResponseMiddleware> Logger)
        {
            this.next = Next;
            this.logger = Logger;
        }

        private readonly RequestDelegate next;
        private readonly ILogger<RequestResponseMiddleware> logger;

        public async Task Invoke(HttpContext httpContext)
        {
            var originalBodyStream = httpContext.Response.Body;

            //request aldığımız kısım.

            logger.LogInformation($"Query Keys: { httpContext.Request.QueryString}");

            MemoryStream requestBody = new MemoryStream();
            await httpContext.Request.Body.CopyToAsync(requestBody);
           
            requestBody.Seek(0, SeekOrigin.Begin);
            String requestText = await new StreamReader(requestBody).ReadToEndAsync();
            requestBody.Seek(0, SeekOrigin.Begin);

            var tempStream = new MemoryStream();
            httpContext.Response.Body = tempStream;
            await next.Invoke(httpContext);

            //response aldığımız kısım.


            httpContext.Response.Body.Seek(0,SeekOrigin.Begin);
            String responseText = await new StreamReader(httpContext.Response.Body, Encoding.UTF8).ReadToEndAsync();
            originalBodyStream.Seek(0, SeekOrigin.Begin);

            await httpContext.Response.Body.CopyToAsync(originalBodyStream);

            logger.LogInformation($"Request: { requestText}");
            logger.LogInformation($"Response: {responseText}");
        }
    }
}
