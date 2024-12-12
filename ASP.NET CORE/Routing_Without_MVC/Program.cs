namespace Routing_Without_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");

            app.MapControllerRoute(
                name: default,
                pattern: "{controller=Home}/{action=Index}/{id?}"
                );



            app.Run();
        }
    }
}
