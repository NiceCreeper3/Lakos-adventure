using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    [SerializeField]public PlayerMovemont player;

    [HideInInspector]public bool isopen;
    private bool holding;
    [SerializeField]private GameObject menu;

    public void killmovement()
    {
        
        player.enabled = false;

    }
    public void revidedmovement()
    {
        
        player.enabled = true;

    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (!holding)
            {
                if (!isopen)
                {
                    menu.SetActive(true);
                    killmovement();
                    isopen = true;
                }
                else
                {
                    menu.SetActive(false);
                    revidedmovement();
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
