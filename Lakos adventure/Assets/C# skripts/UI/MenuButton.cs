using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] public MenuScript menu;
    [SerializeField] private Canvas canvas;
    public void Dexopen(GameObject thisdex)
    {
        disablemenu();
        Instantiate(thisdex, canvas.transform);
    }
    public void leave()
    {
        SceneLoader.ChageScene(SceneLoader.ScenesToLoad.MainMenu);
    }
    public void enablemenu()
    {
        
        menu.enabled = true;
        menu.revidedmovement();
    }
    public void disablemenu()
    {
        menu.killmovement();
        menu.enabled = false;
    }
}
