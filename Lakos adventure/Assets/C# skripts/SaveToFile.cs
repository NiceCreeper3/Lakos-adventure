using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public static class SaveToFile
{
   public static int saveplayed = -1; 
   public static void savefile()
   {
        savegame(saveplayed);
   }

    public static string[] loadfile(string location)
    {
        return File.ReadAllText(location).Split(" "); ;
    }

    public static void savegame(int playedsave)
    {
        validatesaves();
        if (saveplayed < 0)
        {
            savegame();
            return;
        }
        string savePath = Path.Combine(Application.dataPath, "saves", "save"+playedsave);
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }
        LocationData[] locationDatas = Resources.LoadAll<LocationData>("Maps/location data");
        List<string> locationjson = new List<string>();

        foreach (LocationData data in locationDatas)
        {
            Debug.Log(data);
            locationjson.Add(JsonUtility.ToJson(data));
        }
        string locationJsonString = string.Join(" ", locationjson);
        Debug.Log(locationJsonString);


        File.WriteAllText(Path.Combine(savePath, "LocationData.json"), locationJsonString);

        pomonteam[] pomonteams = Resources.LoadAll<pomonteam>("Player");
        List<string> pomonsinteam = new List<string>();
        List<string> pomonsinbox = new List<string>();

        foreach (pomonteam data in pomonteams)
        {
            Debug.Log(data);
            foreach (Pomons pomon in data.team)
            {
                if (data.name == "players team")
                {
                    Debug.Log(data.name + " " + pomon.PomonName);
                    pomonsinteam.Add(JsonUtility.ToJson(pomon));
                }
                else
                {
                    Debug.Log(data.name + " " + pomon.PomonName);
                    pomonsinbox.Add(JsonUtility.ToJson(pomon));
                }

            }

        }
        string playteamJsonString = string.Join(" ", pomonsinteam);
        Debug.Log(playteamJsonString);

        File.WriteAllText(Path.Combine(savePath, "MyTeam.json"), playteamJsonString);

        string playboxJsonString = string.Join(" ", pomonsinbox);
        Debug.Log(playboxJsonString);

        File.WriteAllText(Path.Combine(savePath, "MyBox.json"), playboxJsonString);

        // adds some extra data that doesn't change the ingame world
        List<string> extrtdata = new List<string>();
        LocationHandeler handeler = null;
        bool handelerfound = false;
        foreach (GameObject game in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            handeler = game.GetComponentInChildren<LocationHandeler>();
            if (handeler)
            {
                extrtdata.Add(SceneLoader.Convert(handeler.data.toLoad).ToString());
                handelerfound = true;
            }

        }
        if (!handelerfound)
        {
            extrtdata.Add("--");
        }
        extrtdata.Add(playedsave.ToString());
        File.WriteAllLines(Path.Combine(savePath, "ExtraData.txt"),extrtdata);
        saveplayed = playedsave;

        
    }

    private static void validatesaves()
    {
        
        if (Directory.Exists(Path.Combine(Application.dataPath, "saves")))
        {
            Directory.CreateDirectory(Path.Combine(Application.dataPath, "saves"));
        }

    }
    public static void savegame()
    {
        validatesaves();
        int index = 0;
        string[] dir = Directory.GetDirectories(Path.Combine(Application.dataPath, "saves"));
        foreach (string save in dir)
        {
            if (!Directory.Exists(Path.Combine(Application.dataPath, "saves", "save" + index)))
            {
                break;
            }
            index++;
        }
        
        Directory.CreateDirectory(Path.Combine(Application.dataPath , "saves","save"+index));

        saveplayed = index;
        string savePath = Path.Combine(Application.dataPath, "saves", "save" + saveplayed);

        LocationData[] locationDatas = Resources.LoadAll<LocationData>("Maps/location data");
        List<string> locationjson = new List<string>();

        foreach (LocationData data in locationDatas)
        {
            Debug.Log(data);
            locationjson.Add(JsonUtility.ToJson(data));
        }
        string locationJsonString = string.Join(" ", locationjson);
        Debug.Log(locationJsonString);


        File.WriteAllText(Path.Combine(savePath, "LocationData.json"), locationJsonString);

        pomonteam[] pomonteams = Resources.LoadAll<pomonteam>("Player");
        List<string> pomonsinteam = new List<string>();
        List<string> pomonsinbox = new List<string>();

        foreach (pomonteam data in pomonteams)
        {
            foreach (Pomons pomon in data.team)
            {
                if (data.name == "players team")
                {
                    Debug.Log(data.name + " " + pomon.PomonName);
                    pomonsinteam.Add(JsonUtility.ToJson(pomon));
                }
                else
                {
                    Debug.Log(data.name +" " + pomon.PomonName);
                    pomonsinbox.Add(JsonUtility.ToJson(pomon));
                }
                
            }
            
        }
        string playteamJsonString = string.Join(" ", pomonsinteam);
        Debug.Log(playteamJsonString);

        File.WriteAllText(Path.Combine(savePath, "MyTeam.json"), playteamJsonString);

        string playboxJsonString = string.Join(" ", pomonsinbox);
        Debug.Log(playboxJsonString);
        
        File.WriteAllText(Path.Combine(savePath, "MyBox.json"), playboxJsonString);

        List<string> extrtdata = new List<string>();
        LocationHandeler handeler = null;
        bool handelerfound = false;
        foreach (GameObject game in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            handeler = game.GetComponentInChildren<LocationHandeler>();
            if (handeler)
            {
                extrtdata.Add(SceneLoader.Convert(handeler.data.toLoad).ToString());
                handelerfound = true;
            }

        }
        if (!handelerfound)
        {
            extrtdata.Add("--");
        }
        extrtdata.Add(index.ToString());
        File.WriteAllLines(Path.Combine(savePath, "ExtraData.txt"), extrtdata);



    }

    public static void loadgame(int save)
    {
        string savePath = Path.Combine(Application.dataPath, "saves", "save" + save);
        LocationData[] locationDatas = Resources.LoadAll<LocationData>("Maps/location data");
        string[] splitfile = loadfile(Path.Combine(savePath, "LocationData.json"));
        foreach (string file in splitfile)
        {
            Debug.Log(file);
            LocationData data = ScriptableObject.CreateInstance<LocationData>();
            JsonUtility.FromJsonOverwrite(file, data);
            Debug.Log(data.toLoad);
            foreach (LocationData location in locationDatas)
            {
                Debug.Log(location.toLoad);
                if (location.toLoad == data.toLoad)
                {
                    Debug.Log("Found");
                    JsonUtility.FromJsonOverwrite(file, location);
                    break;
                }
            }
            Object.Destroy(data);
        }

        savePath = Path.Combine(Application.dataPath, "saves", "save" + save);
        pomonteam[] teams = Resources.LoadAll<pomonteam>("Player");
        foreach (pomonteam team in teams)
        {
            team.team.Clear();
            if (team.name == "players team")
            {
                string[] splitmons = loadfile(Path.Combine(savePath, "MyTeam.json"));
                foreach (string file in splitmons)
                {
                    Pomons mon = ScriptableObject.CreateInstance<Pomons>();
                    JsonUtility.FromJsonOverwrite(file, mon);
                    team.team.Add(mon);
                }
            }
            else if(team.name == "THE BOX")
            {
                string[] splitmons = loadfile(Path.Combine(savePath, "MyBox.json"));
                foreach (string file in splitmons)
                {
                    Pomons mon = ScriptableObject.CreateInstance<Pomons>();
                    JsonUtility.FromJsonOverwrite(file, mon);
                    team.team.Add(mon);
                }
            }
        }
    }


}
