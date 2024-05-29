using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Generateinlocation : StateMachineBehaviour
{
    [SerializeField] private Actor actor;
    [SerializeField] private Vector2Int location;
    [SerializeField] private Vector2 direction;
    [SerializeField] private LocationData data;
    [SerializeField] private RuntimeAnimatorController interact;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        

        GameObject[] @object = SceneManager.GetActiveScene().GetRootGameObjects();
        
        foreach (GameObject game in @object)
        {
            data.addactor(actor, location, interact, direction);
            LocationHandeler handeler1 = game.GetComponent<LocationHandeler>();
            if (handeler1)
            {

                if (handeler1.data == data)
                {
                    Actorscript actorscript = textinteractor.Generateactor(actor, direction, location);
                    actorscript.actor.changeinteraction(interact);
                    break;
                }
            }
            


        }

    }
}
