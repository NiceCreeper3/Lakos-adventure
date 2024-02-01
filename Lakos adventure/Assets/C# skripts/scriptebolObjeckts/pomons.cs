using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this a cahte pomon. this meanes its one the game wille make.
/// it is goving to use pomons scriptebol objeckt to deafine how its created
/// </summary>

[CreateAssetMenu(fileName = "Pomon", menuName = "ScriptableObjeckts/Pomon")]
public class Pomons : ScriptableObject
{
    // (Inprovement) make this (get, sets)
    // nothing ind here exept CurrentHealt hvil be changed out side of lvling

    // values
    #region

    [Header("Falver info")]
    public string PomonName;
    public PomonsBluPrint Spesies;
    public bool IsDude;

    [Header("States and Moves")]
    public int Attack;

    public int MaxHealt;
    public int CurrentHealt;

    public int Speed;

    public int Defense;

    public List<BasikMoves> PomonMoves = new List<BasikMoves>();

    #endregion
}