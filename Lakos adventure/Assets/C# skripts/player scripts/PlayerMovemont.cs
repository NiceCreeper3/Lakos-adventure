using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemont : MonoBehaviour
{
    [SerializeField] private Vector3 movepoint;
    [SerializeField] private Grid grid;
    [SerializeField] private CircleCollider2D col;
    [SerializeField] private playerinteract interact;
    // Start is called before the first frame update
    void Start()
    {
        movepoint = grid.CellToWorld(grid.WorldToCell(transform.position)) + new Vector3(1.76f, 1.76f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == movepoint)
        {
            RaycastHit2D[] hit = new RaycastHit2D[1];
            col.Raycast(new Vector2(0,(int)Input.GetAxis("Vertical")), hit, 3.52f);
            if (!hit[0])
            {
                
                movepoint += new Vector3(0, 3.52f * (int)Input.GetAxis("Vertical"), 0);
            }
            else
            {
                foreach (RaycastHit2D hit2D in hit)
                {
                    if (hit2D.collider.isTrigger)
                    {
                        movepoint += new Vector3(0, 3.52f * (int)Input.GetAxis("Vertical"), 0);
                        break;
                    }
                }
            }
            
            
            if (transform.position == movepoint)
            {
                col.Raycast(new Vector2((int)Input.GetAxis("Horizontal"), 0), hit, 3.52f);
                if (!hit[0])
                {

                    movepoint += new Vector3(3.52f * (int)Input.GetAxis("Horizontal"), 0, 0);
                }
                else
                {
                    foreach (RaycastHit2D hit2D in hit)
                    {
                        if (hit2D.collider.isTrigger)
                        {
                            
                            movepoint += new Vector3(3.52f * (int)Input.GetAxis("Horizontal"), 0, 0);
                        }
                    }
                }
                
                
            }
                


        }
        else
        {
            interact.direction = new Vector2((int)Input.GetAxis("Horizontal"), (int)Input.GetAxis("Vertical"));
            transform.position = Vector3.MoveTowards(transform.position, movepoint, 10 * Time.deltaTime);
        }
    }
}
