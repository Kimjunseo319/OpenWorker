﻿using ow.Framework.Game.Enums;

namespace ow.Framework.IO.Network.Sync.Responses
{
    public sealed record SAuthLoginResponse
    {
        public AuthLoginStatus Response { get; init; }
        public int AccountId { get; init; }
        public ulong SessionKey { get; init; }
        public string Mac { get; init; } = "00-00-00-00-00-00";
        public AuthLoginErrorMessageCode ErrorMessageCode { get; init; } = AuthLoginErrorMessageCode.None;
        public string ErrorMessage { get; init; } = string.Empty;
    }
}