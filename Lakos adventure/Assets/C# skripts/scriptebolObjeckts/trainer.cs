using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new trainer", menuName = "person/trainer")]
public class trainer : ScriptableObject
{
    [Header("visuals")]
    public Sprite battlesprite;
    public Texture2D sprite;

    [Header("details")]
    public bool Seaching;
    public bool defeated;

    public pomonteam trainerTeam;

}
