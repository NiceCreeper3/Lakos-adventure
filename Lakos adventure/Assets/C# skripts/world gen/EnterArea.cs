using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterArea : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Grid grid;
    [SerializeField] private SceneLoader.ScenesToLoad warparea;
    public void Enter()
    {
        InfoSaved.playerlocation = grid.WorldToCell(player.position);
        SceneLoader.ChageScene(warparea);
    }
}
