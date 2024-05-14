using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[CreateAssetMenu(fileName = "new Actor", menuName = "person/Playable Actor")]
public class playeractor : Actor
{
    public void KillControl()
    {
        body.GetComponent<PlayerMovemont>().enabled = false;
        body.GetComponent<playerinteract>().enabled = false;
        GameObject[] @object = SceneManager.GetActiveScene().GetRootGameObjects();

        foreach (GameObject game in @object)
        {
            MenuScript grid = game.GetComponentInChildren<MenuScript>();

            if (grid)
            {
                grid.enabled = false;
                break;
            }

        }
    }

    public void enableControl()
    {
        body.GetComponent<PlayerMovemont>().enabled = true;
        body.GetComponent<playerinteract>().enabled = true;
        GameObject[] @object = SceneManager.GetActiveScene().GetRootGameObjects();

        foreach (GameObject game in @object)
        {
            MenuScript grid = game.GetComponentInChildren<MenuScript>();

            if (grid)
            {
                grid.enabled = true;
                break;
            }

        }
    }
}

