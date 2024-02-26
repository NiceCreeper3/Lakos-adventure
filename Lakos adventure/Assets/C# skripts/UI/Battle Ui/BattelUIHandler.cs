using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattelUIHandler : MonoBehaviour
{
    //[SerializeField] private Pomons _pomonInUse, enemyPomon;
    [SerializeField] private SwichePomon _onPlayerSwiching;

    [SerializeField] private TMP_Text[] _moves;

    private void Awake()
    {
        _onPlayerSwiching.OnPomonSwiching += _onPlayerSwiching_OnPomonSwiching;
    }

    private void _onPlayerSwiching_OnPomonSwiching(Pomons arg1, bool arg2)
    {
        SetMoveName(arg1);
    }

    private void SetMoveName(Pomons pomonInUse)
    {
        // sets op so eathe moves name is represendit on a button
        for (int i = 0; i <= _moves.Length - 1; i++)
        {
            try
            {
                _moves[i].text = pomonInUse.PomonMoves[i].name;
            }
            catch
            {
                _moves[i].text = "";
            }
        }
    }   
}
