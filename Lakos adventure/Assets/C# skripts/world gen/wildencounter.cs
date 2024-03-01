using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wildencounter : MonoBehaviour
{
    [SerializeField] private pomonteam wild;
    [SerializeField] private Transform player;
    [SerializeField] private Grid grid;
    public void enterencouter(Wildgrass grass)
    {
        PomonsBluPrint[] bluPrints = grass.posiblemons.bluPrint;
        PomonsBluPrint bluPrint = bluPrints[Random.Range(0,bluPrints.Length)];
        while (wild.team.Count >= 1)
        {
            wild.team.RemoveAt(0);
        }
        wild.team.Add(bluPrint.generateMon(Random.Range(grass.minlevel,grass.maxlevel+1))) ;
        InfoSaved.playerlocation = grid.WorldToCell(player.position);
        SceneLoader.Battle(wild);
    }
}
