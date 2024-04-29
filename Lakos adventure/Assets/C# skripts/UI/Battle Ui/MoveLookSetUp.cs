using System.Collections.Generic;
using UnityEngine;

public class MoveLookSetUp : MonoBehaviour
{
    [SerializeField] private GameObject _getMoveAprends;
    [SerializeField] private SwichePomon EventRefends;

    private List<GameObject> _moveAprends;

    private void Awake()
    {
        _moveAprends = new List<GameObject>();

        foreach (Transform Gird in _getMoveAprends.transform)
            _moveAprends.Add(Gird.gameObject);

        // turns all the buttons off to start of with
        SetMoveToDefalt();

        EventRefends.OnPomonSelket += EventRefends_OnPomonSelket;
    }

    private void EventRefends_OnPomonSelket(Pomons pomon)
    {
        TurnOnOrOffMoves(pomon);
    }

    // turns all the buttons off to start of with
    private void SetMoveToDefalt()
    {
        // sets the moves to be off by defalt
        foreach (GameObject move in _moveAprends)
            move.SetActive(false);
    }


    // updates aperends off the button
    private void TurnOnOrOffMoves(Pomons pomon)
    {
        SetMoveToDefalt();

        // Funds fruge all the buttons. and then check if the pomon has a move that can fit onto there.
        // if it can then it turns the button on
        // if not then it turns it off
        for (int i = 0; i < _moveAprends.Count; i++)
        {
            if (pomon.PomonMoves.Count > i)
            {
                // turns the button on and gives it the move its represending. (if eny are awebol. else it turns it off)               
                _moveAprends[i].GetComponent<MoveButtonAperends>().MoveToRepresent = pomon.PomonMoves[i];
                _moveAprends[i].SetActive(true);
            }
            else
            {
                _moveAprends[i].SetActive(false);
            }
        }
    }
}
