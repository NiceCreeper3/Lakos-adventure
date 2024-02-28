using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actorscript : MonoBehaviour
{
    [SerializeField]public Actor actor;
    [SerializeField] public Vector2 diretion;
    [SerializeField] public Grid grid;
    [SerializeField] public Vector3 movepoint = new Vector3(0.31f, 0.31f, 0);

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,movepoint, 1 * Time.deltaTime);
        
    }
    public void load()
    {
        gameObject.transform.position = movepoint;
        actor.body = this;
        if (diretion == new Vector2(0, 1))
        {
            actor.turn(1);
        }
        else if (diretion == new Vector2(0, -1))
        {
            actor.turn(2);
        }
        else if (diretion == new Vector2(-1, 0))
        {
            actor.turn(3);
        }
        else if (diretion == new Vector2(1, 0))
        {
            actor.turn(4);
        }
    }
}
