public static class BuffingMoves
{
    // buffing
    #region
    [System.Serializable]
    public struct BuffInfo
    {
        public StatesBuff.Buff WhatToBuff;
        public HowToBuff HowToBuff;     
    }

    // makes it easyer to keep trak of how we buff/debuff
    public enum HowToBuff
    {
        LesserIncrease,
        LesserDebuff,
        StatIncrease,
        StatdeDebuff,
        MasiveStatIncrease,   
        MasiveStatDebuff    
    }
    #endregion

    public static void Buff(BattelLingMons interragsen, BuffInfo[] buffing)
    {
        foreach (BuffInfo buff in buffing)
        {
            interragsen.BuffPomon(HowToStat(buff.HowToBuff), buff.WhatToBuff);
        }
    }


    // gets the buff/debuff number
    private static double HowToStat(HowToBuff howToBuff)
    {
        double lesserIncrease = 0.25;
        double statIncrease = 0.5;
        double masiveStatIncrease = 1;
        

        double buffNumber = 0;

        switch (howToBuff)
        {
            // Increase states
            case HowToBuff.LesserIncrease:
                buffNumber = lesserIncrease;
                break;
            case HowToBuff.StatIncrease:
                buffNumber = statIncrease;
                break;
            case HowToBuff.MasiveStatIncrease:
                buffNumber = masiveStatIncrease;
                break;


            // Dincrease states
            case HowToBuff.LesserDebuff:
                buffNumber = -lesserIncrease;
                break;
            case HowToBuff.StatdeDebuff:
                buffNumber = -statIncrease;
                break;
            case HowToBuff.MasiveStatDebuff:
                buffNumber = -masiveStatIncrease;
                break;
        }

        return buffNumber;
    }
}
