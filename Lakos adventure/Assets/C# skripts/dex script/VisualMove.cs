using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VisualMove : MonoBehaviour
{
    [SerializeField] private BasikMoves move;

    [SerializeField] private TMP_Text nametext;
    [SerializeField] private TMP_Text powertext;

    
    public void Visulize(BasikMoves newmove)
    {
        move = newmove;

        nametext.text = move.MoveName;
        if (move.power != 0)
        {
            powertext.text = move.power.ToString();
        }
    }
}
