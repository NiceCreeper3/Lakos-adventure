using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this a cahte pomon. this meanes its one the game wille make.
/// it is goving to use pomons scriptebol objeckt to deafine how its created
/// </summary>

[CreateAssetMenu(fileName = "Pomon", menuName = "ScriptableObjeckts/Pomon")]
public class CharhePomons : ScriptableObject
{
    // (Inprovement) make this (get, sets)

    // values
    #region
    //public imge PomonImg;
    public string PomonName;

    public int Attack;

    public int MaxHealt;
    public int CurrentHealt;

    public int Speed;

    public int Defense;

    public List<Moves> PomonMoves = new List<Moves>();

    #endregion
}

