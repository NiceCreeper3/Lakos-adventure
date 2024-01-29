using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doesitBrack : MonoBehaviour
{
    // K: endrer Navn, F: slet A: bruge i method
    private int RemoveThisValue;

    void klaes()
    {

    }

    void freja()
    {

    }

    private int alex()
    {
        RemoveThisValue = 5;

        int u = 4;

        RemoveThisValue += u;

        return RemoveThisValue;
    }

    // delethe this method
    private void Delemethod()
    {
        // i did not delete this
    }


    private void ThangeThisMethod()
    {

        Debug.LogError("somthing" + alex());
    }
}
