using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    [SerializeField]private PlayerMovemont player;
    private bool isopen;
    private bool holding;
    [SerializeField]private GameObject menu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (!holding)
            {
                if (!isopen)
                {
                    menu.SetActive(true);
                    player.enabled = false;
                    isopen = true;

                }
                else
                {
                    menu.SetActive(false);
                    player.enabled = true;
                    isopen = false;

                }
                holding = true;
            }
            

        }
        else
        {
            holding = false;
        }
    }
}
