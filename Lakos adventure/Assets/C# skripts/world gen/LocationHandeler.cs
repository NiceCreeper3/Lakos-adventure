using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationHandeler : MonoBehaviour
{
    public LocationData data;
    // Start is called before the first frame update
    public void Loadall()
    {
        LocationData.SceneActorData[] truedata = data.actordatainfo.ToArray();
        foreach (LocationData.SceneActorData sceneActor in truedata)
        {
            sceneActor.actor.body = textinteractor.Generateactor(sceneActor.actor, sceneActor.direction, sceneActor.location,sceneActor.interaction);
            sceneActor.actor.interaction = sceneActor.interaction;
        }
    }
}
