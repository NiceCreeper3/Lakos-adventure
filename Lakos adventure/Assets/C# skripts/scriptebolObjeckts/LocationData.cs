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
}
