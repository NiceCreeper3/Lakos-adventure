using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerinteract : MonoBehaviour
{
    public Vector2 direction;
    [SerializeField] private CircleCollider2D col;


    // Update is called once per frame
    void Update()
    {
        Vector2 directions = direction;
        if (Input.GetAxis("Vertical") != 0)
        {
            directions = new Vector2(0, (int)Input.GetAxis("Vertical"));
        }
        else if ((int)Input.GetAxis("Horizontal") != 0)
        {
            directions = new Vector2((int)Input.GetAxis("Horizontal"), 0);
        }

        if(((int)Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && directions != new Vector2(0,0))
        {
            direction = directions;
        }
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit2D[] hit = new RaycastHit2D[1];
            col.Raycast(direction, hit, 3.52f);
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
