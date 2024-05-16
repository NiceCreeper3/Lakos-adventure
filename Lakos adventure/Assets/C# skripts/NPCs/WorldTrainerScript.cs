using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WorldTrainerScript : MonoBehaviour
{
    [SerializeField] public trainer Trainer;
    [SerializeField] private Transform player;
    [SerializeField] private Actorscript actorscript;
    private void Start()
    {
        actorscript.movepoint = new Vector2Int(actorscript.grid.WorldToCell(transform.position).x, actorscript.grid.WorldToCell(transform.position).y);
        transform.position = new Vector3(actorscript.movepoint.x, actorscript.movepoint.y) * 0.64f;
        Trainer = actorscript.actor as trainer;
        Debug.Log(Trainer.trainerTeam);
        actorscript.load();
        

    }
    void Update()
    {
        if (!player)
        {
            GameObject[] objectsinscene = SceneManager.GetActiveScene().GetRootGameObjects();
            foreach (GameObject game in objectsinscene)
            {
                try
                {
                    player = game.GetComponentInChildren<playerinteract>().transform;
                }
                catch
                {

                }

                if (player)
                {
                    break;
                }
            }
        }
        
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
        Trainer.ineract();
        
    }
}
