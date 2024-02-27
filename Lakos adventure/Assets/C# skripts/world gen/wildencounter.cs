using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wildencounter : MonoBehaviour
{
    [SerializeField] private pomonteam wild;
    public void enterencouter(Wildgrass grass)
    {
        PomonsBluPrint[] bluPrints = grass.posiblemons.bluPrint;
        PomonsBluPrint bluPrint = bluPrints[Random.Range(0,bluPrints.Length)];
        wild.team.Add(bluPrint.generateMon(Random.Range(grass.minlevel,grass.maxlevel+1))) ;
        SceneLoader.Battle(wild);
    }
}
