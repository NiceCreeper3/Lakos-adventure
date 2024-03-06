using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Buffing
{
    // buffing
    #region
    [System.Serializable]
    public struct BuffInfo
    {
        public BattelLingMons.Buffs WhatToBuff;
        public HowToBuff HowToBuff;     
    }

    // makes it easyer to keep trak of how we buff/debuff
    public enum HowToBuff
    {
        LesserInkres,
        LesserDebuff,
        StatInkres,
        StatdeDebuff,
        MasiveStatInkres,   
        MasiveStatDebuff    
    }

    public static void Buff(BattelLingMons interragsen, BuffInfo[] buffing)
    {
        foreach (BuffInfo buff in buffing)
        {
            interragsen.StatesBuff(HowToStat(buff.HowToBuff), buff.WhatToBuff);
        }
    }
    #endregion

    // gets the buff/debuff number
    private static double HowToStat(HowToBuff howToBuff)
    {
        double lesserInkres = 0.25;
        double statInkres = 0.5;
        double masiveStatInkres = 1;


        double buffNumber = 0;

        switch (howToBuff)
        {
            // buff states
            case HowToBuff.LesserInkres:
                buffNumber = lesserInkres;
                break;
            case HowToBuff.StatInkres:
                buffNumber = statInkres;
                break;
            case HowToBuff.MasiveStatInkres:
                buffNumber = masiveStatInkres;
                break;


            // dekres states
            case HowToBuff.LesserDebuff:
                buffNumber = -lesserInkres;
                break;
            case HowToBuff.StatdeDebuff:
                buffNumber = -statInkres;
                break;
            case HowToBuff.MasiveStatDebuff:
                buffNumber = -masiveStatInkres;
                break;
        }

        return buffNumber;
    }

}
