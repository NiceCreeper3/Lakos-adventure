using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class charactreallign : MonoBehaviour
{
    [SerializeField] private Grid grid;
    void Start()
    {
        GameObject[] objectsinscene = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject game in objectsinscene)
        {
            try
            {
                grid = game.GetComponent<Grid>();
            }
            catch
            {

            }

            if (grid)
            {
                break;
            }
        }
        transform.position = grid.CellToWorld(grid.WorldToCell(transform.position)) + new Vector3(0.32f, 0.32f, 0);
        Actorscript actor = GetComponent<Actorscript>();
        if (actor)
        {
            actor.movepoint = new Vector2Int((int)transform.position.x, (int)transform.position.y);
        }
    }
}
