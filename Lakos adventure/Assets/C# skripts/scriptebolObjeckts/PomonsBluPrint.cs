using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this works as the tamplate to a pomon. keyword is that this is not a pomon. but merly the bluprints to create one
/// </summary>
[CreateAssetMenu(fileName = "Pomon", menuName = "Pomon/Pomon Bluprint")]
public class PomonsBluPrint : ScriptableObject
{
    [System.Serializable]
    public struct Statgrow
    {
        public short HealtUp;
        public short AttackUp;
        public short DefendesUp;
        public short SpeedUp;

        public Moves NewAttack;
    }

    // Flaver
    #region
    [Header("Flaver")]
    public new string name;

    public Sprite front;
    public Sprite back;

    public string description;

    [Range(0, 100)] public int genderratio;

    public Animasons BackAniasonAT;
    public Animasons FrontAnimasonAT;
    #endregion

    // Statess
    #region
    [Header("Genral states")]

    [Header("Healt")]
    public int MinHealt;
    public int MaxHealt, healthgrow;

    [Header("Attack")]
    public int MinAttack;
    public int MaxAttack, attackgrow;

    [Header("Speed")]
    public int MinSpeed;
    public int MaxSpeed, speedgrow;

    [Header("Defense")]
    public int MinDefense;
    public int MaxDefense, Defensegrow;
    #endregion

    [Space(10)]
    public int CaptureChanse;

    public ElementObjecks[] PomonElemet;

    [Header("On Level")]
    public List<Moves> MovesCanLern = new List<Moves>();
    public Statgrow[] StatesGrows;

    public Pomons generateMon(int level)
    {
        
        Pomons mon = CreateInstance<Pomons>();

        // creates a levelsystem and linkes it to the Linkens
        LevelSystem levelSystem = new LevelSystem((ushort)level);
        mon.level = levelSystem;

        mon.name = name + level;
        mon.Spesies = this;
        mon.PomonName = name;
        if (RollUtilatyes.Chanse(genderratio))
        {
            mon.IsDude = false;
        }
        else
        {
            mon.IsDude = true;
        }
        /*
        mon.Attack = Random.Range(MinAttack, MaxAttack+1) + (attackgrow * (level - 1));
        mon.Defense = Random.Range(MinDefense, MaxDefense+1) + (Defensegrow * (level - 1));
        mon.MaxHealt = Random.Range(MinHealt, MaxHealt+1) + (healthgrow * (level-1));
        mon.Speed = Random.Range(MinSpeed, MaxSpeed+1) + (speedgrow * (level - 1));
        mon.CurrentHealt = mon.MaxHealt;*/



        mon.MaxHealt = Random.Range(MinHealt, MaxHealt);
        mon.Attack = Random.Range(MinAttack, MaxAttack);
        mon.Defense = Random.Range(MinDefense, MaxDefense);
        mon.Speed = Random.Range(MinSpeed, MaxSpeed);

        levelSystem.IncreseStates(mon, level);

        for (int i = 0; i < 4; i++)
        {
            int rand = Random.Range(0, MovesCanLern.Count);
            mon.PomonMoves.Add(MovesCanLern[rand]);

        }
        Debug.Log(name + " generated at level:" + mon.level);
        Debug.Log($"attack:{mon.Attack} defense:{mon.Defense} speed:{mon.Speed} health:{mon.MaxHealt}");

        return mon;
    }
}