using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterArea : MonoBehaviour
{
    [SerializeField] private Actorscript player;
    [SerializeField] private Vector2Int exitlocation;
    [SerializeField] private LocationData location;
    private void Update()
    {
        if (!player)
        {
            GameObject[] objectsinscene = SceneManager.GetActiveScene().GetRootGameObjects();
            foreach (GameObject game in objectsinscene)
            {
                try
                {
                    player = game.GetComponentInChildren<playerinteract>().GetComponent<Actorscript>();
                }
                catch
                {

                }

                if (player)
                {
                    break;
                }
            }
        }
    }
    public void Enter()
    {
        location.addactor(player.actor,exitlocation,null,player.diretion);
        player.actor.kill();
        SceneLoader.ChageScene(location.toLoad);
    }
}
