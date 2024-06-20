using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveSystemRD
{
    public enum SaveFilles
    {
        PlayerStuff,
        LinkensTeam,
        LinkensBox,

        Linkens
    }

    public static class SaveSystem
    {

        private static readonly string saveFolder = Application.dataPath + "/Save/";


        public static void Init()
        {
            // Checks if the save folder exists. If it doesn't, it makes a save folder
            if (!Directory.Exists(saveFolder))
            {
                // Makes save folder
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

        public static string Load(SaveFilles fillName)
        {
            /*            string saveString = SaveSystem.Load(SaveFilles.Linkens);
                        if (saveString != null)
                        {
                            SaveObjeck saveObjeck = JsonUtility.FromJson<SaveObjeck>(saveString);
                            teast = saveObjeck.teast;
                        }*/

            string filePath = Path.Combine(saveFolder, "Save_" + fillName + ".txt");
            if (File.Exists(filePath))
            {
                string saveString = File.ReadAllText(filePath);
                return saveString;
            }
            else
            {
                Debug.Log("Can NOT find file: " + filePath);
                return null;
            }
        }
    }
}



