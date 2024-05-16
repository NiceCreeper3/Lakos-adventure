using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwichePomon : MonoBehaviour
{
    [Header("the team of pomon chosen to battel")]
    [SerializeField] protected pomonteam _pomonTeam;
    [SerializeField] private GameObject PicPomonUI;

    protected int _seletedPomon;
    protected bool _isPlayer = true;

    public event Action<Pomons> OnPomonSelket;
    public event Action<Pomons, bool> OnPomonSwiching;
    public event Action OnBattleOver;

    private BattelLingMons onNeededSwiche;

    protected virtual void Awake()
    {
        onNeededSwiche = GetComponent<BattelLingMons>();
        onNeededSwiche.OnPomonSwicheNeeded += OnNeededSwiche_OnPomonSwicheNeeded;
    }

    private void Start()
    {
        FullHealTeam();

        _seletedPomon = 0; // seltes one that does not have Zero HP
        SwitchPomonConfurmt();
    }
    private void OnNeededSwiche_OnPomonSwicheNeeded()
    {
        // turns on the swiche UI
        SwichePickMetthod();
    }

    // Methodes
    #region
    // handels how a new Pomon is beaing swiceh ind. the enemy is goving to inhert this and change it 
    protected virtual void SwichePickMetthod()
    {
        RemoveDeadPomons();

        if (StillHasPomonLeft())
            PicPomonUI.SetActive(true);
        else
            BattleLost();
    }

    void FullHealTeam() //----------------------------------------------[ remove this after teasting]------------------------------------------------------
    {
        // full heales the team. so you don,t have to do it manuly
        foreach (Pomons pomons in _pomonTeam.team)
            pomons.CurrentHealt = pomons.MaxHealt;
    }

    // is goving to handel swithing ind a new pokemon
    public void SwitchPomonConfurmt()
    {
        OnPomonSwiching?.Invoke(_pomonTeam.team[_seletedPomon], _isPlayer);    
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

    protected void BattleLost()
    {
        StartCoroutine(WaitFouraBit());
    }


    protected void BattelWin(List<Pomons> pomonsTeam)
    {
        ushort levelUps = 0;

        // gives the playeres Linkens XP 
        foreach (Pomons pomon in _pomonTeam.team)
        {
            levelUps = pomon.level.GiveXP(100 * pomonsTeam.Count);
            pomon.level.IncreseStates(pomon, levelUps);
        }

        // shows

        // remove this after and have it indsted show all the Pomon that leveled up
        StartCoroutine(WaitFouraBit());
    }

    private IEnumerator WaitFouraBit()
    {
        yield return new WaitForSeconds(1);
        OnBattleOver?.Invoke();

        SceneLoader.ChageScene();
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

    private bool StillHasPomonLeft()
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
    #endregion

}