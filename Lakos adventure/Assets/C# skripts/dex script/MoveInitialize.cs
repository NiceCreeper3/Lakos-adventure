using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInitialize : MonoBehaviour
{
    [SerializeField] List<GameObject> moves;
    [SerializeField]GameObject movebutton;
    // Update is called once per frame
    public void Updatemoves( List<BasikMoves> pomonMoves)
    {
        if (moves.Count > 0)
        {
            foreach (GameObject move in moves)
            {
                Destroy(move);
            }
        }
        
        foreach (BasikMoves move in pomonMoves)
        {
            GameObject movebut = Instantiate(movebutton, transform);
            movebut.GetComponent<VisualMove>().Visulize(move);
            moves.Add(movebut);
        }
    }
}
