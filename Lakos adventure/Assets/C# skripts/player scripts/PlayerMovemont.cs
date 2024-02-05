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
        movepoint = grid.CellToWorld(InfoSaved.playerlocation) + new Vector3(1.76f, 1.76f, 0);
        gameObject.transform.position = movepoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == movepoint)
        {
            bool isempty = true;
            RaycastHit2D[] hit = new RaycastHit2D[2];
            col.Raycast(new Vector2(0,(int)Input.GetAxis("Vertical")), hit, 3.52f);
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
                movepoint += new Vector3(0, 3.52f * (int)Input.GetAxis("Vertical"), 0);
            }
            


            if (transform.position == movepoint)
            {
                isempty = true;
                col.Raycast(new Vector2((int)Input.GetAxis("Horizontal"), 0), hit, 3.52f);
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
                    movepoint += new Vector3(3.52f * (int)Input.GetAxis("Horizontal"), 0, 0);
                }
                
                
            }
                


        }
        else
        {
            
            transform.position = Vector3.MoveTowards(transform.position, movepoint, 10 * Time.deltaTime);
        }
    }
}
