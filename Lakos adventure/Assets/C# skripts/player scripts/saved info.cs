using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class InfoSaved
{
    static public LocationData[] areasexplored;

    public static void Loadlocations()
    {
        areasexplored = Resources.LoadAll<LocationData>("Maps/location data");
    }
}
