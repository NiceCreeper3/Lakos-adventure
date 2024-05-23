using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class InfoSaved
{
    static public LocationData[] areasexplored;
    static public pomonteam[] pomonteams;

    public static void Loadlocations()
    {
        areasexplored = Resources.LoadAll<LocationData>("Maps/location data");
        pomonteams = Resources.LoadAll<pomonteam>("Player");

    }
}
