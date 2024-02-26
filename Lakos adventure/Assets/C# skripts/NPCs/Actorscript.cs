using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actorscript : MonoBehaviour
{
    [SerializeField]public Actor actor;
    [SerializeField] public Vector2 diretion;
    void Start()
    {
        actor.body = this;
    }
}
