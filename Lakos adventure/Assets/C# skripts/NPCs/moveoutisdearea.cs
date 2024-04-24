using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generateinlocation : StateMachineBehaviour
{
    [SerializeField] private Actor Actor;
    [SerializeField] private Vector2Int location;
    [SerializeField] private Vector2 direction;
    [SerializeField] private LocationData data;
    [SerializeField] private RuntimeAnimatorController interact;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        data.addactor(Actor, location, interact, direction);
    }
}
