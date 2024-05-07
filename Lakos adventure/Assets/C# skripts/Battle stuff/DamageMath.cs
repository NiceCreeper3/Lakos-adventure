using UnityEngine;

public static class DamageMath
{
    private static short _minimumeDamage = 1;

    // does the attack damage math
    public static int AttackMath(Moves attack, Pomons pomon, Pomons target, StatesBuff.StatsBuffs buffs)
    {
        // tempeary values
        int rawDamage = 0;
        double totalAttackDamage = 0;

        // makes sure buff moves don,t end up doving damige
        rawDamage = attack.power + pomon.Attack;

        // gets a multeplyer based on weter or not the enemy resistes or is weak to the attacks elemt
        double elementalMultyplayer = attack.MoveElement.ElementMultiplier(target.Spesies);

        // adds all the math togetter four a totalDamage value
        totalAttackDamage = rawDamage * elementalMultyplayer + buffs.AttackBuff * rawDamage;

        Debug.Log(
            $"raw damage is {rawDamage} geainde by {attack.power} + {pomon.Attack} \n" +
            $"Total damage is {totalAttackDamage} geainde by {rawDamage} *{elementalMultyplayer} * {buffs.AttackBuff}");

        return (int)totalAttackDamage;
    }

    //takes does the defendes math
    public static int DefenderMath(Pomons enemyPomon, int damage, StatesBuff.StatsBuffs enemyDefendBuffs)
    {
        double totalDefendsDamage = 0;

        // aclkulates kow muthe damage is dealt
        totalDefendsDamage = (enemyPomon.Defense * enemyDefendBuffs.DefenseBuff) + enemyPomon.Defense - damage ;

        Debug.Log($"{enemyPomon.PomonName} damge defended is {totalDefendsDamage} given by {enemyDefendBuffs.DefenseBuff} - {damage}");

        // ind case Defense is higer then damage. this sets it to _minimumeDamage. to indsure the user still does som damage. and does not heal the aponent
        if (totalDefendsDamage > damage)
            totalDefendsDamage = _minimumeDamage;

        return (int)totalDefendsDamage;
    }
}
