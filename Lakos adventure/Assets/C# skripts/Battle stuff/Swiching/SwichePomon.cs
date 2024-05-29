using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwichePomon : Switching
{
    [Header("the team of pomon chosen to battel")]
    [SerializeField] private GameObject PicPomonUI;

    public event Action<Pomons> OnPomonSelket;
    #region setups

    protected override void Start()
    {
        base.Start();

        _isPlayer = true;

        _seletedPomon = 0; // seltes one that does not have Zero HP
        SwitchPomonConfurmt();
    }
    #endregion

    // Methodes
    #region
    // handels how a new Pomon is beaing swiceh ind. the enemy is goving to inhert this and change it 
    protected override void SwichePickMetthod()
    {
        RemoveDeadPomons();

        if (StillHasPomonLeft())
            PicPomonUI.SetActive(true);
        else
            EndBattle(0);
    }

    private void RemoveDeadPomons()
    {
        List<Pomons> pomonsToDelete = new List<Pomons>();

        // gets the pomons to remove
        foreach (Pomons pomon in _pomonTeam.team)
        {
            if (pomon.CurrentHealt == 0)
                pomonsToDelete.Add(pomon);
        }

        foreach (Pomons pomon in pomonsToDelete)
        {
            _pomonTeam.team.Remove(pomon);
        }
    }

    // the buttons of picing a new Pomon is goving to be here
    public void SeltedPomon(int pomonNummber)
    {
        try
        {
            if (_pomonTeam.team[pomonNummber].CurrentHealt > 0)
            {
                _seletedPomon = pomonNummber;
                OnPomonSelket?.Invoke(_pomonTeam.team[pomonNummber]);
            }
        }
        catch
        {
            Debug.Log("attemting to swiche Pomon");
        }
    }
    #endregion

}