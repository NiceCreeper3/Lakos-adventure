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

            pomon.Level += 100 * multiplayer;
            levelUps = (ushort)LevelChalkulater.LinkenXP(pomon);

            OnPomonLevel?.Invoke(pomon, levelUps);

        }
    }
}
