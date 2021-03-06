﻿using System;

namespace ow.Framework.Game.Datas.Bin
{
    public interface ITableEntity<TId> where TId : IConvertible
    {
        TId Id { get; }
    }
}
