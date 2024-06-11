using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
    [Header("new game peramiters")]
    [SerializeField] private Vector2Int startlocation;
    [SerializeField] private playeractor player;
    [SerializeField] private pomonlist generate;
    [SerializeField] private int level;
    [SerializeField] private LocationData  startarea;
    [SerializeField] private SceneLoader.ScenesToLoad StartScenes;
    [SerializeField] private RuntimeAnimatorController openingcutscene;


    public void play()
    {
        textinteractor.controller = openingcutscene;
        startarea.addactor(player, startlocation, null, new Vector2(0,-1));
        SaveToFile.saveplayed = -1;
        SceneLoader.ChageScene(StartScenes);
    }
    private void Start()
    {
        InfoSaved.Loadlocations();
    }
    public void load()
    {
        SaveToFile.savegame();
    }
    public void quit()
    {
        SceneLoader.close();
    }
}
