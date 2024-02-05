using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class EnterArea : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Grid grid;
    public void Enter(string warparea)
    {
        InfoSaved.playerlocation = grid.WorldToCell(player.position);
        SceneManager.LoadScene(warparea);
    }
}
