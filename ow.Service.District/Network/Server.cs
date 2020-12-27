﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCoreServer;
using ow.Framework;
using ow.Framework.IO.Network.Sync;
using System;
using System.Net;

namespace ow.Service.District.Network
{
    public sealed class Server : SyncServer
    {
        public Server(IServiceProvider services, IConfiguration configuration) : base(services, GetEndPoint(configuration))
        {
        }

        protected override TcpSession CreateSession() => Services.GetRequiredService<Session>();

        private static IPEndPoint GetEndPoint(IConfiguration configuration) =>
            IPEndPoint.Parse($"{configuration.GetSection($"Districts:{configuration.GetValue<string>("Id")}").Get<GateConfiguration>().Host}");
    }
}