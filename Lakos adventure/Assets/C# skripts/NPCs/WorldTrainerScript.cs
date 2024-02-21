using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTrainerScript : MonoBehaviour
{
    [SerializeField] private trainer Trainer;
    [SerializeField] private Transform player;
    [SerializeField] private Vector2 diretion;


    void Update()
    {
        if (Trainer.Seaching)
        {
            RaycastHit2D[] coll = new RaycastHit2D[1];
            GetComponent<Collider2D>().Raycast(diretion, coll);
            foreach (RaycastHit2D col in coll)
            {
                if (col.collider.tag == "Player")
                {
                    
                    triggeractive();
                }
                    
            }
        }
        
    }
    public void triggeractive()
    {

        Trainer.Seaching = false;
        if (!Trainer.defeated)
        {
            MapToBattel.IsTranerBattle = Trainer;
            MapToBattel.enemyPomons = Trainer.trainerTeam;
            SceneLoader.ChageScene("Battle_Scene");
        }
        
    }
}
