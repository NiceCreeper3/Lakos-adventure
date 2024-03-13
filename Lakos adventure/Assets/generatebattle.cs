using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatebattle : StateMachineBehaviour
{
    [SerializeField] private PomonsBluPrint monster;
    [SerializeField] private int level;
    [SerializeField] private Actor player;
    [SerializeField] private pomonteam wild;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        while (wild.team.Count >= 1)
        {
            wild.team.RemoveAt(0);
        }
        wild.team.Add(monster.generateMon(level));
        InfoSaved.playerlocation = player.body.grid.WorldToCell(player.body.transform.position);
        SceneLoader.Battle(wild);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
