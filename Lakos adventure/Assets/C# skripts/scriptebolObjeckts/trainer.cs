using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new trainer", menuName = "person/trainer")]
public class trainer : Actor
{
    
    

    [Header("Traine specific")]
    public Sprite battlesprite;
    public bool Seaching;
    public bool defeated;

    public pomonteam trainerTeam;

    

    public void attack()
    {
        Seaching = false;
        if (!defeated)
        {
            SceneLoader.Battle(this);
        }
    }

}
