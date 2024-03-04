using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

[CreateAssetMenu(fileName = "new trainer", menuName = "person/trainer")]
public class trainer : Actor
{
    
    

    [Header("Traine specific")]
    public Sprite battlesprite;
    public bool Seaching;
    public bool defeated;

    public pomonteam trainerTeam;

    public AnimatorController interaction;

    public void attack()
    {
        Seaching = false;
        if (!defeated)
        {
            MapToBattel.IsTranerBattle = this;
            MapToBattel.enemyPomons = trainerTeam;
            Textinteractor.changeanim(interaction);
        }
    }

}
