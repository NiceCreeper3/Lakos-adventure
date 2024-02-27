using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattelUIHandler : MonoBehaviour
{
    //[SerializeField] private Pomons _pomonInUse, enemyPomon;
    [SerializeField] private SwichePomon _onPlayerSwiching;

    [SerializeField] private Button[] _buttonPlate;
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
        for (int i = 0; i <= _buttonPlate.Length - 1; i++)
        {
            try
            {
                _buttonPlate[i].gameObject.SetActive(true);
                // sets color and name of the attacks
                _moves[i].text = pomonInUse.PomonMoves[i].name;
                _buttonPlate[i].GetComponent<Image>().color = pomonInUse.PomonMoves[i].MoveElement.ElementColor;
            }
            catch
            {
                _buttonPlate[i].gameObject.SetActive(false);
                //_moves[i].text = "";
                //_buttonPlate[i].GetComponent<Image>().color = new Color(200, 200, 200);
            }

        }
    }   
}
