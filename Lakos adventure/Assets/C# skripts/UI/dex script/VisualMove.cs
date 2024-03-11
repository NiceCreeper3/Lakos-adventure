using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VisualMove : MonoBehaviour
{
    [SerializeField] private Moves move;

    [SerializeField] private TMP_Text nametext;
    [SerializeField] private TMP_Text powertext;
    [SerializeField] private TMP_Text disc;
    [SerializeField] private Image typeIMG;



    public void Visulize(Moves newmove)
    {
        move = newmove;

        nametext.text = move.MoveName;
        if (move.power != 0)
        {
            powertext.text = move.power.ToString();
        }
        disc.text = move.MoveDiskrepseon;
        typeIMG.color = move.MoveElement.ElementColor;
    }
}
