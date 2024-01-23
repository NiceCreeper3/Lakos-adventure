using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemont : MonoBehaviour
{
    private Vector3 movepoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == movepoint)
        {
                
                movepoint += new Vector3(0, 3.52f* (int)Input.GetAxis("Vertical"), 0);

            if (transform.position == movepoint)
            {
                movepoint += new Vector3(3.52f * (int)Input.GetAxis("Horizontal"), 0, 0);
            }
                


        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, movepoint, 10 * Time.deltaTime);
        }
    }
}
