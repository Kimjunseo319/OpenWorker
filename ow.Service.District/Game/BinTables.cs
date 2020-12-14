﻿using ow.Framework.Game;
using ow.Framework.Game.Datas.Bin.Table;
using ow.Framework.Game.Datas.Bin.Table.Entities;
using ow.Framework.Game.Enums;
using System.Collections.Generic;

namespace ow.Service.District.Game
{
    public sealed class BinTables : IBinTables
    {
        public IReadOnlyDictionary<Hero, CustomizeSkinTableEntity> CustomizeSkinTable { get; }
        public IReadOnlyDictionary<Hero, CustomizeEyesTableEntity> CustomizeEyesTable { get; }
        public IReadOnlyDictionary<Hero, CustomizeHairTableEntity> CustomizeHairTable { get; }
        public IReadOnlyDictionary<ushort, DistrictTableEntity> DistrictTable { get; }

        public BinTables(BinTable tables)
        {
            CustomizeSkinTable = tables.ReadCustomizeSkinTable();
            CustomizeEyesTable = tables.ReadCustomizeEyesTable();
            CustomizeHairTable = tables.ReadCustomizeHairTable();
            DistrictTable = tables.ReadDistrictTable();
        }
    }
}