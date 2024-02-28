using System;
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
        PicPomonUI.SetActive(true);
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
        Debug.Log("attemting to swiche Pomon");

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

        }
    }

    protected void BattleLost()
    {
        SceneLoader.ChageScene();
    }


    protected void BattelWin()
    {
        SceneLoader.ChageScene();
    }
    #endregion

}
