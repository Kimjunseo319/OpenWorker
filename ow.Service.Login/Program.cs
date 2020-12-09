using ow.Service.Login.Game;
using ow.Service.Login.Network;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ow.Framework.IO.Lan.Extensions;
using ow.Framework.IO.Network.Extensions;

namespace ow.Service.Login
{
    public static class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) => services
                .AddHostedService<Worker>()
                .AddSingleton<Server>()
                .AddSingleton<GatesInstances>()
                .AddSingleton<Options>()
                .AddTransient<Session>()
                .AddNetwork()
                .AddLan());
    }
}