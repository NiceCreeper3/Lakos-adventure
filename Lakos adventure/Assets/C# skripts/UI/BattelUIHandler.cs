using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattelUIHandler : MonoBehaviour
{
    [SerializeField] private Pomons _pomonInUse;
    [SerializeField] private TMP_Text[] _moves;
    //[SerializeField] private List<TMP_Text> _moves = new List<TMP_Text>();

    //[SerializeField] TextMeshPro _move0, _move1, _move2, _move3;

    private void Start()
    {
        SetMoveName();
    }

    private void SetMoveName()
    {
        for (int i = 0; i <= _moves.Length - 1; i++)
        {
            try
            {
                _moves[i].text = _pomonInUse.PomonMoves[i].name;
            }
            catch
            {
                _moves[i].text = "";
            }
            Debug.Log(i);
        }
    }

    public void SetPomonHp(int HPToSet)
    {

    }

}
