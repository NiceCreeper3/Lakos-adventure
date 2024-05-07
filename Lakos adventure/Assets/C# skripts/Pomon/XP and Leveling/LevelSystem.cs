using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem
{
    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;


    private ushort _level;
    private int _experience;
    private int _experienceToNextLevel;

    public LevelSystem(ushort level, int experience)
    {
        _level = 0;
        _experience = 0;
        _experienceToNextLevel = 100 * level * 2;
    }

    /// <summary>
    /// adds XP 
    /// </summary>
    /// <param name="xp"> amount xp to add</param>
    public void GetXP(int xp)
    {
        _experience += xp;

        while (_experience >= _experienceToNextLevel)
        {
            // Enough experience to level up
            _level++;
            _experience -= _experienceToNextLevel;

            OnLevelChanged?.Invoke(this, EventArgs.Empty);
        }

        OnExperienceChanged?.Invoke(this, EventArgs.Empty);
    }

    public int GetLevelNumber()
    {
        return _level;
    }

    public float GetExperienceNormalizez()
    {
        return (float)_experience / _experienceToNextLevel;
    }

}
