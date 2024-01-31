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
    [SerializeField] private SpriteRenderer pomonImgeDissplay;

    [Header("the team of pomon chosen to battel")]
    [SerializeField] protected Pomons[] PomonTeam;

    // pomon uses this temprary battel valuse to battel
    protected Pomons _currentMon;
    [HideInInspector] public int _attack;
    [HideInInspector] private int _speed;
    [HideInInspector] private int _defense;

    // evnets
    public event Action<int> OnHealhtChange;
    public event Action<Pomons> OnPomonSwiche;

    #endregion

    // Start is called before the first frame update
    private void Start()
    {
        FullHealTeam();

        // sets up the Pomon to Fight
        SwitchPomon(PomonTeam[0]); // ________________________(out side of teasting indklude a way to check the Pomon does not have 0 HP)__________________________
    }

    
    void FullHealTeam() //----------------------------------------------[ remove this after teasting]------------------------------------------------------
    {
        // full heales the team. so you don,t have to do it manuly
        foreach (Pomons pomons in PomonTeam)
        {
            pomons.CurrentHealt = pomons.MaxHealt;
        }
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

    public void PomonAttacks(ushort attackPicked, BattelLingMons attckTarget)
    {
        if (_currentMon.CurrentHealt > 0)
        {
            // the math of the chosen attack
            int damageMultiPlajer = _currentMon.Attack + _attack;
            int totalDamage = _currentMon.PomonMoves[attackPicked].power * damageMultiPlajer;

            // actevates the Ability after the Damage math as to not give buff damige amidetly
            _currentMon.PomonMoves[attackPicked].Ability(this);

            attckTarget.TakesDamage(totalDamage);
        }
        else
        {
            Debug.Log("you dumb boy? this Pomon has fainted");
        }
    }


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

        OnHealhtChange?.Invoke(howToChange);
    }
    #endregion

    // handels how a new Pomon is beaing swiceh ind. the enemy is goving to inhert this and change it 
    protected virtual void SwichePomonLogic()
    {
        // gives difrent logic four when a new pomon needs to be swiched ind
        if (_isPlayerMon)
        {
            PicPomonUI.SetActive(true);
        }
        else
        {
            foreach (Pomons pomon in PomonTeam)
            {
                if (pomon.CurrentHealt > 0)
                {
                    SwitchPomon(pomon);
                    break;
                }
            }
        }

    }

    // SWICHING pomon
    #region
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
    }

    // is goving to handel swithing ind a new pokemon
    protected void SwitchPomon(Pomons swichingPomons)
    {
        Debug.Log($"swichint {_currentMon.PomonName} out with {swichingPomons.PomonName}");
        // sets the new _currentMon Pomon to be the swithed ind one
        _currentMon = swichingPomons;

        // sets the tempeary states of the swinced ind Pomon
        _attack = _currentMon.Attack;
        _speed = _currentMon.Speed;
        _defense = _currentMon.Defense;

        pomonImgeDissplay.sprite = _currentMon.PomonLook;

        // change sprite her maby?

        // need to be swichingPomons as we mite need to update the Ui
        OnPomonSwiche?.Invoke(swichingPomons);
    }
    #endregion

    #endregion
}
