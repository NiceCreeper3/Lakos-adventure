using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using System;

[CreateAssetMenu(fileName = "new location data", menuName = "handeler/locationdata")]
public class LocationData : ScriptableObject
{
    [Serializable]
    public struct SceneActorData
    {
        public Actor actor;
        public RuntimeAnimatorController interaction;
        public Vector2Int location;
        public Vector2 direction;

        public SceneActorData(Actor actor = default, RuntimeAnimatorController interaction = default, Vector2Int location = default, Vector2 direction = default)
        {
            this.actor = actor;
            this.interaction = interaction;
            this.location = location;
            this.direction = direction;
        }
    }

    public SceneLoader.ScenesToLoad toLoad;
    public List<SceneActorData> actordatainfo;

    public int findactor(Actor actor)
    {
        int index =  0;
        foreach(SceneActorData actorinscene in actordatainfo)
        {
            if (actorinscene.actor == actor)
            {
                return index;
            }
            index++;
        }
        return -1;
         
    }

    // adds scene actor data for actor too this Location data if it doesn't exist. 
    public void addactor(Actor actor, Vector2Int location, RuntimeAnimatorController interaction, Vector2 direction)
    {
        SceneActorData actorlocationinfo;
        bool existsts = false;
        foreach (SceneActorData actorinscene in actordatainfo)
        {
            if (actorinscene.actor == actor)
            {
                actorlocationinfo = actorinscene;
                setactor(actor, location, direction, interaction);
                existsts = true;
                break;
            }

        }
        if (!existsts)
        {
            SceneActorData data = new SceneActorData(actor, interaction, location, direction);
            actordatainfo.Add(data);
        }

    }
    public void setactor(Actor actor, Vector2Int location)
    {
        int index = findactor(actor);
        if (index >= 0)
        {
            SceneActorData sceneActor = actordatainfo[index];
            sceneActor.location = location;
            removeactor(actor);
            actordatainfo.Insert(index, sceneActor);

        }

    }
    public void setactor(Actor actor, Vector2Int location, Vector2 direction, RuntimeAnimatorController interaction)
    {
        int index = findactor(actor);
        if(index >= 0)
        {
            SceneActorData sceneActor = actordatainfo[index];
            sceneActor.direction = direction;
            sceneActor.location = location;
            sceneActor.interaction = interaction;
            removeactor(actor);
            actordatainfo.Insert(index, sceneActor);
            
        }


    }

    public void setactor(Actor actor, Vector2 direction, RuntimeAnimatorController interaction)
    {
        int index = findactor(actor);
        if (index >= 0)
        {
            SceneActorData sceneActor = actordatainfo[index];
            sceneActor.direction = direction;
            sceneActor.interaction = interaction;
            removeactor(actor);
            actordatainfo.Insert(index, sceneActor);

        }

    }

    public void setactor(Actor actor, RuntimeAnimatorController interaction)
    {
        int index = findactor(actor);
        if (index >= 0)
        {
            SceneActorData sceneActor = actordatainfo[index];
            sceneActor.interaction = interaction;
            removeactor(actor);
            actordatainfo.Insert(index, sceneActor);

        }

    }

    public void setactor(Actor actor, Vector2Int location, Vector2 direction)
    {
        int index = findactor(actor);
        if (index >= 0)
        {
            SceneActorData sceneActor = actordatainfo[index];
            sceneActor.direction = direction;
            sceneActor.location = location;
            removeactor(actor);
            actordatainfo.Insert(index, sceneActor);

        }

    }

    public void setactor(Actor actor, Vector2 direction)
    {
        int index = findactor(actor);
        if (index >= 0)
        {
            SceneActorData sceneActor = actordatainfo[index];
            sceneActor.direction = direction;
            removeactor(actor);
            actordatainfo.Insert(index, sceneActor);

        }

    }
    public void removeactor(Actor actor)
    {
        int index = findactor(actor);
        if (index != -1)
        {
            actordatainfo.RemoveAt(index);
        }

    }
}
