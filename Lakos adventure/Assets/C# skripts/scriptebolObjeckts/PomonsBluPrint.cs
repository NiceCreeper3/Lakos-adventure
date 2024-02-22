using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this works as the tamplate to a pomon. keyword is that this is not a pomon. but merly the bluprints to create one
/// </summary>
[CreateAssetMenu(fileName = "Pomon", menuName = "Pomon/Pomon Bluprint")]
public class PomonsBluPrint : ScriptableObject
{
    [Header("Flaver")]
    public new string name;

    public Sprite front;
    public Sprite back;

    public string description;

    public int genderratio;

    [Header("Genral states")]
    public int MinAttack, MaxAttack, attackgrow;

    public int MinHealt, MaxHealt, healthgrow;

    public int MinSpeed, MaxSpeed, speedgrow;

    public int MinDefense, MaxDefense, Defensegrow;

    public int CaptureChanse;

    public ElementObjecks[] PomonElemet;

    [Header("On Level")]
    public List<BasikMoves> MovesCanLern = new List<BasikMoves>();

    public Pomons generateMon(int level)
    {
        Pomons mon = new Pomons(this);

        return mon;
    }

}


