using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class savefileveiwer : MonoBehaviour
{
    public int file;

    private TMP_Text text;
    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponentInChildren<TMP_Text>();
        string save = Path.Combine(Application.dataPath, "saves", "save" + file);
        string[] info = File.ReadAllLines(Path.Combine(save, "ExtraData.txt"));
        text.text = info[0];
        file = int.Parse(info[1]);
    }

    public void loadgame()
    {
        SaveToFile.loadgame(file);
    }
}
