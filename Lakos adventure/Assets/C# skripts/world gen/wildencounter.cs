using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wildencounter : MonoBehaviour
{
    public void enterencouter(pomonlist pomons)
    {
        PomonsBluPrint bluPrint = pomons.bluPrint[Random.Range(0,pomons.bluPrint.Length)];
        Debug.Log(bluPrint.name);
    }
}
