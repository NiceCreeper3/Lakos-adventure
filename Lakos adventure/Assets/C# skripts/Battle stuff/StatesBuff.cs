public static class StatesBuff
{
    public struct StatsBuffs
    {
        // represents the buffes to a state. are public so arracks can modefi them
        public double AttackBuff;
        public double SpeedBuff;
        public double DefenseBuff;

        public StatsBuffs(double a, double s, double d)
        {
            this.AttackBuff = a;
            this.SpeedBuff = s;
            this.DefenseBuff = d;
        }
    }

    public enum Buff
    {
        AttackBuff,
        SpeedBuff,
        DefenseBuff
    }

    // the max amount of times we can buff. ind ither deregson
    public static double maxBuffAmount = 1.5;


    // adds stats "stabs". aka buffs
    public static StatsBuffs BuffSates(StatsBuffs buffSet, double buffTimes, Buff whatToBuff)
    {
        // what to buff and then buffs it
        switch (whatToBuff)
        {
            case Buff.AttackBuff:
                buffSet.AttackBuff += buffTimes;
                break;

            case Buff.SpeedBuff:
                buffSet.SpeedBuff += buffTimes;
                break;

            case Buff.DefenseBuff:
                buffSet.DefenseBuff += buffTimes;
                break;
        }

        // adds a buff cap. so you can only buffe up to [maxBuffTimes]
        if (maxBuffAmount < buffSet.AttackBuff)
            buffSet.AttackBuff = maxBuffAmount;
        if (maxBuffAmount < buffSet.SpeedBuff)
            buffSet.SpeedBuff = maxBuffAmount;
        if (maxBuffAmount < buffSet.DefenseBuff)
            buffSet.DefenseBuff = maxBuffAmount;

        // adds a buff cap to the -. so you can only go belove [maxBuffTimes]
        if (maxBuffAmount < -buffSet.AttackBuff)
            buffSet.AttackBuff = -maxBuffAmount;
        if (maxBuffAmount < -buffSet.SpeedBuff)
            buffSet.SpeedBuff = -maxBuffAmount;
        if (maxBuffAmount < -buffSet.DefenseBuff)
            buffSet.DefenseBuff = -maxBuffAmount;

        // returns the new stats buff
        return buffSet;
    }
}
