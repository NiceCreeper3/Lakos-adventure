using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    [SerializeField]private PlayerMovemont player;
    private bool isopen = false;
    private bool holding = false;
    [SerializeField]private GameObject menu;
    void Update()
    {
        if (Input.GetKey(KeyCode.V))
        {
            if (!holding)
            {
                if (isopen)
                {

                    menu.active = true ;
                    player.enabled = true;
                    isopen = true;

                }
                else
                {

                    menu.active = false;
                    player.enabled = false;
                    isopen = false;

                }
                holding = true;
            }
            

        }
        else
        {
            holding = true;
        }
    }
}
