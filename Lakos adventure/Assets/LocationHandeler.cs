using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationHandeler : MonoBehaviour
{
    public LocationData data;
    [SerializeField] private textinteractor inizilizer;
    // Start is called before the first frame update
    public void Loadall()
    {

        foreach(LocationData.SceneActorData sceneActor in data.actordatainfo)
        {
            sceneActor.actor.body = inizilizer.Generateactor(sceneActor.actor);
            sceneActor.actor.setx(sceneActor.location.x);
            sceneActor.actor.sety(sceneActor.location.y);
            sceneActor.actor.turn(sceneActor.direction);
            sceneActor.actor.interaction = sceneActor.interaction;
        }
    }
}