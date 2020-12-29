﻿using Microsoft.EntityFrameworkCore;
using ow.Framework.Database.Accounts;
using ow.Framework.Database.Characters;
using ow.Framework.Database.Storages;
using ow.Framework.Game.Enums;
using ow.Framework.IO.Lan;
using ow.Framework.IO.Network.Sync.Attributes;
using ow.Framework.IO.Network.Sync.Opcodes;
using ow.Framework.IO.Network.Sync.Permissions;
using ow.Framework.IO.Network.Sync.Requests;
using ow.Framework.IO.Network.Sync.Responses;
using ow.Framework.Utils;
using ow.Service.Gate.Game;
using System;
using System.Linq;

namespace ow.Service.Gate.Network.Handlers
{
    public sealed class ServiceHandler
    {
        [Handler(ServerOpcode.GateEnter, HandlerPermission.UnAuthorized)]
        public void Enter(Session session, GateEnterRequest request)
        {
            if (_gate.Id != request.Gate)
                NetworkUtils.DropSession();

            if (request.Account != _lan.GetAccountIdBySessionKey(request.SessionKey))
                NetworkUtils.DropSession();

            {
                using AccountContext context = _accountFactory();

                AccountModel model = context.Accounts.AsNoTracking().First(c => c.Id == request.Account);

                session.Account = new(model);
                session.Characters = GetCharacters(model, request.Gate);
                session.Background = model.CharacterBackground;
            }

            session.SendAsync(new GateEnterResponse() { AccountId = request.Account, Result = GateEnterResult.Success });
            session.SendAsync(new ServiceCurrentDataResponse());
        }

        private Characters GetCharacters(AccountModel model, ushort gate)
        {
            using CharacterContext characterContext = _characterFactory();
            using ItemContext itemContext = _itemFactory();

            return new(model, gate, _tables, characterContext, itemContext);
        }

        public ServiceHandler(GateInstance gate, LanContext lan, BinTables tables, Func<ItemContext> itemFactory, Func<AccountContext> accountFactory, Func<CharacterContext> characterFactory)
        {
            _gate = gate;
            _lan = lan;
            _tables = tables;
            _itemFactory = itemFactory;
            _accountFactory = accountFactory;
            _characterFactory = characterFactory;
        }

        private readonly GateInstance _gate;
        private readonly LanContext _lan;
        private readonly BinTables _tables;
        private readonly Func<ItemContext> _itemFactory;
        private readonly Func<AccountContext> _accountFactory;
        private readonly Func<CharacterContext> _characterFactory;
    }
}