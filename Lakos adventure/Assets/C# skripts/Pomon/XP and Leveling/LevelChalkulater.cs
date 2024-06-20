using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelChalkulater
{
    private static byte _maxLevel = 20;

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
            if (pomon.Level > _maxLevel)
            {
                pomon.Level = _maxLevel;
                pomon.Expirence -= ExpinseToNextLevel(pomon.Level);
                break;
            }
            else
            {
                // Enough experience to level up
                pomon.Expirence -= ExpinseToNextLevel(pomon.Level);
                pomon.Level++;

                timesItLevel++;
            }

            Debug.Log($" Level({pomon.Level}), XP To next level({ExpinseToNextLevel(pomon.Level)}), Xp is: {pomon.Expirence}");
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

            if (pomon.Level < _maxLevel)
            {
                Debug.Log($"Level to stat increse {i + pomon.Level}");

                pomon.MaxHealt += states[i + pomon.Level].HealtUp;
                pomon.Attack += states[i + pomon.Level].AttackUp;
                pomon.Defense += states[i + pomon.Level].DefendesUp;
                pomon.Speed += states[i + pomon.Level].SpeedUp;
            }
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
