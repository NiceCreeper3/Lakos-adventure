using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpHandler : MonoBehaviour
{
    // basik verson. can make it beader
    [SerializeField] private pomonteam PlayerLinkens;

    [SerializeField] private Switching[] EventRefendes;

    public event Action<Pomons, ushort> OnPomonLevel;

    private void Awake()
    {
        foreach (Switching switchingEvent in EventRefendes)
            switchingEvent.OnGiveXP += SwitchingEvent_OnGiveXP;
    }

    private void SwitchingEvent_OnGiveXP(ushort obj)
    {
        GiveXp(obj);
    }

    private void GiveXp(ushort multiplayer)
    {

        Debug.Log($"give xp multiplayer:{multiplayer}");
        ushort levelUps = 0;

        // gives the playeres Linkens XP 
        foreach (Pomons pomon in PlayerLinkens.team)
        {
            levelUps = 0;

            // this is only indcase of debug where the game does not make a levelsystem ind a prebild Linkens
            if (pomon.Level != null)
            {
                levelUps = pomon.Level.GiveXP(100 * multiplayer);
                pomon.Level.IncreseStates(pomon, levelUps);
            }
            else
            {
                pomon.Level = new LevelSystem();
                levelUps = pomon.Level.GiveXP(100 * multiplayer);
                pomon.Level.IncreseStates(pomon, levelUps);
            }

            OnPomonLevel?.Invoke(pomon, levelUps);

        }
    }
}
