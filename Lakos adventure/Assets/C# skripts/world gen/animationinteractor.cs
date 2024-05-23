using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class animationinteractor : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform actorlayer; 
    [SerializeField] private GameObject actorprephap;
    [SerializeField] private GameObject trainerprephap;
    [SerializeField] private GameObject playerprephap;

    // Start is called before the first frame update
    void Start()
   {
        textinteractor.interactor = this;
        animator.runtimeAnimatorController = textinteractor.controller;
        GetComponent<LocationHandeler>().Loadall();
   }

    // Update is called once per frame
    public void setcontroller()
    {
        animator.runtimeAnimatorController = textinteractor.controller;
    }
    
    public Actorscript generateactor(Actor person)
    {
        LocationData data = GetComponent<LocationHandeler>().data;
        int index = data.findactor(person);
        if (index == -1)
        {
            data.addactor(person, new Vector2Int(), null, new Vector2(0, -1));
        }
        Actorscript actorscript = Instantiate(actorprephap, actorlayer).GetComponent<Actorscript>();
        actorscript.actor = person;
        GameObject[] @object = SceneManager.GetActiveScene().GetRootGameObjects();

        foreach (GameObject game in @object)
        {
            Grid grid = game.GetComponentInChildren<Grid>();

            if (grid)
            {
                actorscript.grid = grid;
                break;
            }

        }
        return actorscript;
    }

    public Actorscript generateplayer(Actor person)
    {


        LocationData data = GetComponent<LocationHandeler>().data;
        int index = data.findactor(person);
        if (index == -1)
        {
            data.addactor(person, new Vector2Int(), null, new Vector2(0, -1));
        }
        Actorscript actorscript = Instantiate(playerprephap, actorlayer).GetComponent<Actorscript>();
        actorscript.actor = person;

        GameObject[] @object = SceneManager.GetActiveScene().GetRootGameObjects();
        int loads = 0;
        foreach (GameObject game in @object)
        {
            Grid grid = game.GetComponentInChildren<Grid>();
            CameraLock Lock = game.GetComponentInChildren<CameraLock>();
            MenuScript menu = game.GetComponentInChildren<MenuScript>();
            if (grid)
            {
                actorscript.grid = grid;
                loads++;

            }
            if (Lock)
            {
                Lock.player = actorscript;
                loads++;

            }
            if (menu)
            {
                menu.player = actorscript.GetComponent<PlayerMovemont>();
                loads++;

            }
            if (loads == 3)
            {
                break;
            }

        }
        foreach (GameObject game in @object)
        {
            

        }

        return actorscript;
    }
    public Actorscript generatetrainer(Actor person)
    {
        LocationData data = GetComponent<LocationHandeler>().data;
        int index = data.findactor(person);
        if (index == -1)
        {
            data.addactor(person,new Vector2Int(), null,new Vector2(0,-1));
        }


        
        GameObject newtrainer = Instantiate(trainerprephap, actorlayer);
        Actorscript actorscript = newtrainer.GetComponent<Actorscript>();
        actorscript.actor = person;
        GameObject[] @object = SceneManager.GetActiveScene().GetRootGameObjects();

        foreach (GameObject game in @object)
        {
            Grid grid = game.GetComponentInChildren<Grid>();

            if (grid)
            {
                actorscript.grid = grid;
                break;
            }

        }
        return actorscript;
    }
}
