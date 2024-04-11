using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour
{
    public Actor player;


    void Update()
    {
        if(player)
        {
            transform.position = player.body.transform.position + new Vector3(0, 0 ,-1);
        }
        
    }
}
