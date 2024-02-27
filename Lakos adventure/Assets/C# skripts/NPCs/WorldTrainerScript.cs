using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTrainerScript : MonoBehaviour
{
    [SerializeField] private trainer Trainer;
    [SerializeField] private Transform player;
    [SerializeField] private Actorscript actorscript;


    private void Start()
    {
        actorscript.movepoint = actorscript.grid.CellToWorld(actorscript.grid.WorldToCell(transform.position)) + new Vector3(0.31f, 0.31f, 0);
        actorscript.load();
    }
    void Update()
    {
        if (Trainer.Seaching)
        {
            RaycastHit2D[] coll = new RaycastHit2D[1];
            GetComponent<Collider2D>().Raycast(actorscript.diretion, coll);
            if (coll[0])
            {
                foreach (RaycastHit2D col in coll)
                {
                    if (col.collider.tag == "Player")
                    {

                        triggeractive();
                    }

                }
            }
            
        }
        
    }
    public void triggeractive()
    {

        
        
    }
}
