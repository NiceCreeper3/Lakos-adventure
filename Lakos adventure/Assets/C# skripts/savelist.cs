using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class savelist : MonoBehaviour
{

    [SerializeField]private GameObject saveObject;
    // Start is called before the first frame update
    void Awake()
    {
        string[] dir = Directory.GetDirectories(Path.Combine(Application.dataPath, "saves"));
        foreach (string save in dir)
        {
            savefileveiwer game = Instantiate(saveObject, transform).GetComponent<savefileveiwer>();
            game.file = int.Parse(File.ReadAllLines(Path.Combine(save, "ExtraData.txt"))[1]);
            game.visualize();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
