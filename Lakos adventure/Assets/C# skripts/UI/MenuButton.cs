using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] public MenuScript menu;
    [SerializeField] private Canvas canvas;
    public void Dexopen(GameObject thisdex)
    {
        menu.killmovement();
        menu.enabled = false;
        Instantiate(thisdex, canvas.transform);
    }
    public void leave()
    {
        SceneLoader.ChageScene(SceneLoader.ScenesToLoad.MainMenu);
    }
}
