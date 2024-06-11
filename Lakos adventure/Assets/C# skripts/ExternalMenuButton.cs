using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalMenuButton : MonoBehaviour
{
    public void leave()
    {
        InfoSaved.areasexplored = new LocationData[0];
        InfoSaved.pomonteams = new pomonteam[0];
        SceneLoader.ChageScene(SceneLoader.ScenesToLoad.MainMenu);
    }

}
