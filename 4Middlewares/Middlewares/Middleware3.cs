namespace _4Middlewares.Middlewares
{
    public class Middleware3
    {
        private readonly RequestDelegate _next;

        public Middleware3(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"[Middleware 3] Incoming Request: {context.Request.Method} {context.Request.Path}");

            await _next(context);

            Console.WriteLine($"[Middleware 3] Outgoing Response: {context.Response.StatusCode} for {context.Request.Method} {context.Request.Path}");
        }
    }
}
