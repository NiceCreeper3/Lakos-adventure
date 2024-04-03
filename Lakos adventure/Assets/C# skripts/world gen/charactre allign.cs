using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class charactreallign : MonoBehaviour
{
    [SerializeField] private Grid grid;
    void Start()
    {
        transform.position = grid.CellToWorld(grid.WorldToCell(transform.position)) + new Vector3(0.32f, 0.32f, 0);
        Actorscript actor = GetComponent<Actorscript>();
        if (actor)
        {
            actor.movepoint = transform.position;
        }
    }
}
