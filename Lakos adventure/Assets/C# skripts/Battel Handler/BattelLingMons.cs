using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

using Random = UnityEngine.Random;

public class BattelLingMons : MonoBehaviour
{
    // Values
    #region

    [Header("Checks if swiching pomon needs player logic or AI logic")]
    [SerializeField] private bool _isPlayerMon;

    [Header("Reference to aesthetic stuff")]
    [SerializeField] private GameObject PicPomonUI;
    [SerializeField] private SpriteRenderer pomonImgeDissplay; // mite move after 
    [SerializeField] private AudioAssets _audio;

    // represents the buffes to a state
    [HideInInspector] public int _attackBuff;
    [HideInInspector] private int _speedBuff;
    [HideInInspector] private int _defenseBuff;

    private Pomons _currentMon;

    private SwichePomon OnSwitch;

    // evnets
    public event Action<int> OnHealhtChange;
    public static string PreaviseScene;

    #endregion

    // Start is called before the first frame update
    private void Awake()
    {
        OnSwitch = GetComponent<SwichePomon>();

        // gets a refrends to Pomon swiching
        OnSwitch.OnPomonSwiching += OnSwiche_OnPomonSwiching;
    }

    private void OnSwiche_OnPomonSwiching(Pomons arg1, bool arg2)
    {
        SwitchPomon(arg1);
    }

    // methods
    #region

    public int ReturnSpeed()
    {
        return _currentMon.Speed * _speedBuff;
    }

    public void PomonAttacks(int attackPicked, BattelLingMons attckTarget)
    {
        if (_currentMon.CurrentHealt > 0)
        {
            int rawDamage = 0;

            if (_currentMon.PomonMoves[attackPicked].power != 0) // makes sure buff moves don,t end up doving damige
                rawDamage = _currentMon.PomonMoves[attackPicked].power + _currentMon.Attack;
             
            int totalDamage = rawDamage * _attackBuff;

            Debug.Log($"_______________{_currentMon.PomonName}_______________");
            Debug.Log(
                $"raw damage is {rawDamage} geainde by {_currentMon.PomonMoves[attackPicked].power} + {_currentMon.Attack} \n" +
                $"Total damage is {totalDamage} geainde by {rawDamage} * {_attackBuff}");

            // actevates the Ability after the Damage math as to not give buff damige amidetly
            _currentMon.PomonMoves[attackPicked].Ability(this);

            attckTarget.TakesDamage(totalDamage);
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
        int totaldamage = damage - (_currentMon.Defense * _defenseBuff);

        Debug.Log(
            $"{_currentMon.PomonName} \n" +
            $"damge defended is {totaldamage} given by {_defenseBuff} - {damage}");

        // ind case Defense is higer then damage and then wood result ind the healing
        if (totaldamage < 0)
            totaldamage = 0;

        // changes the pomons current HP diretlig as we want to remember eng damage don to the pomon
        ChangeHealt(-totaldamage);

        if (_currentMon.CurrentHealt <= 0)
        {
            Debug.Log("attevated");
            SwichePomonLogic();

        }
            
    }

    //make changes ind the helt of the pomon. this can be healing of damage
    public void ChangeHealt(int howToChange)
    {

        _currentMon.CurrentHealt += howToChange;
        Debug.Log(howToChange + " " + _currentMon.CurrentHealt);

        // makes sure a pomon does not have more health then MaxHealth
        if (_currentMon.CurrentHealt > _currentMon.MaxHealt) // makes sure the Pomon does not get more HP then Max
            _currentMon.CurrentHealt = _currentMon.MaxHealt;

        // makes sure we don,t hit negetive nummberes of health
        if (_currentMon.CurrentHealt < 0)
            _currentMon.CurrentHealt = 0;

        Debug.Log($"{_currentMon.PomonName} has had its health changed by {howToChange} and is now at {_currentMon.CurrentHealt}/{_currentMon.MaxHealt}");

        OnHealhtChange?.Invoke(howToChange);
    }
    #endregion

    // handels how a new Pomon is beaing swiceh ind. the enemy is goving to inhert this and change it 
    private void SwichePomonLogic()
    {
        
        // gives difrent logic four when a new pomon needs to be swiched ind
        if (_isPlayerMon)
        {
            Debug.Log(" 13141 415 1 4514 1");
            PicPomonUI.SetActive(true);
        }
        else
        {
            Debug.Log(" yyyyyyyyyyyyyyy");
            OnSwitch.AIPickMon();
        }

    }

    // is goving to handel swithing ind a new pokemon
    private void SwitchPomon(Pomons swichingPomons)
    {
        if (_currentMon != null)
            Debug.Log($"swichint {_currentMon.PomonName} out with {swichingPomons.PomonName}");

        SoundManger.Playsound(SoundManger.Sound.OnPomonEnterBattel);

        // sets the new _currentMon Pomon to be the swithed ind one
        _currentMon = swichingPomons;

        // sets the tempeary states of the swinced ind Pomon
        _attackBuff = 1;
        _speedBuff = 1;
        _defenseBuff = 1;

        // insertes the sprite ind its plase. and if its the player mekes sure it is the back sprite 
        if (_isPlayerMon)
            pomonImgeDissplay.sprite = _currentMon.Spesies.back;
        else
            pomonImgeDissplay.sprite = _currentMon.Spesies.front;
    }
    #endregion
}
