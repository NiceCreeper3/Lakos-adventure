using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattelButtonSetUp : MonoBehaviour
{
    [Header("New")]
    [SerializeField] private TurnHandler _turnHandlerRefends;
    [SerializeField] private Transform[] _buttonPositon;

    [Header("Button To Creat")]
    [SerializeField] private GameObject _buttonPrefab;

    [SerializeField] private SwichePomon _onPlayerSwiching;

    private List<GameObject> _buttons;

    private void Awake()
    {
        _buttons = new List<GameObject>();

        // gets a refrends to the swich event
        _onPlayerSwiching.OnPomonSwiching += _onPlayerSwiching_OnPomonSwiching;
    }

    private void _onPlayerSwiching_OnPomonSwiching(Pomons pomon, bool arg2)
    {

        // creates as meany buttons as there are points. only does this if there have not bean created allrede
        if (_buttons.Count <= 0)
            MakeMoves(pomon);

        TurnOnOrOffButtons(pomon);
    }

    private void MakeMoves(Pomons pomon)
    {
        for (int i = 0; i < _buttonPositon.Length; i++)
        {
            // Creates the prefab button
            GameObject button = Instantiate(_buttonPrefab, _buttonPositon[i].position, Quaternion.identity, transform);

            // adds the needed info to be a "to be a button"
            button.GetComponent<CustumButton>().ButtonNummber = i; // ueses i to get what attack the button represents
            button.GetComponent<CustumButton>().TurnHandler = _turnHandlerRefends;

            // adds the button to a list
            _buttons.Add(button);

            // turns the buttons off by defalt. 
            // its also does this so the buttons are updated with the new informason before 
            button.SetActive(false);
        }
    }

    // updates aperends off the button
    private void TurnOnOrOffButtons(Pomons pomon)
    {

        // Funds fruge all the buttons. and then check if the pomon has a move that can fit onto there.
        // if it can then it turns the button on
        // if not then it turns it off
        for (int i = 0; i < _buttons.Count; i++)
        {
            if (pomon.PomonMoves.Count > i)
            {
                // turns the button on and gives it the move its represending. (if eny are awebol. else it turns it off)               
                _buttons[i].GetComponent<MoveButtonAperends>().MoveToRepresent = pomon.PomonMoves[i];
                _buttons[i].SetActive(true);
            }
            else
            {
                _buttons[i].SetActive(false);
            }
        }
    }
}
