﻿using ow.Framework.Game;
using ow.Framework.IO.Network.Sync.Requests;
using ow.Framework.IO.Network.Sync.Responses;
using ow.Service.District.Game.Helpers;
using ow.Service.District.Network.Sync;
using System.Linq;
using static ow.Service.District.Game.Repositories.ChannelRepository;

namespace ow.Service.District.Game
{
    public sealed class ChannelMember : BaseChannelMember<ChannelEntity, SyncSession>
    {
        public void Leave() => Channel.Leave(Session);

        public void SendOtherCharactersAsync(Instance instance) =>
            SendAsync(new CharacterOthersResponse()
            {
                Values = Channel.Sessions.Select(s => new CharacterOthersResponse.Entity()
                {
                    Character = ResponseHelper.GetCharacter(s.Value),
                    Place = ResponseHelper.GetPlace(s.Value, instance)
                })
            });

        public void SendAsync(CharacterSpecialOptionListUpdateRequest request)
        {
            SyncSession? session = Channel.Sessions.Values.FirstOrDefault(s => s.Character.Id == request.Character);
            if (session is null)
                return;

            SendAsync(new CharacterSpecialOptionListUpdateResponse()
            {
                Character = session.Character.Id,
                Values = session.SpecialOptions.Select(s => new CharacterSpecialOptionListUpdateResponse.Entity()
                {
                    Id = s.Id,
                    Value = s.Value
                })
            });
        }

        public ChannelMember(SyncSession session, ChannelEntity channel) : base(session, channel)
        {
        }
    }
}

// https://youtu.be/7mosZiponDg