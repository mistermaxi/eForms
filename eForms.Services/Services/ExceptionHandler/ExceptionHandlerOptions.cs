using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Builder
{
    public class ExceptionHandlerOptions
    {
        public PathString ExceptionHandlingPath { get; set; }

        public RequestDelegate ExceptionHandler { get; set; }
    }
}