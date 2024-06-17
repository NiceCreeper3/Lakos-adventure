using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem
{
    public enum SaveFilles
    {
        PlayerStuff,
        Box,
        Linkens
    }


    private struct SaveObjeck
    {
       public int teast;
    }

    private static readonly string saveFolder = Application.dataPath + "/Save/";


    public static void Init()
    {
        if (!Directory.Exists(saveFolder))
        {
            Directory.CreateDirectory(saveFolder);
        }
    }

    public static void Save(SaveFilles fillName, string data)
    {

        ///        SaveObjeck saveObjeck = new SaveObjeck
        ///        {
        ///           teast = 2,
        ///        };
        ///        string json = JsonUtility.ToJson(save);

        File.WriteAllText(saveFolder + "save_" + fillName + ".txt", data);
    } 

    public static string Load(SaveFilles fill)
    {
        if (!File.Exists(saveFolder + "/save_" + fill + ".txt"))
        {
            string saveString = File.ReadAllText(saveFolder + "/save_" + fill + ".txt");
            return saveString;
        }
        else
        {
            return null;
        }
    }
}
