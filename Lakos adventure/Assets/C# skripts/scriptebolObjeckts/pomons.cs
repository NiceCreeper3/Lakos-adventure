using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this a cahte pomon. this meanes its one the game wille make.
/// it is goving to use pomons scriptebol objeckt to deafine how its created
/// </summary>

[CreateAssetMenu(fileName = "Pomon", menuName = "Pomon/Pomon")]
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

    [Space(10)]

    public LevelSystem Level;

    [Header("States and Moves")]

    [Header("Healt")]
    public int MaxHealt;
    [HideInInspector] public int CurrentHealt;

    [Header("Attack")]
    public int Attack;

    [Header("Speed")]
    public int Speed;

    [Header("Defense")]
    public int Defense;

    [Space(10)]

    public List<Moves> PomonMoves = new List<Moves>();

    #endregion

    public override string ToString()
    {
        string movesString = "[";

        foreach (Moves move in PomonMoves)
            movesString += $"{move.MoveName},";

        movesString += "]";

        Debug.Log($"Name:{PomonName}");
        Debug.Log($"Name:{Spesies}");
        Debug.Log($"Name:{IsDude}");
        Debug.Log($"Name:{Level.GetLevelNumber()}");
        Debug.Log($"Name:{MaxHealt}");
        Debug.Log($"Name:{CurrentHealt}");
        Debug.Log($"Name:{Attack}");
        Debug.Log($"Name:{Speed}");
        Debug.Log($"Name:{Defense}");
        Debug.Log($"Name:{movesString}");


        return $"Name:{PomonName}, Spsises:{Spesies}, is a dude:{IsDude}, Level{Level.GetLevelNumber()}, HP:{MaxHealt}/{CurrentHealt}, Attack:{Attack}, Speed:{Speed}, Defends{Defense}";
        //return $"{PomonName}, {Spesies}, {IsDude}, {Level.GetLevelNumber()}, {MaxHealt}, {CurrentHealt}, {Attack}, {Speed}, {Defense}";
    }
}