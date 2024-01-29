using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class Wildgrass : MonoBehaviour
{
    [SerializeField] private UnityEvent ontrigger;
    [SerializeField] private Collider2D player;
    [SerializeField] int propability;



    private void FixedUpdate()
    {
        Collider2D[] coll = new Collider2D[1];
        GetComponent<TilemapCollider2D>().OverlapCollider(new ContactFilter2D(),coll);
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


    
