using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTrainerScript : MonoBehaviour
{
    [SerializeField] private trainer Trainer;
    [SerializeField] private Transform player;
    private Actorscript actorscript;


    private void Start()
    {
        actorscript.actor = Trainer;
    }
    void Update()
    {
        if (Trainer.Seaching)
        {
            RaycastHit2D[] coll = new RaycastHit2D[1];
            GetComponent<Collider2D>().Raycast(actorscript.diretion, coll);
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

        
        
    }
}
