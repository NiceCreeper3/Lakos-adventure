using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class MainMenuButtons : MonoBehaviour
{
    [Header("new game peramiters")]
    [SerializeField] private Vector2Int startlocation;
    [SerializeField] private AnimatorController openingcutscene;
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
