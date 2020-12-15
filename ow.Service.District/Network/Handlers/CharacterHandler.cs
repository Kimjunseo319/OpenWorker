﻿using ow.Framework.IO.Network;
using ow.Framework.IO.Network.Attributes;
using ow.Framework.IO.Network.Opcodes;
using ow.Framework.IO.Network.Permissions;
using ow.Framework.IO.Network.Requests.Character;
using ow.Service.District.Game;

namespace ow.Service.District.Network.Handlers
{
    internal static class CharacterHandler
    {
        [Handler(ServerOpcode.OthersInfo, HandlerPermission.Authorized)]
        public static void GetOthers(GameSession session, CachedNpcs npcs) => session
            .SendCharacterOtherInfos()
            .SendNpcOtherInfos(npcs);

        [Handler(ServerOpcode.CharacterToggleWeapon, HandlerPermission.Authorized)]
        public static void ToggleWeapon(GameSession session, ToggleWeaponRequest request) => session
            .SendCharacterToggleWeapon(request);
    }
}