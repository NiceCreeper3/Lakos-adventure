using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savepanle : MonoBehaviour
{
    public void savenew()
    {
        SaveToFile.savegame();
    }
    public void save()
    {
        SaveToFile.savefile();
    }
}
