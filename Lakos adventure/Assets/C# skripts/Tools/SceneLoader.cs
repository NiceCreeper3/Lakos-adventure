using UnityEngine.SceneManagement;

public static class SceneLoader
{
    private static string PreviesScene;

    // is four when we need to load a spisifk scene
    public static void ChageScene(string SceneToLoad)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        PreviesScene = currentScene.name;
        SceneManager.LoadScene(SceneToLoad);
    }

    // returns you to what the prives scene was 
    public static void ChageScene()
    {
        if (PreviesScene != null)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            PreviesScene = currentScene.name;
            SceneManager.LoadScene(PreviesScene);          
        }
    }
}
