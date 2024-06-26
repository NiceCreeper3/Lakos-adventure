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


    // generates actor in location when called
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        string debugText = "the @objeck array: ";
        

        GameObject[] @object = SceneManager.GetActiveScene().GetRootGameObjects();
   
        foreach (GameObject game in @object)
        {
            debugText += game.name + ", "; 

            

            LocationHandeler handeler1 = game.GetComponent<LocationHandeler>();
            if (handeler1)
            {

                if (handeler1.data == data)
                {
                    Actorscript actorscript = textinteractor.Generateactor(actor, direction, location, interact);
                    actorscript.actor.changeinteraction(interact);
                    break;
                }
                else
                {
                    data.addactor(actor, location, interact, direction);
                }
            }
            
        }

        Debug.Log(debugText);
        animator.SetTrigger("continue");
    }
}
