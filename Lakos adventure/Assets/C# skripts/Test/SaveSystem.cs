using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveSystemRD
{
    public static class SaveSystem
    {
        public static readonly string saveFolder = Application.dataPath + "/Save/";


        public static void Init()
        {
            // checks if the save folder exits. if it doesnt it makes a save folder
            if (!Directory.Exists(saveFolder))
            {
                //makes save folder
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

            Init();
            File.WriteAllText(Path.Combine(saveFolder + "Save_" + fillName + ".txt"), data);
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
    public enum SaveFilles
    {
        PlayerStuff,
        LinkensTeam,
        LinkensBox,   

        OutDoorsInfo,
        EnlderRuinsInfo,

    }
}


