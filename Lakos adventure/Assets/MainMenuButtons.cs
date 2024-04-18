using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
    [Header("new game peramiters")]
    [SerializeField] private Vector2Int startlocation;
    [SerializeField] private playeractor player;
    [SerializeField] private LocationData  startarea;
    [SerializeField] private SceneLoader.ScenesToLoad StartScenes;
    [SerializeField] private RuntimeAnimatorController openingcutscene;
    [SerializeField] private textinteractor texter;

    public void play()
    {
        texter.controller = openingcutscene;
        startarea.addactor(player, startlocation, null, new Vector2(0,-1));
        SceneLoader.ChageScene(StartScenes);
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
