using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDex : MonoBehaviour
{
    
    public void exitDex()
    {
        MenuButton buttons;
        GameObject[] objectsinscene = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject @object in objectsinscene)
        {
            buttons = @object.GetComponentInChildren<MenuButton>();
            if (buttons)
            {
                buttons.menu.enabled = true;
                if (!buttons.menu.isopen)
                {
                    buttons.menu.revidedmovement();
                }
                break;
            }
        }
        Destroy(gameObject);
    }
}
