using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    public void Dexopen(GameObject thisdex)
    {
        Instantiate(thisdex, canvas.transform);
    }
    public void leave()
    {
        SceneLoader.ChageScene("menue");
    }
}
