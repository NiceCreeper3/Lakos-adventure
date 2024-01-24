using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BattelLingMons : MonoBehaviour
{
    #region
    //public imge PomonImg;

    [SerializeField] private CharhePomons _currentMon;

    // pomon uses this temprary battel valuse to battel
    private int _attack;
    private int _speed;
    private int _defense;


    [SerializeField] private UnityEvent _unityEvent;
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

    // damiges the pomons current HP
    public void TagesDamige(int damige)
    {
        int totaldamige = damige - _defense;

        // ind case Defense is higer then damige and then wood result ind the healing
        if (totaldamige < 0)
            totaldamige = 0;

        // changes the pomons current HP diretlig as we want to save eng damige don to the pomon
        _currentMon.CurrentHealt -= totaldamige;
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
