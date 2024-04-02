using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterArea : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Grid grid;
    public void Enter(SceneLoader.ScenesToLoad warparea)
    {
        InfoSaved.playerlocation = grid.WorldToCell(player.position);
        SceneLoader.ChageScene(warparea);
    }
}
