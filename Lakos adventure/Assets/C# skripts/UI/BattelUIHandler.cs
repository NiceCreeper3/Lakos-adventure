using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattelUIHandler : MonoBehaviour
{
    [SerializeField] private Pomons _pomonInUse, enemyPomon;

    [SerializeField] private TMP_Text[] _moves;

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
}
