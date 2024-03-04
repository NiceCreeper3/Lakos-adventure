using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

using Random = UnityEngine.Random;

public class BattelLingMons : MonoBehaviour
{
    public enum buffs
    {
        AttackBuff,
        SpeedBuff,
        DefenseBuff       
    }

    // Values
    #region

    [Header("Checks if swiching pomon needs player logic or AI logic")]
    [SerializeField] private bool _isPlayerMon;

    [Header("Reference to aesthetic stuff")]
    [SerializeField] private SpriteRenderer pomonImgeDissplay; // mite move after 

    private Pomons _currentMon;
    private SwichePomon OnSwitch;

    // represents buffs
    private DamageMath.StatsBuff _buffs;

    // evnets
    public event Action<int> OnHealhtChange;
    public event Action OnPomonSwicheNeeded;

    #endregion

    // Start is called before the first frame update
    private void Awake()
    {
        // gets refrends to swichePomon
        OnSwitch = GetComponent<SwichePomon>();

        // gets a refrends to Pomon swiching
        OnSwitch.OnPomonSwiching += OnSwiche_OnPomonSwiching;
    }

    private void OnSwiche_OnPomonSwiching(Pomons arg1, bool arg2)
    {
        SwitchPomon(arg1, arg2);
    }

    // methods
    #region

    public int ReturnSpeed()
    {
        return (int)(_currentMon.Speed * _buffs.SpeedBuff);
    }

    // triggeres chosen attacks BeforeAblity
    public void BeforeBattle(int attackPicked)
    {
        _currentMon.PomonMoves[attackPicked].AbilityBefore(this);
    }

    // adds stats "stabs". aka buffs
    public void StatesBuff(int buffTimes, buffs whatToBuff)
    {
        // the max amount of times we can buff
        short maxBuffTimes = 6;

        // is kurrent amout stuff gets buffed
        double buffAmount = 0.5;

        // determens how meany times a abilty buffs
        for (int i = 0; i < buffTimes; i++)
        {
            switch (whatToBuff)
            {
                case buffs.AttackBuff:
                    _buffs.AttackBuff += buffAmount;
                    break;

                case buffs.SpeedBuff:
                    _buffs.SpeedBuff += buffAmount;
                    break;

                case buffs.DefenseBuff:
                    _buffs.DefenseBuff += buffAmount;
                    break;
            }
        }

        // make it beater latter
        // adds a buff cap. so you can only have buffed [maxBuffTimes]. the + 2 is to acount four the buff starting at 1
        if ((maxBuffTimes + 2) * buffAmount < _buffs.AttackBuff)
            _buffs.AttackBuff = buffAmount * 8;
        if ((maxBuffTimes + 2) * buffAmount < _buffs.SpeedBuff)
            _buffs.SpeedBuff = buffAmount * 8;
        if ((maxBuffTimes + 2) * buffAmount < _buffs.DefenseBuff)
            _buffs.DefenseBuff = buffAmount * 8;
    }

    // calkulates damige and and  sends it to the (attckTarget)
    public void PomonAttacks(int attackPicked, BattelLingMons attckTarget)
    {
        // checkes if the Pomon is stil alive 
        if (_currentMon.CurrentHealt > 0)
        {
            // makes a short refrens to the Move
            BasikMoves move = _currentMon.PomonMoves[attackPicked];

            int Damage = DamageMath.AttackMath(move, _currentMon, attckTarget, _buffs);

            // actevates the Ability after the Damage math as to not give buff damige amidetly
            move.AbilityAfter(this);

            attckTarget.TakesDamage(Damage);
        }
        else
        {
            Debug.Log("you dumb boy? this Pomon has fainted");
        }
    }

    // health maipulason
    #region

    // damiges the pomons current HP
    private void TakesDamage(int damage)
    {
        
        // aclkulates kow muthe damage is dealt
        int totaldamage = damage - (int)(_currentMon.Defense * _buffs.DefenseBuff);

        Debug.Log(
            $"{_currentMon.PomonName} \n" +
            $"damge defended is {totaldamage} given by {_buffs.DefenseBuff} - {damage}");

        // ind case Defense is higer then damage and then wood result ind healing
        if (totaldamage < 0)
            totaldamage = 0;

        // changes the pomons current HP diretlig as we want to remember eng damage don to the pomon
        ChangeHealt(-totaldamage);
    }

    //make changes ind the helt of the pomon. this can be healing or damage
    public void ChangeHealt(int howToChange)
    {
        _currentMon.CurrentHealt += howToChange;
        Debug.Log(howToChange + " " + _currentMon.CurrentHealt);

        // makes sure a pomon does not have more health then MaxHealth
        if (_currentMon.CurrentHealt > _currentMon.MaxHealt) // makes sure the Pomon does not get more HP then Max
            _currentMon.CurrentHealt = _currentMon.MaxHealt;

        Debug.Log($"{_currentMon.PomonName} has had its health changed by {howToChange} and is now at {_currentMon.CurrentHealt}/{_currentMon.MaxHealt}");

        OnHealhtChange?.Invoke(howToChange);

        // checks if the pomon has negetive healt. if so then its considered dead.
        // and its hp is put to 0 as it is nicer to look at
        if (_currentMon.CurrentHealt <= 0)
        {
            _currentMon.CurrentHealt = 0;
            TurnHandler.FreeAction = true;
            OnPomonSwicheNeeded?.Invoke();
        }
    }
    #endregion


    // is goving to handel swithing ind a new pokemon
    private void SwitchPomon(Pomons swichingPomons, bool isPlayerMon)
    {
        if (_currentMon != null)
            Debug.Log($"swichint {_currentMon.PomonName} out with {swichingPomons.PomonName}");

        SoundManger.Playsound(SoundManger.Sound.OnPomonEnterBattel);

        // sets the new _currentMon Pomon to be the swithed ind one
        _currentMon = swichingPomons;

        // sets buff amount
        _buffs = new DamageMath.StatsBuff(1,1,1);

        // insertes the sprite ind its plase. and if its the player mekes sure it is the back sprite 
        if (isPlayerMon)
            pomonImgeDissplay.sprite = _currentMon.Spesies.back;
        else
            pomonImgeDissplay.sprite = _currentMon.Spesies.front;
    }
    #endregion
}
