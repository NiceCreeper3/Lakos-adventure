using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// this works as the tamplate to a pomon. keyword is that this is not a pomon. but merly the bluprints to create one
/// </summary>
[CreateAssetMenu(fileName = "Pomon", menuName = "ScriptableObjeckts/Pomon Bluprint")]
public class PomonsBluPrint : ScriptableObject
{
    public new string name;
    public Sprite front;
    public Sprite back;
    public int MinAttack, MaxAttack;

    public int MinHealt, MaxHealt;

    public int MinSpeed, MaxSpeed;

    public int MinDefense, MaxDefense;

    public string description;

    public int genderratio;

    public List<BasikMoves> MovesCanLern = new List<BasikMoves>();
}


