using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class animationinteractor : MonoBehaviour
{
    [SerializeField] private textinteractor handler;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform actorlayer; 
    [SerializeField] private GameObject actorprephap;
    [SerializeField] private GameObject trainerprephap;

    // Start is called before the first frame update
    void Start()
   {
        handler.interactor = this;
        animator.runtimeAnimatorController = handler.controller;
   }

    // Update is called once per frame
    public void setcontroller()
    {
        animator.runtimeAnimatorController = handler.controller;
    }
    
    public Actorscript generateactor(Actor person)
    {
        Actorscript actorscript = Instantiate(actorprephap, actorlayer).GetComponent<Actorscript>();
        actorscript.actor = person;
        return actorscript;
    }
    public Actorscript generateactor(trainer person)
    {
        GameObject newtrainer = Instantiate(trainerprephap, actorlayer);
        Actorscript actorscript = newtrainer.GetComponent<Actorscript>();
        WorldTrainerScript worldTrainerScript = newtrainer.GetComponent<WorldTrainerScript>();
        actorscript.actor = person;
        worldTrainerScript.Trainer = person;
        return actorscript;
    }
}
