using UnityEngine;

public static class DamageMath
{
    public struct StatsBuff
    {
        // represents the buffes to a state. are public so arracks can modefi them
        public double AttackBuff;
        public double SpeedBuff;
        public double DefenseBuff;

        public StatsBuff(double a, double s, double d)
        {
            this.AttackBuff = a;
            this.SpeedBuff = s;
            this.DefenseBuff = d;
        }
    }

    private static short _minimumeDamage = 1;

    // does the attack damage math
    public static int AttackMath(Moves attack, Pomons pomon, Pomons target, StatsBuff buffs)
    {
        // tempeary values
        int rawDamage = 0;
        double totalAttackDamage = 0;


        if (attack.power != 0) // makes sure buff moves don,t end up doving damige
            rawDamage = attack.power + pomon.Attack;

        // gets a multeplyer based on weter or not the enemy resistes or is weak to the attacks elemt
        double elementalMultyplayer = attack.MoveElement.ElementMultiplier(target.Spesies);

        // adds all the math togetter four a totalDamage value
        totalAttackDamage = rawDamage * elementalMultyplayer * buffs.AttackBuff;

        Debug.Log(
            $"_______________{pomon.PomonName}_______________\n" +
            $"___________used {attack.MoveName}_______________ ");
        Debug.Log(
            $"raw damage is {rawDamage} geainde by {attack.power} + {pomon.Attack} \n" +
            $"Total damage is {totalAttackDamage} geainde by {rawDamage} *{elementalMultyplayer} * {buffs.AttackBuff}");

        return (int)totalAttackDamage;
    }

    //takes does the defendes math
    public static int DefenderMath(Pomons enemyPomon, int damage, StatsBuff enemyDefendBuffs)
    {
        int totalDefendsDamage = 0;

        // aclkulates kow muthe damage is dealt
        totalDefendsDamage = damage - (int)(enemyPomon.Defense * enemyDefendBuffs.DefenseBuff);

        Debug.Log(
            $"{enemyPomon.PomonName} damge defended is {totalDefendsDamage} given by {enemyDefendBuffs.DefenseBuff} - {damage} \n" +
            "______________________________________________[Math]______________________________________________________");

        // ind case Defense is higer then damage. this sets it to _minimumeDamage. to indsure the user still does som damage. and does not heal the aponent
        if (totalDefendsDamage < 0)
            totalDefendsDamage = _minimumeDamage;

        return totalDefendsDamage;
    }
}
