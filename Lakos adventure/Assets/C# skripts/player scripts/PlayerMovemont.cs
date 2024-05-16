using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemont : MonoBehaviour
{
    [SerializeField] private Actorscript movepoint;
    [SerializeField] private CircleCollider2D col;
    [SerializeField] private playerinteract interact;
    // Start is called before the first frame update
    void Start()
    {
        movepoint.load();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == (new Vector3(movepoint.movepoint.x, movepoint.movepoint.y) * 0.64f) + new Vector3(0.32f, 0.32f))
        {
            bool isempty = true;
            RaycastHit2D[] hit = new RaycastHit2D[2];
            col.Raycast(new Vector2(0,(int)Input.GetAxis("Vertical")), hit, 0.64f);
            foreach (RaycastHit2D raycastHit in hit)
            {
                if (raycastHit)
                {
                    if (!raycastHit.collider.isTrigger)
                    {
                        isempty = false;
                        break;
                    }
                   
                }
            }
            if (isempty)
            {
                if((int)Input.GetAxis("Vertical") != 0)
                {
                    movepoint.actor.movey((int)Input.GetAxis("Vertical"));
                }
                
            }
            
            


            if (transform.position == (new Vector3(movepoint.movepoint.x, movepoint.movepoint.y) * 0.64f) + new Vector3(0.32f, 0.32f))
            {
                isempty = true;
                col.Raycast(new Vector2((int)Input.GetAxis("Horizontal"), 0), hit, 0.64f);
                foreach (RaycastHit2D raycastHit in hit)
                {
                    if (raycastHit)
                    {
                        if (!raycastHit.collider.isTrigger)
                        {
                            isempty = false;
                            break;
                        }

                    }
                }
                if (isempty)
                {
                    if ((int)Input.GetAxis("Horizontal") != 0)
                    {
                        movepoint.actor.movex((int)Input.GetAxis("Horizontal"));
                    }
                }
                
                
            }
                


        }
    }
}
