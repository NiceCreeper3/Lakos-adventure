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
        AiPicPomon();
        SwitchPomon(_pomonPiced); // this brackes?
    }


    private void AiPicPomon()
    {
        pomonfound = false;

        Debug.Log(TeastArrey);
        foreach (Pomons pomon in TeastArrey)
        {
            Debug.Log("is lokking four Pomon");
            if (pomon.CurrentHealt !<= 0 && !pomonfound)
            {
                Debug.Log(pomon);
                _currentMon = _pomonPiced;
                pomonfound = true;
            }
        }
    }
}
