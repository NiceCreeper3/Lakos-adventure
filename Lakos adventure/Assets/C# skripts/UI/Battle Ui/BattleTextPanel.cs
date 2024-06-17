using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleTextPanel : MonoBehaviour
{
    [SerializeField] private GameObject _textPanel;
    [SerializeField] private TMP_Text _text;

    [SerializeField] private BattelLingMons[] _eventRefendsLinkenMove;

    private Queue<string> _textOrder;
    private bool panelIsActive;
    private bool closeOnNextClick;


    private void Awake()
    {
        _textOrder = new Queue<string>();

        closeOnNextClick = false;
        panelIsActive = false;
        _textPanel.SetActive(false);

        foreach (BattelLingMons mons in _eventRefendsLinkenMove)
            mons.OnLineknMove += Mons_OnLineknMove;
    }
    private void Mons_OnLineknMove(string text)
    {
        _textOrder.Enqueue(text);

        TextLogic();
    }

    private void LateUpdate()
    {
        if (Input.anyKeyDown && panelIsActive)
        {
            TextLogic();

            if (closeOnNextClick)
            {
                closeOnNextClick = false;
                ClosePanle();
            }
            else
            {
                showText();
            }
        }
    }

    private void TextLogic()
    {

        if (!panelIsActive)
        {
            _textPanel.SetActive(true);

            showText();

            panelIsActive = true;
        }
        else if (_textOrder.Count <= 0)
        {
            closeOnNextClick = true;
        }
    }

    private void ClosePanle()
    {
        panelIsActive = false;
        _textPanel.SetActive(false);
    }

    private void showText()
    {
        string text = _textOrder.Dequeue();
        _text.text = text;
    }


}
