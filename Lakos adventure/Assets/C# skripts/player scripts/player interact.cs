using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerinteract : MonoBehaviour
{
    public Vector2 direction;
    [SerializeField] private CircleCollider2D col;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit2D[] hit = new RaycastHit2D[1];
            col.Raycast(direction, hit, 3.52f);
        }
    }
}
