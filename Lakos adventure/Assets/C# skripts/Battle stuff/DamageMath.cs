using System.Collections;
using System.Collections.Generic;
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

    public static int AttackMath(Moves attack, Pomons pomon, Pomons target, StatsBuff buffs)
    {
        // tempeary values
        int rawDamage = 0;
        double totalDamage = 0;


        if (attack.power != 0) // makes sure buff moves don,t end up doving damige
            rawDamage = attack.power + pomon.Attack;

        // gets a multeplyer based on weter or not the enemy resistes or is weak to the attacks elemt
        double elementalMultyplayer = attack.MoveElement.ElementMultiplier(target.Spesies);

        // adds all the math togetter four a totalDamage value
        totalDamage = rawDamage * elementalMultyplayer * buffs.AttackBuff;

        Debug.Log(
            $"_______________{pomon.PomonName}_______________\n" +
            $"___________used {attack.MoveName}_______________ ");
        Debug.Log(
            $"raw damage is {rawDamage} geainde by {attack.power} + {pomon.Attack} \n" +
            $"Total damage is {totalDamage} geainde by {rawDamage} *{elementalMultyplayer} * {buffs.AttackBuff}");

        return (int)totalDamage;
    }

    public static int DefenderMath()
    {
        double totalDamage = 0;

        return (int)totalDamage;
    }
}
