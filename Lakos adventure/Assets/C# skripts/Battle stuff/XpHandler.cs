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

<<<<<<< Updated upstream
            // this is only indcase of debug where the game does not make a levelsystem ind a prebild Linkens
            if (pomon.level != null)
            {
                levelUps = pomon.level.GiveXP(100 * multiplayer);
                pomon.level.IncreseStates(pomon, levelUps);
            }
            else
            {
                pomon.level = new LevelSystem();
                levelUps = pomon.level.GiveXP(100 * multiplayer);
                pomon.level.IncreseStates(pomon, levelUps);
            }
=======
            pomon.Level += 100 * multiplayer;
            levelUps = (ushort)LevelChalkulater.LinkenXP(pomon);
>>>>>>> Stashed changes

            OnPomonLevel?.Invoke(pomon, levelUps);

        }
    }
}
