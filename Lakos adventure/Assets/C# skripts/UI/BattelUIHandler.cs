using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattelUIHandler : MonoBehaviour
{
    [SerializeField] private Pomons _pomonInUse;
    [SerializeField] private TMP_Text[] _moves;

    [SerializeField] private Slider _healhtSlider;
    //[SerializeField] private List<TMP_Text> _moves = new List<TMP_Text>();

    //[SerializeField] TextMeshPro _move0, _move1, _move2, _move3;

    private void Start()
    {
        SetMoveName();

        _healhtSlider.maxValue = _pomonInUse.MaxHealt;
        _healhtSlider.value = _pomonInUse.CurrentHealt;
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
        _healhtSlider.value -= HPToSet;
    }

}
