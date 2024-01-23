using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// this works as the tamplate to a pomon. keyword is that this is not a pomon. but merly the bluprints to create one
/// </summary>
[CreateAssetMenu(fileName = "Pomon", menuName = "ScriptableObjeckts/Pomon Bluprint")]
public class pomons : ScriptableObject
{
    public int MinAttack, MaxAttack;

    public int MinHealt, MaxHealt;

    public int MinSpeed, MaxSpeed;

    public int MinDefense, MaxDefense; 

    public List<Moves> MovesCanLern = new List<Moves>();
}


