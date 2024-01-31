using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class BattelLingMons : MonoBehaviour
{
    // Values
    #region

    [SerializeField] protected Pomons _currentMon;

    [SerializeField] private GameObject PicPomonUI;

    [SerializeField] private SpriteRenderer pomonImgeDissplay;

    // pomon uses this temprary battel valuse to battel
    [HideInInspector] public int _attack;
    [HideInInspector] private int _speed;
    [HideInInspector] private int _defense;

    // evnets
    public event Action<int> OnHealhtChange;
    public event Action<Pomons> OnPomonSwiche;

    [SerializeField] protected Pomons[] TeastArrey; // ______________________________________________{Remove this after teasting}_______________________________________________________________
  

    #endregion

    // Start is called before the first frame update
    private void Start()
    {
        // sets up the Pomon to Fight
        SwitchPomon(_currentMon);
    }

    // methods
    #region

    // returns ________(we myt want to delete this after)__________________
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

        if (_currentMon.CurrentHealt > 0 ) // is problem
        {
            totalDamage = _attack + _currentMon.PomonMoves[movePicked].power;

            _currentMon.PomonMoves[movePicked].Ability(this);
        }

        return totalDamage;
    }

    // health maipulason
    #region
    //make changes ind the helt of the pomon. this can be healing of damage
    public void ChangeHealt(int howToChange)
    {
        _currentMon.CurrentHealt += howToChange;

        // makes sure we a pomon does not have more then MaxHealth
        if (_currentMon.CurrentHealt > _currentMon.MaxHealt) // makes sure the Pomon does not get more HP then Max
            _currentMon.CurrentHealt = _currentMon.MaxHealt;

        // makes sure we don,t hit negetive nummberes of health
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

        Debug.Log($"{_currentMon.PomonName} has taken {totaldamage} and is at {_currentMon.CurrentHealt}/{_currentMon.MaxHealt}");

        if (_currentMon.CurrentHealt <= 0)
            SwichePomonLogic();
    }
    #endregion

    // handels how a new Pomon is beaing swiceh ind. the enemy is goving to inhert this and change it 
    protected virtual void SwichePomonLogic()
    {
        // turnes on the Pomon pic UI. so the player can deside what pomon to swiche to
        PicPomonUI.SetActive(true);
    }

    // SWICHING pomon
    #region
    // the buttons of picing a new Pomon is goving to be here
    public void PlayerHaspiced(int pomonNummber)
    {
        Debug.Log("attemting to swiche Pomon");

        if (TeastArrey[pomonNummber].CurrentHealt > 0)
        {
            //teales the SwitchPomon methond with Pomon we are swiching to. and turns off the Pomon pic UI
            SwitchPomon(TeastArrey[pomonNummber]);
            PicPomonUI.SetActive(false);      
        }
    }

    // is goving to handel swithing ind a new pokemon
    protected void SwitchPomon(Pomons swichingPomons)
    {
        Debug.Log($"swichint {_currentMon.name} out with {swichingPomons.name}");
        // sets the new _currentMon Pomon to be the swithed ind one
        _currentMon = swichingPomons;

        Debug.Log(_currentMon.name);
        // sets the tempeary states of the swinced ind Pomon
        _attack = _currentMon.Attack;                            // is having problems
        _speed = _currentMon.Speed;
        _defense = _currentMon.Defense;

        pomonImgeDissplay.sprite = _currentMon.PomonLook;

        _currentMon.CurrentHealt = _currentMon.MaxHealt;//----------------------------------------------[ remove this after teasting]------------------------------------------------------

        // change sprite her maby?

        // need to be swichingPomons as we mite need to update the Ui
        OnPomonSwiche?.Invoke(swichingPomons);
    }
    #endregion

    #endregion
}
