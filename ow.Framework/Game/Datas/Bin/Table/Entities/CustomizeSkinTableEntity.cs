﻿using ow.Framework.Attributes;
using ow.Framework.Extensions;
using ow.Framework.Game.Enums;
using System.Collections.Generic;
using System.IO;

namespace ow.Framework.Game.Datas.Bin.Table.Entities
{
    using KeyType = Hero;

    [BinTable("tb_Customize_Skin")]
    public sealed record CustomizeSkinTableEntity : ITableEntity<KeyType>
    {
        public KeyType Id { get; }
        public IReadOnlyList<uint> Unknown1 { get; }
        public IReadOnlyList<string> Icons { get; }
        public IReadOnlyList<uint> Color { get; }

        internal CustomizeSkinTableEntity(BinaryReader br)
        {
            Id = br.ReadHero();
            Unknown1 = br.ReadUInt32Array(ItemsCount);
            Icons = br.ReadByteLengthUnicodeStringArray(ItemsCount);
            Color = br.ReadUInt32Array(ItemsCount);
        }

        private const byte ItemsCount = 10;
    }
}