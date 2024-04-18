using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveToFile
{
   public static string saveplayed;
   public static void savefile(string location,string savefile)
   {
        if (File.Exists(location))
        {
            File.WriteAllText(location, savefile);
        }
   }

    public static string loadfile(string location)
    {
        return File.ReadAllText(location);
    }

    public static void savegame(string playedsave)
    {

    }

    private static void validatesaves()
    {
        if (Directory.Exists(Application.dataPath + "/saves"))
        {
            return;
        }
        Directory.CreateDirectory(Application.dataPath + "/saves");
    }
    public static void savegame()
    {
        validatesaves();
        int index = 0;
        string[] dir = Directory.GetDirectories(Application.dataPath + "/saves");
        foreach (string save in dir)
        {
            if (!Directory.Exists(Application.dataPath + "/saves/save" + index))
            {
                break;
            }
            index++;
        }
        
        Directory.CreateDirectory(Application.dataPath + "/saves/save"+index);

        saveplayed = "save" + index;
        
        LocationData[] locationDatas = Resources.LoadAll<LocationData>(Application.dataPath + "/Maps/location data");
        List<string> locationjson = new List<string>();

        foreach (LocationData data in locationDatas)
        {
            locationjson.Add(JsonUtility.ToJson(data));
        }
        string str = string.Join(" ", locationjson);
        Debug.Log(str);

        File.Create(Application.dataPath + "/saves/" + saveplayed + "/LocationData.json");
        File.WriteAllText(Application.dataPath + "/saves/" + saveplayed + "/LocationData.json", str);        
        
        File.Create(Application.dataPath + "/saves/" + saveplayed + "/MyTeam.json");
        File.Create(Application.dataPath + "/saves/" + saveplayed + "/MyBox.json");
        
        
        

    }

    public static void loadgame(int save)
    {
        
        LocationData[] locationDatas = Resources.LoadAll<LocationData>(Application.dataPath + "/Maps/location data");
        string[] splitfile = loadfile(Application.dataPath + "/saves" + saveplayed + "/locationdata").Split(" ");
        foreach (string file in splitfile)
        {
            LocationData data = JsonUtility.FromJson<LocationData>(file);
            foreach (LocationData location in locationDatas)
            {
                if (location == data)
                {
                    location.actordatainfo = data.actordatainfo;
                }
            }
        }
    }


}
