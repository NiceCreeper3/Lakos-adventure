using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class animationinteractor : MonoBehaviour
{
    [SerializeField] public Animator animator;
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
    
    public Actorscript generateactor(Actor person, Vector2 direction, Vector2Int location) 
    {
        LocationData data = GetComponent<LocationHandeler>().data;
        
        data.addactor(person, location, null, direction);
        int index = data.findactor(person);

        Actorscript actorscript = Instantiate(actorprephap, actorlayer).GetComponent<Actorscript>();
        actorscript.movepoint = data.actordatainfo[index].location;
        actorscript.diretion = direction;
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
        actorscript.gameObject.SetActive(true);
        actorscript.load();
        return actorscript;
    }
    public Actorscript generateplayer(Actor person, Vector2 direction, Vector2Int location)
    {


        LocationData data = GetComponent<LocationHandeler>().data;
        
        data.addactor(person, location, null, direction);
        int index = data.findactor(person);

        Actorscript actorscript = Instantiate(playerprephap, actorlayer).GetComponent<Actorscript>();
        actorscript.movepoint = data.actordatainfo[index].location;
        actorscript.diretion = direction;
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
        actorscript.gameObject.SetActive(true);
        actorscript.load();
        return actorscript;
    }
    public Actorscript generatetrainer(Actor person, Vector2 direction, Vector2Int location)
    {
        LocationData data = GetComponent<LocationHandeler>().data;

        data.addactor(person, location, null, direction);
        int index = data.findactor(person);

        GameObject newtrainer = Instantiate(trainerprephap, actorlayer);
        Actorscript actorscript = newtrainer.GetComponent<Actorscript>();
        actorscript.movepoint = data.actordatainfo[index].location;
        actorscript.diretion = direction;
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
        newtrainer.SetActive(true);
        actorscript.load();
        return actorscript;
    }
}
