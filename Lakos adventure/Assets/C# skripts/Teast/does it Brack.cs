using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doesitBrack : MonoBehaviour
{
    // K: endrer Navn, F: slet A: bruge i method
    private int KeepThisValue;

    void klaes()
    {
        transform.position = new Vector3(); 
    }

    void freja()
    {

    }

    void alex()
    {

    }


    private void TangelThisMethod()
    {
        try
        {
            GetComponent<playerinteract>();
        }
        catch
        {

        }
    }
}
