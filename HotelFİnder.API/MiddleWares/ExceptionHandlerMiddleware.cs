using System.Net;
using System.Text.Json;

namespace HotelFİnder.API.MiddleWares
{
    public class ExceptionHandlerMiddleware
    {
        public ExceptionHandlerMiddleware(RequestDelegate Next, ILogger<ExceptionHandlerMiddleware> Logger)
        {
            this.Next = Next;
            this.Logger = Logger;
        }

        public RequestDelegate Next { get; private set; }
        public ILogger<ExceptionHandlerMiddleware> Logger { get; }

        public async Task Invoke(HttpContext httpContext)
        {

            try
            {
                await Next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                //Hata yönetim kodları.
                Logger.LogError(ex.Message);
            }
        }

    }
}
