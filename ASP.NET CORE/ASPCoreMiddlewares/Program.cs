namespace ASPCoreMiddlewares
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");

            //1st middleware - for single middleware
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Welcome to ASP.Net Core6.");
            //});

            //2nd middleware - for multiple middleare we use app.use() function
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Welcome to ASP.Net Core6./n");
                await next(context);

                //it run when next middleware execute and return from it..
                await context.Response.WriteAsync("Returning from next middleware.");

            });

            //app.Run - not run the next middleware that's ehy we use it as a last ...
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("This is second middleware.");
            });



            //server statrting
            app.Run();
        }
    }
}
