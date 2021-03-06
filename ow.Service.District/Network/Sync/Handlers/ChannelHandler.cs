﻿using ow.Framework.IO.Network.Sync.Attributes;
using ow.Framework.IO.Network.Sync.Opcodes;
using ow.Framework.IO.Network.Sync.Permissions;
using ow.Framework.IO.Network.Sync.Responses;
using ow.Service.District.Game;
using ow.Service.District.Game.Repositories;
using System.Linq;

namespace ow.Service.District.Network.Sync.Handlers
{
    public sealed class ChannelHandler
    {
        [Handler(ServerOpcode.ChannelInfo, HandlerPermission.Authorized)]
        public void GetInfo(SyncSession session) => session
            .SendAsync(new ChannelInfoResponse()
            {
                Location = _instance.Location.Id,
                Values = _channels.Values.Select(s => new ChannelInfoResponse.Entity()
                {
                    Id = (ushort)(1 + s.Id),
                    Status = s.Status
                })
            });

        //[Handler(ServerOpcode.ChannelSwitch, HandlerPermission.Authorized)]
        //public static void Switch(Session session) => session;

        public ChannelHandler(Instance instance, ChannelRepository channels) =>
            (_instance, _channels) = (instance, channels);

        private readonly Instance _instance;
        private readonly ChannelRepository _channels;
    }
}