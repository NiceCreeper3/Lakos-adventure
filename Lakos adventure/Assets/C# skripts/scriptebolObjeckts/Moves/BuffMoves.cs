using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Moves", menuName = "PomonMoves/Buff Attack")]
public class BuffMoves : BasikMoves
{
    [System.Serializable]
    private struct Boffing
    {
        public int BuffTimes;
        public BattelLingMons.Buffs WhatToBuff;
    }

    [Header("Buffs")]
    [SerializeField] private Boffing[] _toBuff;

    public override void AbilityBefore(BattelLingMons interragsen)
    {
        foreach (Boffing buff in _toBuff)
        {
            interragsen.StatesBuff(buff.BuffTimes, buff.WhatToBuff);
        }
    }
}
