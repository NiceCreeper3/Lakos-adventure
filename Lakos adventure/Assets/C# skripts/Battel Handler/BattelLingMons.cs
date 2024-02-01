using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class BattelLingMons : MonoBehaviour
{
    // Values
    #region

    [Header("Checkes if swiching pomon needs player logic of AI logic")]
    [SerializeField] private bool _isPlayerMon;

    [Header("refrense to astetik stuff")]
    [SerializeField] private GameObject PicPomonUI;
    [SerializeField] private SpriteRenderer pomonImgeDissplay; // mite move after 

    [Header("the team of pomon chosen to battel")]
    //[SerializeField] private Pomons[] PomonTeam;

    [SerializeField] private Pomons _currentMon;

    // represents the buffes to a state
    [HideInInspector] public int _attack;
    [HideInInspector] private int _speed;
    [HideInInspector] private int _defense;

    // evnets
    public event Action<int> OnHealhtChange;
    public event Action<Pomons> OnPomonSwiche;

    private SwichePomon OnSwiche;


    #endregion

    // Start is called before the first frame update
    private void Awake()
    {
        OnSwiche = GetComponent<SwichePomon>();

        // gets a refrends to Pomon swiching
        OnSwiche.OnPomonSwiching += OnSwiche_OnPomonSwiching;

        //SwitchPomon(_currentMon); // ________________________(out side of teasting indklude a way to check the Pomon does not have 0 HP)__________________________
    }

    private void OnSwiche_OnPomonSwiching(Pomons arg1, bool arg2)
    {
        SwitchPomon(arg1);
    }



    // methods
    #region

    public int ReturnSpeed()
    {
        return _currentMon.Speed * _speed;
    }

    public void PomonAttacks(int attackPicked, BattelLingMons attckTarget)
    {
        if (_currentMon.CurrentHealt > 0)
        {
            // the math of the chosen attack
            int damageMultiPlajer = _currentMon.Attack + _attack;
            int totalDamage = _currentMon.PomonMoves[attackPicked].power * damageMultiPlajer; // its a times to makes it so a 0power move does not do damage

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
    public void TakesDamage(int damage)
    {
        // aclkulates kow muthe damage is dealt
        int totaldamage = 2 * _defense - damage;

        // ind case Defense is higer then damage and then wood result ind the healing
        if (totaldamage < 0)
            totaldamage = 0;

        // changes the pomons current HP diretlig as we want to remember eng damage don to the pomon
        ChangeHealt(-totaldamage);

        if (_currentMon.CurrentHealt <= 0)
            SwichePomonLogic();
    }

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
            PicPomonUI.SetActive(true);
        }
        else
        {
            OnSwiche.AIPickMon();
        }

    }
    // SWICHING pomon
    #region
    /*
        // the buttons of picing a new Pomon is goving to be here
        public void PlayerHaspicked(int pomonNummber)
        {
            Debug.Log("attemting to swiche Pomon");

            if (PomonTeam[pomonNummber].CurrentHealt > 0)
            {
                //teales the SwitchPomon methond with Pomon we are swiching to. and turns off the Pomon pic UI
                SwitchPomon(PomonTeam[pomonNummber]);
                PicPomonUI.SetActive(false);      
            }
        }*/

    // is goving to handel swithing ind a new pokemon
    protected void SwitchPomon(Pomons swichingPomons)
    {
        Debug.Log($"swichint {_currentMon.PomonName} out with {swichingPomons.PomonName}");
        // sets the new _currentMon Pomon to be the swithed ind one
        _currentMon = swichingPomons;

        // sets the tempeary states of the swinced ind Pomon
        _attack = 1;
        _speed = 1;
        _defense = 1;

        if (_isPlayerMon)
            pomonImgeDissplay.sprite = _currentMon.Spesies.back;
        else
            pomonImgeDissplay.sprite = _currentMon.Spesies.front;


        // change sprite her maby?

        // need to be swichingPomons as we mite need to update the Ui
        //OnPomonSwiche?.Invoke(swichingPomons);
    }
    #endregion

    #endregion
}
