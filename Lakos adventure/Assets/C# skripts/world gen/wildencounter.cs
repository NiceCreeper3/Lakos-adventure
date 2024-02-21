using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wildencounter : MonoBehaviour
{
    public void enterencouter(pomonlist pomons)
    {
        PomonsBluPrint bluPrint = pomons.bluPrint[Random.Range(0,pomons.bluPrint.Length)];
        MapToBattel.IsTranerBattle = null;
        MapToBattel.enemyPomons = new pomonteam();
        SceneLoader.ChageScene("Battle_Scene");
    }
}
