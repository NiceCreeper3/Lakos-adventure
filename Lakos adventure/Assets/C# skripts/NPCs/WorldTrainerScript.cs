using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTrainerScript : MonoBehaviour
{
    [SerializeField] bool issearching = true;
    [SerializeField]Vector2 diretion;
    [SerializeField] Pomons[] team;


    void Update()
    {
        if (issearching)
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
        issearching = false;
        Debug.Log("trainer active");
    }
}
