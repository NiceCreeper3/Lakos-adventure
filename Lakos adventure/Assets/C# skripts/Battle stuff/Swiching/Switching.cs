using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Switching : MonoBehaviour
{
    #region Values
    [Header("the team of pomon chosen to battel")]
    [SerializeField] protected pomonteam _pomonTeam;

    [SerializeField] protected bool _isPlayer;
    protected int _seletedPomon;
  
    public event Action<Pomons, bool> OnPomonSwiching;
    public event Action<ushort> OnGiveXP;
    public event Action OnBattleOver;

    private BattelLingMons onNeededSwiche;
    #endregion

    #region setups
    protected virtual void Awake()
    {
        onNeededSwiche = GetComponent<BattelLingMons>();
        onNeededSwiche.OnPomonSwicheNeeded += OnNeededSwiche_OnPomonSwicheNeeded;
    }

    protected virtual void Start()
    {
        FullHealTeam();
    }
    #endregion

    private void OnNeededSwiche_OnPomonSwicheNeeded()
    {
        // turns on the swiche UI
        SwichePickMetthod();
    }

    private void FullHealTeam() //----------------------------------------------[ remove this after teasting]------------------------------------------------------
    {
        // full heales the team. so you don,t have to do it manuly
        foreach (Pomons pomons in _pomonTeam.team)
            pomons.CurrentHealt = pomons.MaxHealt;
    }

    // handels how a new Pomon is beaing swiceh ind. the enemy is goving to inhert this and change it 
    protected virtual void SwichePickMetthod()
    {

    }

    // is goving to handel swithing ind a new pokemon
    public void SwitchPomonConfurmt()
    {
        Debug.Log($"swiching linken {_pomonTeam.team[_seletedPomon]}");

        OnPomonSwiching?.Invoke(_pomonTeam.team[_seletedPomon], _isPlayer);
    }

    protected bool StillHasPomonLeft()
    {
        bool noPomonFound = false;

        foreach (Pomons pomons in _pomonTeam.team)
        {
            // checkes the team still has pomon with full healt
            if (pomons.CurrentHealt > 0)
            {
                noPomonFound = true;
                break;
            }
        }

        return noPomonFound;
    }

    protected void EndBattle(ushort xpMultyplayer)
    {
        OnGiveXP?.Invoke(xpMultyplayer);
        OnBattleOver?.Invoke();
    }
}
