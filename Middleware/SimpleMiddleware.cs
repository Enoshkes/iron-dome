namespace IronDome.Middleware
{
    public class SimpleMiddleware(RequestDelegate next)
    {
      

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"Request: {DateTime.Now}");

            var path = context.Request.Path;
            Console.WriteLine($"Request Path: {path}");

            var status = context.Response.StatusCode;


            await next(context);

            var status2 = context.Response.StatusCode;
            Console.WriteLine($"Response status code: {status}");
        }
    }
}
