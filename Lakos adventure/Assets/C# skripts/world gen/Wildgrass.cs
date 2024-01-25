using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wildgrass : MonoBehaviour
{
    [SerializeField] private UnityEvent ontrigger;
    [SerializeField] int propability;




    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("is in the trigger");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("stay");
        if (collision.tag == "Player")
        {
            
            int instance = Random.Range(1, 100);
            if (propability / 2 > instance)
            {
                ontrigger.Invoke();
            }

        }
    }
}
