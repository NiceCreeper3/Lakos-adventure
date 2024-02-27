using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actorscript : MonoBehaviour
{
    [SerializeField]public Actor actor;
    [SerializeField] public Vector2 diretion;
    [SerializeField] public Grid grid;
    [SerializeField] public Vector3 movepoint = new Vector3(0.31f, 0.31f, 0);
    void Start()
    {
        

    }
    public void load()
    {
        gameObject.transform.position = movepoint;
        actor.body = this;
    }
}
