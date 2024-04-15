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
    }

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
        foreach (SceneActorData actorinscene in actordatainfo)
        {
            if (actorinscene.actor == actor)
            {
                actorlocationinfo = actorinscene;
                break;
            }

        }
        if (actor)
        {
            setactor(actor, location, direction, interaction);
        }
        else
        {
            SceneActorData data = new SceneActorData();
            data.actor = actor;
            data.direction = direction;
            data.location = location;
            data.interaction = interaction;
            actordatainfo.Add(data);
        }




    }
    public void setactor(Actor actor, Vector2Int location)
    {
        SceneActorData actorlocationinfo ;
        foreach (SceneActorData actorinscene in actordatainfo)
        {
            if (actorinscene.actor == actor)
            {
                actorlocationinfo = actorinscene;
                break;
            }

        }
        if (actor)
        {
            actorlocationinfo.location = location;
        }

    }
    public void setactor(Actor actor, Vector2Int location, Vector2 direction, RuntimeAnimatorController interaction)
    {
        SceneActorData actorlocationinfo;
        foreach (SceneActorData actorinscene in actordatainfo)
        {
            if (actorinscene.actor == actor)
            {
                actorlocationinfo = actorinscene;
                break;
            }

        }
        if (actor)
        {
            actorlocationinfo.location = location;
            actorlocationinfo.direction = direction;
            actorlocationinfo.interaction = interaction;
        }

    }

    public void setactor(Actor actor, Vector2 direction, RuntimeAnimatorController interaction)
    {
        SceneActorData actorlocationinfo;
        foreach (SceneActorData actorinscene in actordatainfo)
        {
            if (actorinscene.actor == actor)
            {
                actorlocationinfo = actorinscene;
                break;
            }

        }
        if (actor)
        {
            actorlocationinfo.direction = direction;
            actorlocationinfo.interaction = interaction;
        }

    }

    public void setactor(Actor actor, RuntimeAnimatorController interaction)
    {
        SceneActorData actorlocationinfo;
        foreach (SceneActorData actorinscene in actordatainfo)
        {
            if (actorinscene.actor == actor)
            {
                actorlocationinfo = actorinscene;
                break;
            }

        }
        if (actor)
        {
            actorlocationinfo.interaction = interaction;
        }

    }

    public void setactor(Actor actor, Vector2Int location, Vector2 direction)
    {
        SceneActorData actorlocationinfo;
        foreach (SceneActorData actorinscene in actordatainfo)
        {
            if (actorinscene.actor == actor)
            {
                actorlocationinfo = actorinscene;
                break;
            }

        }
        if (actor)
        {
            actorlocationinfo.location = location;
            actorlocationinfo.direction = direction;
        }

    }

    public void setactor(Actor actor, Vector2 direction)
    {
        SceneActorData actorlocationinfo;
        foreach (SceneActorData actorinscene in actordatainfo)
        {
            if (actorinscene.actor == actor)
            {
                actorlocationinfo = actorinscene;
                break;
            }

        }
        if (actor)
        {
            actorlocationinfo.direction = direction;
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
