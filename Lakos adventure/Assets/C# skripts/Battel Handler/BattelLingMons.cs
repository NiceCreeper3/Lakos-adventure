using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BattelLingMons : MonoBehaviour
{
    #region
    //public imge PomonImg;

    [SerializeField] private Pomons _currentMon;

    // pomon uses this temprary battel valuse to battel
    public int _attack;
    private int _speed;
    private int _defense;

    [SerializeField] private IntEvent _onDamige;
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

    // returns the base attack damige
    public int ReturnAttack(int AttackPiked)
    {
        int totallDamige = _attack + _currentMon.PomonMoves[AttackPiked].power;

        // returns the totall amount of damie the pomon does
        return totallDamige;
    }

    public int ReturnSpeed()
    {
        return _speed;
    }
    #endregion

    public int PomonUseMove(int MovePiked) 
    {
        int totallDamige = 0;

        if (_currentMon.CurrentHealt > 0 )
        {
            totallDamige = _attack + _currentMon.PomonMoves[MovePiked].power;

            _currentMon.PomonMoves[MovePiked].Abilety(this);
        }

        return totallDamige;
    }


    //make changes ind the helt of the pomon. this can be healing of damige
    public void ChangeHealt(int howToChange)
    {
        _currentMon.CurrentHealt += howToChange;
        if (_currentMon.CurrentHealt > _currentMon.MaxHealt) // makes sure the Pomon does not get more HP then Max
            _currentMon.CurrentHealt = _currentMon.MaxHealt;

        _onDamige.Raise(_currentMon.CurrentHealt);
    }


    // damiges the pomons current HP
    public void TagesDamige(int damige)
    {
        int totaldamige = damige - _defense;

        // ind case Defense is higer then damige and then wood result ind the healing
        if (totaldamige < 0)
            totaldamige = 0;

        // changes the pomons current HP diretlig as we want to reamber eng damige don to the pomon
        ChangeHealt(-totaldamige);
        //_currentMon.CurrentHealt -= totaldamige;
        Debug.Log($"{_currentMon.PomonName} has takken {totaldamige} and is at {_currentMon.CurrentHealt}/{_currentMon.MaxHealt}");

        if (_currentMon.CurrentHealt <= 0)
            SwichePomon();
    }

    // is goving to handel swithing ind a new pokemon
    private void SwichePomon()
    {


        Debug.Log($"{_currentMon.PomonName} has fainted");
    }
    #endregion
}
