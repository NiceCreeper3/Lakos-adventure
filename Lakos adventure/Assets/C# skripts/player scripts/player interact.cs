using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerinteract : MonoBehaviour
{
    public Actorscript direction;
    [SerializeField] private CircleCollider2D col;


    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit2D[] hit = new RaycastHit2D[1];
            col.Raycast(direction.diretion, hit, 0.63f);
            interactreciver ireciver;
            if (hit[0])
            {
                if (hit[0].transform.TryGetComponent<interactreciver>(out ireciver))
                {
                    hit[0].transform.GetComponent<interactreciver>().Trigger();
                }
            }
            
            
        }
    }
}
