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
    }
}
