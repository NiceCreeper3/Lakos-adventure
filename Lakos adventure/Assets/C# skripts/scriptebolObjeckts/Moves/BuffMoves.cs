using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Moves", menuName = "PomonMoves/Buff Attack")]
public class BuffMoves : BasikMoves
{
    [SerializeField] private int buffTimes;
    [SerializeField] private BattelLingMons.buffs WhatToBuff;

    public override void AbilityBefore(BattelLingMons interragsen)
    {
        interragsen.StatesBuff(buffTimes, WhatToBuff);
    }
}
