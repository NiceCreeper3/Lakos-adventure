using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class BattelLingMons : MonoBehaviour
{
    // Values
    #region

    [SerializeField] private Pomons _currentMon;

    [SerializeField] private bool _isPlayerPomon;

    // pomon uses this temprary battel valuse to battel
    [HideInInspector] public int _attack;
    [HideInInspector] private int _speed;
    [HideInInspector] private int _defense;

    // evnets
    public event Action<int> OnHealhtChange;
    public event Action<Pomons> OnPomonSwiche;

    //[SerializeField] private IntEvent _onDamage;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // sets the starting valuse four the pomons to battel
        _attack = _currentMon.Attack;
        _speed = _currentMon.Speed;
        _defense = _currentMon.Defense;

        _currentMon.CurrentHealt = _currentMon.MaxHealt;//----------------------------------------------[ remove this after teasting]------------------------------------------------------
    }

    // methods
    #region

    // returns
    #region

    // returns the base attack damage
    public int ReturnAttack(int attackPicked)
    {
        int totalDamage = _attack + _currentMon.PomonMoves[attackPicked].power;

        // returns the totall amount of damie the pomon does
        return totalDamage;
    }

    public int ReturnSpeed()
    {
        return _speed;
    }
    #endregion

    public int PomonUseMove(int movePicked) 
    {
        int totalDamage = 0;

        if (_currentMon.CurrentHealt > 0 )
        {
            totalDamage = _attack + _currentMon.PomonMoves[movePicked].power;

            _currentMon.PomonMoves[movePicked].Ability(this);
        }

        return totalDamage;
    }


    //make changes ind the helt of the pomon. this can be healing of damage
    public void ChangeHealt(int howToChange)
    {
        _currentMon.CurrentHealt += howToChange;

        if (_currentMon.CurrentHealt > _currentMon.MaxHealt) // makes sure the Pomon does not get more HP then Max
            _currentMon.CurrentHealt = _currentMon.MaxHealt;

        if (_currentMon.CurrentHealt < 0)
            _currentMon.CurrentHealt = 0;

        Debug.Log(howToChange);
        OnHealhtChange?.Invoke(howToChange);
    }


    // damiges the pomons current HP
    public void TakesDamage(int damage)
    {
        int totaldamage = damage - _defense;

        // ind case Defense is higer then damage and then wood result ind the healing
        if (totaldamage < 0)
            totaldamage = 0;

        // changes the pomons current HP diretlig as we want to remember eng damage don to the pomon
        ChangeHealt(-totaldamage);
        //_currentMon.CurrentHealt -= totaldamage;
        Debug.Log($"{_currentMon.PomonName} has taken {totaldamage} and is at {_currentMon.CurrentHealt}/{_currentMon.MaxHealt}");

        if (_currentMon.CurrentHealt <= 0)
            SwitchPomon();
    }

    // is goving to handel swithing ind a new pokemon
    private void SwitchPomon()
    {
        // remove _currentMon here as its just to not get error
        Pomons pomonSwichingTo = _currentMon;

        if (_isPlayerPomon)
        {

        }
        else
        {

        }

        OnPomonSwiche?.Invoke(pomonSwichingTo);

        Debug.Log($"{_currentMon.PomonName} has fainted");
    }

    private Pomons AiPicPomon()
    {

        // remove _currentMon here as its just to not get error
        return _currentMon;
    }
    #endregion
}
