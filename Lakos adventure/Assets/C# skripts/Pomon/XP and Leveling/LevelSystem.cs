using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem
{
    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;

    private ushort _maxLevel;
    private ushort _level;
    private int _experience;
    private int _experienceToNextLevel;

    /// <summary>
    /// level must never be under eny surkemsans 0. as this vil make it a infint loop
    /// </summary>
    /// <param name="level"></param>
    /// <param name="experience"></param>
    public LevelSystem(ushort level = 0, int experience = 0)
    {
        _maxLevel = 20;
        _level = level;
        _experience = experience;
        _experienceToNextLevel = SetExpinceToNextLevel(_level);
    }


    /// <summary>
    /// adds XP
    /// </summary>
    /// <param name="xp"> how muthe Xp the </param>
    /// <returns> returnes the amount of times we leved up</returns>
    public ushort GiveXP(int xp)
    {
        ushort timesItLevel = 0;

        _experience += xp;

        while (_experience >= _experienceToNextLevel && _experience != 0)
        {
            Debug.Log($" Level({_level}), XP To level({_experienceToNextLevel}), Xp granted({xp}/{_experience})");

            if (_level > _maxLevel)
            {
                _level = _maxLevel;
            }
            else
            {
                // Enough experience to level up
                _level++;
                _experience -= _experienceToNextLevel;

                // increses the needed xp four next level
                _experienceToNextLevel = SetExpinceToNextLevel(_level);

                timesItLevel++;

                OnLevelChanged?.Invoke(this, EventArgs.Empty);
            }          
        }

        Debug.Log($" Level({_level}), XP To level({_experienceToNextLevel}), Xp granted({xp}/{_experience})");

        OnExperienceChanged?.Invoke(this, EventArgs.Empty);

        return timesItLevel;

    }

    private int SetExpinceToNextLevel(ushort levelMath)
    {
        int baseMultiplyer = 100;
        int ToNewLevel = 0;

        ToNewLevel = (1 + levelMath) * baseMultiplyer;

        return ToNewLevel;
    }


    /// <summary>
    /// Incresise the states of a pomon
    /// </summary>
    /// <param name="pomon"></param>
    /// <param name="levelUp"></param>
    public void IncreseStates(Pomons pomon, int levelUp)
    {
        PomonsBluPrint.Statgrow[] states = pomon.Spesies.StatesGrows;
        
        // increse the Pomons states using its states growf and how mane leves it went up
        for (int i = 0; i < levelUp; i++)
        {
            Debug.Log($"Level to stat increse {1 - i + _level}");

            pomon.MaxHealt += states[i + _level].HealtUp;
            pomon.Attack += states[i + _level].AttackUp;
            pomon.Defense += states[i + _level].DefendesUp;
            pomon.Speed += states[i + _level].SpeedUp;
        }
    }


    public int GetLevelNumber()
    {
        return _level;
    }

    public float GetExperienceNormalizez()
    {
        //return (float)_experience / _experienceToNextLevel;
        return _experience;
    }

    public int GetExpirenceOntilNextLevel()
    {
        return _experienceToNextLevel;
    }

}
