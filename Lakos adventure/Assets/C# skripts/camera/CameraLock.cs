using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour
{
    public Actorscript player;


    void Update()
    {
        try
        {
            transform.position = player.transform.position + new Vector3(0, 0, -1);
        }
        catch
        {

        }
        
    }
}
