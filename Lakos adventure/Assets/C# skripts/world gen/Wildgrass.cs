using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Wildgrass : MonoBehaviour
{
    [SerializeField] private UnityEvent ontrigger;
    [SerializeField] private Collider2D player;
    [SerializeField] int propability;
    [SerializeField] public int minlevel, maxlevel;
    [SerializeField] public pomonlist posiblemons;



    private void FixedUpdate()
    {
        if (!player)
        {
            GameObject[] objectsinscene = SceneManager.GetActiveScene().GetRootGameObjects();
            foreach (GameObject game in objectsinscene)
            {
                try
                {
                    player = game.GetComponentInChildren<playerinteract>().GetComponent<Collider2D>();
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
        else
        {
            Collider2D[] coll = new Collider2D[1];
            GetComponent<Collider2D>().OverlapCollider(new ContactFilter2D(), coll);
            foreach (Collider2D col in coll)
            {
                if (col == player)
                {
                    int instance = Random.Range(1, 100);
                    if (propability > instance)
                    {
                        ontrigger.Invoke();
                    }
                }

            }
        }
        
    }



}   


    
