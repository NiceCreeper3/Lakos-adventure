using UnityEngine;

public class ExitWindowKeybordButton : MonoBehaviour
{
    // turns off the UI part its on
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
    }

}
