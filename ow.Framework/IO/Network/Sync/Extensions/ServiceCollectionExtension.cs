﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ow.Framework.Database.Accounts;
using ow.Framework.Database.Characters;
using ow.Framework.Database.Storages;
using ow.Framework.IO.Network.Sync.Attributes;
using ow.Framework.IO.Network.Sync.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ow.Framework.IO.Network.Sync.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddAccountContext(this IServiceCollection services, HostBuilderContext context) => services
            .AddContext<AccountContext>(context);

        public static IServiceCollection AddCharacterContext(this IServiceCollection services, HostBuilderContext context) => services
            .AddContext<CharacterContext>(context);

        public static IServiceCollection AddItemContext(this IServiceCollection services, HostBuilderContext context) => services
            .AddContext<ItemContext>(context);

        public static IServiceCollection AddSyncHandlers(this IServiceCollection services)
        {
            foreach (Type type in GetSyncHandlers())
                services.AddTransient(type);

            return services.AddSingleton<HandlerProvider>();
        }

        private static IEnumerable<Type> GetSyncHandlers() => AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .SelectMany(type => type.GetMethods(BindingFlags.Public | BindingFlags.Instance))
            .Where(type => type.IsDefined(typeof(HandlerAttribute)))
            .Select(t => t.DeclaringType!)
            .Distinct();

        private static IServiceCollection AddContext<TContext>(this IServiceCollection services, HostBuilderContext context) where TContext : notnull, DbContext => services
            .AddPooledDbContextFactory<TContext>(options => options
                .UseNpgsql(context.Configuration.GetConnectionString("PgsqlConnection"), b => b.EnableRetryOnFailure()));
    }
}