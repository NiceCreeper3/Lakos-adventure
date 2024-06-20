using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelChalkulater
{
    private static byte _maxLevel;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pomon"></param>
    /// <returns>the amount we have leveled up</returns>
    public static int LinkenXP(Pomons pomon)
    {
        ushort timesItLevel = 0;

        while (pomon.Expirence >= ExpinseToNextLevel(pomon.Level))
        {
            Debug.Log($" Level({pomon.Level}), XP To level({ExpinseToNextLevel(pomon.Level)}), Xp is: {pomon.Expirence}");

            if (pomon.Level > _maxLevel)
            {
                pomon.Level = _maxLevel;
            }
            else
            {
                // Enough experience to level up
                pomon.Expirence -= ExpinseToNextLevel(pomon.Expirence);
                pomon.Level++;

                timesItLevel++;
            }
        }

        IncreseStates(pomon, timesItLevel);

        return timesItLevel;
    }

    /// <summary>
    /// Incresise the states of a pomon
    /// </summary>
    /// <param name="pomon"></param>
    /// <param name="leveledUPTimes"></param>
    public static void IncreseStates(Pomons pomon, int leveledUPTimes)
    {
        PomonsBluPrint.Statgrow[] states = pomon.Spesies.StatesGrows;

        // increse the Pomons states using its states growf and how mane leves it went up
        for (int i = 0; i < leveledUPTimes; i++)
        {
            Debug.Log($"Level to stat increse {1 - i + pomon.Level}");

            pomon.MaxHealt += states[i + pomon.Level].HealtUp;
            pomon.Attack += states[i + pomon.Level].AttackUp;
            pomon.Defense += states[i + pomon.Level].DefendesUp;
            pomon.Speed += states[i + pomon.Level].SpeedUp;
        }
    }

    public static int ExpinseToNextLevel(int Level)
    {
        int baseMultiplyer = 100;
        int ToNewLevel = 0;

        ToNewLevel = (1 + Level) * baseMultiplyer;

        return ToNewLevel;
    }

}
