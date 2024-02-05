using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SwichePomon : MonoBehaviour
{
    public event Action<Pomons> OnPomonSelket;
    public event Action<Pomons, bool> OnPomonSwiching;

    [Header("the team of pomon chosen to battel")]
    [SerializeField] private Pomons[] _pomonTeam;

    private int _seletedPomon;

    private void Start()
    {

        FullHealTeam();

        _seletedPomon = 0; // seltes one that does not have Zero HP
        SwitchPomonConfurmt();
    }

    void FullHealTeam() //----------------------------------------------[ remove this after teasting]------------------------------------------------------
    {
        // full heales the team. so you don,t have to do it manuly
        foreach (Pomons pomons in _pomonTeam)
        {
            pomons.CurrentHealt = pomons.MaxHealt;
        }
    }



    // is goving to handel swithing ind a new pokemon
    public void SwitchPomonConfurmt()
    {
        OnPomonSwiching?.Invoke(_pomonTeam[_seletedPomon], false);
    }

    public void AIPickMon()
    {
        for (int i = 0; i == _pomonTeam.Length ; i++)
        {
            if (_pomonTeam[i].CurrentHealt < 0)
            {
                _seletedPomon = i;
                SwitchPomonConfurmt();
                break;
            }      
        }   

        // calles if 
    }

    // the buttons of picing a new Pomon is goving to be here
    public void SeltedPomon(int pomonNummber)
    {
        Debug.Log("attemting to swiche Pomon");

        if (_pomonTeam[pomonNummber].CurrentHealt > 0)
        {
            _seletedPomon = pomonNummber;
            OnPomonSelket?.Invoke(_pomonTeam[pomonNummber]);
        }
    }

}
