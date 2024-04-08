using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

[CreateAssetMenu(fileName = "new location data", menuName = "handeler/locationdata")]
public class LocationData : ScriptableObject
{
    [System.Serializable]
    public struct SceneActorData
    {
        public Actor actor;
        public RuntimeAnimatorController interaction;
        public Vector2Int location;
    }
}
