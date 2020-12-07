﻿using Core.Systems.GameSystem.Datas.Bin;
using Core.Systems.GameSystem.Datas.Bin.Table;
using Core.Systems.GameSystem.Datas.Bin.Table.Entities;
using Microsoft.Extensions.Configuration;
using SoulWorker.Types;

namespace Core.Systems.GameSystem
{
    public class BinTableProcessor
    {
        public ICustomizeEyesTable ReadCustomizeEyesTable() =>
            TableReader<HeroType, CustomizeHairTableEntity>.Read(_data, "tb_Customize_Eyes") as ICustomizeEyesTable;

        public ICustomizeHairTable ReadCustomizeHairTable() =>
            TableReader<HeroType, CustomizeHairTableEntity>.Read(_data, "tb_Customize_Hair") as ICustomizeHairTable;

        public IDistrictTable ReadDistrictTable() =>
            TableReader<ushort, DistrictTableEntity>.Read(_data, "tb_district") as IDistrictTable;

        public IDistrictTable ReadItemTable() =>
            TableReader<uint, ItemTableEntity>.Read(_data, "tb_item") as IDistrictTable;

        public BinTableProcessor(IConfiguration configuration) => _data = new(configuration);

        private readonly VData12 _data;
    }
}