using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class MainMenuButtons : MonoBehaviour
{
    [Header("new game peramiters")]
    [SerializeField] private Vector2Int startlocation;
    [SerializeField] private RuntimeAnimatorController openingcutscene;
    [SerializeField] private textinteractor texter;

    public void play()
    {
        texter.controller = openingcutscene;
        InfoSaved.playerlocation = (Vector3Int)startlocation;
        SceneLoader.ChageScene("outdoors");
    }

    public void load()
    {
        
    }
    public void quit()
    {
        
    }
}
