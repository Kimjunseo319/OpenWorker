﻿using ow.Framework.Game.Character;
using ow.Framework.Game.Enums;
using System;
using System.Collections.Generic;

namespace ow.Framework.Game.Entities
{
    public interface IStatsEntity : IReadOnlyList<StatEntity>
    {
        StatEntity this[Stat index] => throw new NotImplementedException();

        StatEntity Unknown0 => throw new NotImplementedException();
        StatEntity CurrentHp => throw new NotImplementedException();
        StatEntity CurrentSg => throw new NotImplementedException();
        StatEntity Unknown3 => throw new NotImplementedException();
        StatEntity Unknown4 => throw new NotImplementedException();
        StatEntity Unknown5 => throw new NotImplementedException();
        StatEntity Unknown6 => throw new NotImplementedException();
        StatEntity Unknown7 => throw new NotImplementedException();
        StatEntity Unknown8 => throw new NotImplementedException();
        StatEntity Unknown9 => throw new NotImplementedException();
        StatEntity MaxHp => throw new NotImplementedException();
        StatEntity Unknown11 => throw new NotImplementedException();
        StatEntity MaxSg => throw new NotImplementedException();
        StatEntity Unknown12 => throw new NotImplementedException();
        StatEntity Unknown13 => throw new NotImplementedException();
        StatEntity Stamina => throw new NotImplementedException();
        StatEntity StaminaRegeneration => throw new NotImplementedException();
        StatEntity Unknown16 => throw new NotImplementedException();
        StatEntity Unknown17 => throw new NotImplementedException();
        StatEntity MoveSpeed => throw new NotImplementedException();
        StatEntity AttackSpeed => throw new NotImplementedException();
        StatEntity MinAttackDamage => throw new NotImplementedException();
        StatEntity MaxAttackDamage => throw new NotImplementedException();
        StatEntity Unknown22 => throw new NotImplementedException();
        StatEntity Unknown23 => throw new NotImplementedException();
        StatEntity Defence => throw new NotImplementedException();
        StatEntity Unknown25 => throw new NotImplementedException();
        StatEntity Accuracy => throw new NotImplementedException();
        StatEntity Unknown27 => throw new NotImplementedException();
        StatEntity PartialDamage => throw new NotImplementedException();
        StatEntity CritChance => throw new NotImplementedException();
        StatEntity Unknown30 => throw new NotImplementedException();
        StatEntity CritResistance => throw new NotImplementedException();
        StatEntity Unknown32 => throw new NotImplementedException();
        StatEntity Unknown33 => throw new NotImplementedException();
        StatEntity Unknown34 => throw new NotImplementedException();
        StatEntity CritDamage => throw new NotImplementedException();
        StatEntity Unknown36 => throw new NotImplementedException();
        StatEntity Unknown37 => throw new NotImplementedException();
        StatEntity DamageReduction => throw new NotImplementedException();
        StatEntity Unknown39 => throw new NotImplementedException();
        StatEntity Unknown40 => throw new NotImplementedException();
        StatEntity Unknown41 => throw new NotImplementedException();
        StatEntity Unknown42 => throw new NotImplementedException();
        StatEntity Evade => throw new NotImplementedException();
        StatEntity Unknown44 => throw new NotImplementedException();
        StatEntity Unknown45 => throw new NotImplementedException();
        StatEntity Unknown46 => throw new NotImplementedException();
        StatEntity ArmourBreak => throw new NotImplementedException();
        StatEntity Unknown48 => throw new NotImplementedException();
        StatEntity FireResistance => throw new NotImplementedException();
        StatEntity PoisonResistance => throw new NotImplementedException();
        StatEntity ElectricResistance => throw new NotImplementedException();
        StatEntity BleedResistance => throw new NotImplementedException();
        StatEntity Stun1Resistance => throw new NotImplementedException();
        StatEntity ParalysisResistance => throw new NotImplementedException();
        StatEntity SleepResistance => throw new NotImplementedException();
        StatEntity FrostResistance => throw new NotImplementedException();
        StatEntity SilenceResistance => throw new NotImplementedException();
        StatEntity VulnResistance => throw new NotImplementedException();
        StatEntity Stun2Resistance => throw new NotImplementedException();
        StatEntity ConfusedResistance => throw new NotImplementedException();
        StatEntity Unknown61 => throw new NotImplementedException();
        StatEntity Unknown62 => throw new NotImplementedException();
        StatEntity VirtueDamage => throw new NotImplementedException();
        StatEntity SinDamage => throw new NotImplementedException();
        StatEntity GraceDamage => throw new NotImplementedException();
        StatEntity HateDamage => throw new NotImplementedException();
        StatEntity SolaceDamage => throw new NotImplementedException();
        StatEntity TormentDamage => throw new NotImplementedException();
        StatEntity VirtueResistance => throw new NotImplementedException();
        StatEntity SinResistance => throw new NotImplementedException();
        StatEntity GraceResistance => throw new NotImplementedException();
        StatEntity HateResistance => throw new NotImplementedException();
        StatEntity SolaceResistance => throw new NotImplementedException();
        StatEntity TormentResistance => throw new NotImplementedException();
        StatEntity ManicBalanceDamage => throw new NotImplementedException();
        StatEntity ManicBalanceResistance => throw new NotImplementedException();
    }
}