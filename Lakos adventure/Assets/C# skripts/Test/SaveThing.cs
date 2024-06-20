using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaveSystemRD;

public class SaveThing : MonoBehaviour
{
    
    [SerializeField] private Pomons phomon;
    [SerializeField] private pomonteam _playerTream;
    [SerializeField] private pomonteam _playerBox;

    [SerializeField] private PomonsBluPrint AAAAAAAAAAA;

    private void Awake()
    {
        SaveGameStuff();

        LoadStuff();
    }

    public void SaveGameStuff()
    {
        string json = "";


        List<string> lik = new List<string>();


        //LinkenGroups linkenGroups = new LinkenGroups();

        foreach (Pomons pomon in _playerTream.team)
        {
            json = JsonUtility.ToJson(pomon);
            lik.Add(json);
        }

        json = string.Join(" ", lik);

       SaveSystem.Save(SaveFilles.Linkens , json);
    }

    public void LoadStuff()
    {
        string saveStringTeam = SaveSystem.Load(SaveFilles.LinkensTeam);
        string saveStringBox = SaveSystem.Load(SaveFilles.LinkensBox);

        if (saveStringTeam != null)
        {
            MakePomonGroup(saveStringTeam, _playerTream.team);
        }
        if (saveStringBox != null)
        {
            MakePomonGroup(saveStringBox, _playerTream.team);
        }

    }

    private void MakePomonGroup(string fillPath, List<Pomons> linkenGroup)
    {
        // split the words ind the fille indto a array
        string[] Linkens = fillPath.Split(" ");

        foreach (string jsonLinkens in Linkens)
        {
            Pomons linken = ScriptableObject.CreateInstance<Pomons>();

            JsonUtility.FromJsonOverwrite(jsonLinkens, linken);

            //Debug.Log(pomon);
            linkenGroup.Add(linken);
        }

        foreach (Pomons pomons in linkenGroup)
        {
            
            Debug.Log(pomons);
        }
    }
}
