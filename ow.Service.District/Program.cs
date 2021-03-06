using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ow.Framework.Extensions;
using ow.Framework.IO.File.World;
using ow.Framework.IO.Network.Relay.Extensions;
using ow.Framework.IO.Network.Relay.Global;
using ow.Framework.IO.Network.Sync.Extensions;
using ow.Service.District.Game;
using ow.Service.District.Game.Repositories;
using ow.Service.District.Network.Relay;
using ow.Service.District.Network.Sync;

namespace ow.Service.District
{
    public static class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) => config
                .AddFrameworkConfig(context))
            .ConfigureServices((context, services) => services
                .AddSyncHandlers()
                .AddHostedService<Worker>()
                .AddSingleton<ChatCommandRepository>()
                .AddSingleton<ChannelRepository>()
                .AddSingleton<BinTables>()
                .AddSingleton<Instance>()
                .AddSingleton<DayEventBoosterRepository>()
                .AddSingleton<BoosterRepository>()
                .AddSingleton<NpcRepository>()
                .AddSingleton<SyncServer>()
                .AddSingleton<GateInstance>()
                .AddTransient<WorldTable>()
                .AddTransient<SyncSession>()
                .AddSingleton<RWClient>()
                .AddSingleton<RGClient>()
                .AddSingleton<RWServer>()
                .AddAccountContext(context)
                .AddCharacterContext(context)
                .AddItemContext(context)
                .AddRelayHandlers());
    }
}