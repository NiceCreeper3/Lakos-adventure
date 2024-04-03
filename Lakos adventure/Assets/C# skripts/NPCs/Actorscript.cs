using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actorscript : MonoBehaviour
{
    [SerializeField] public Actor actor;
    [SerializeField] public Vector2 diretion;
    [SerializeField] public Grid grid;
    [SerializeField] public Vector3 movepoint;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,movepoint, 1 * Time.deltaTime);
        
    }
    public void load()
    {
        
        gameObject.transform.position = movepoint;
        actor.body = this;

        if (diretion.y != 0)
        {
            if (diretion.y >= 0)
            {
                actor.turn(1);
            }
            else
            {
                actor.turn(2);
            }

        }
        else if (0 != diretion.x)
        {
            if (diretion.x >= 0)
            {
                actor.turn(4);
            }
            else
            {
                actor.turn(3);
            }


        }
    }
}
