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
        movepoint.movepoint = movepoint.grid.CellToWorld(InfoSaved.playerlocation) + new Vector3(0.31f, 0.31f, 0);
        movepoint.load();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == movepoint.movepoint)
        {
            bool isempty = true;
            RaycastHit2D[] hit = new RaycastHit2D[2];
            col.Raycast(new Vector2(0,(int)Input.GetAxis("Vertical")), hit, 0.63f);
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
                movepoint.actor.movey((int)Input.GetAxis("Vertical"));
            }
            


            if (transform.position == movepoint.movepoint)
            {
                isempty = true;
                col.Raycast(new Vector2((int)Input.GetAxis("Horizontal"), 0), hit, 0.63f);
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
                    movepoint.actor.movex((int)Input.GetAxis("Horizontal"));
                }
                
                
            }
                


        }
    }
}
