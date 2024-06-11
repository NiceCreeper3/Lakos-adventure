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
        Actorscript actorscript = Instantiate(actorprephap, actorlayer).GetComponent<Actorscript>();
        actorscript.actor = person;

        actorscript.grid = GetComponent<Grid>();

        actorscript.gameObject.SetActive(true);
        actorscript.load();
        return actorscript;
    }
    public Actorscript generateplayer(Actor person, Vector2 direction, Vector2Int location)
    {


        LocationData data = GetComponent<LocationHandeler>().data;
        
        data.addactor(person, location, null, direction);
        Actorscript actorscript = Instantiate(playerprephap, actorlayer).GetComponent<Actorscript>();
        actorscript.actor = person;

        actorscript.grid = GetComponent<Grid>();
        GameObject[] @object = SceneManager.GetActiveScene().GetRootGameObjects();
        int loads = 0;
        foreach (GameObject game in @object)
        {
            CameraLock Lock = game.GetComponentInChildren<CameraLock>();
            MenuScript menu = game.GetComponentInChildren<MenuScript>();
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
            if (loads == 2)
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

        GameObject newtrainer = Instantiate(trainerprephap, actorlayer);
        Actorscript actorscript = newtrainer.GetComponent<Actorscript>();
        actorscript.actor = person;

        actorscript.grid = GetComponent<Grid>();
        newtrainer.SetActive(true);
        actorscript.load();
        return actorscript;
    }
}
