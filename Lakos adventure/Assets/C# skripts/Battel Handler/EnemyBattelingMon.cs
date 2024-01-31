using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBattelingMon : BattelLingMons
{
    // is what Pomon the AI Piced
    private Pomons _pomonPiced;
    private bool pomonfound;

    protected override void SwichePomonLogic()
    {
        Debug.Log(2);
        AiPicPomon();

    }


    private void AiPicPomon()
    {
        pomonfound = false;

        Debug.Log("teast if array is full" + PomonTeam[1].PomonName);
        foreach (Pomons pomon in PomonTeam)
        {
            Debug.Log("is lokking four Pomon");
            if (pomon.CurrentHealt > 0 && !pomonfound)
            {
                Debug.Log(pomon.name);

                _currentMon = _pomonPiced;
                SwitchPomon(pomon);

                pomonfound = true;
                break;
            }
        }
    }
}
