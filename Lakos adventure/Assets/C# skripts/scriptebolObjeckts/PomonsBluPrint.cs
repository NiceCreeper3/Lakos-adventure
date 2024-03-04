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

    [Range(0,100)] public int genderratio;

    [Header("Genral states")]

    public int MinAttack;

    public int MaxAttack, attackgrow;

    public int MinHealt, MaxHealt, healthgrow;

    public int MinSpeed, MaxSpeed, speedgrow;

    public int MinDefense, MaxDefense, Defensegrow;

    public int CaptureChanse;

    public ElementObjecks[] PomonElemet;

    [Header("On Level")]
    public List<BasikMoves> MovesCanLern = new List<BasikMoves>();

    public Pomons generateMon(int level)
    {
        Pomons mon = CreateInstance<Pomons>();
        Debug.Log(name + " generated");
        mon.name = name + level;
        mon.Spesies = this;
        mon.PomonName = name;
        Debug.Log("mon named ");
        mon.IsDude = true;
        if (Random.Range(0,100) < genderratio)
        {
            mon.IsDude = false;
        }
        Debug.Log("mon genderd");
        mon.Attack = Random.Range(MinAttack, MaxAttack+1) + (attackgrow * (level - 1));
        mon.Defense = Random.Range(MinDefense, MaxDefense+1) + (Defensegrow * (level - 1));
        mon.MaxHealt = Random.Range(MinHealt, MaxHealt+1) + (healthgrow * (level-1));
        mon.MaxHealt = Random.Range(MinSpeed, MaxSpeed+1) + (speedgrow * (level - 1));
        Debug.Log("stats given");
        mon.CurrentHealt = mon.MaxHealt;
        Debug.Log("health maxed");
        for (int i = 0; i < 4; i++)
        {
            int rand = Random.Range(0, MovesCanLern.Count);
            Debug.Log(rand);
            Debug.Log(MovesCanLern[rand].name);
            mon.PomonMoves.Add(MovesCanLern[rand]);
            
        }


        return mon;
    }

}


