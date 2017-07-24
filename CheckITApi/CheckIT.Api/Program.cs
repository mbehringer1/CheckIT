using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Exercise1Console
{
    //A lot of great articles on setting this up.
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://localhost:9001")//TODO: a more dynamic way of establishing the url.
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
