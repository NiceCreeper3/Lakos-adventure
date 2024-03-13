using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

/// <summary>
/// used to load scenes ind difrent wayes
/// </summary>
public static class SceneLoader
{
    private static string PreviesScene;

    // is four when we need to load a spisifk scene
    public static void ChageScene(string SceneToLoad)
    {
        SceneManager.LoadScene(SceneToLoad);

        PreviesScene = SavePreviesScene();
    }

    /// <summary>
    /// returns you to the prives scene was 
    /// </summary>
    public static void ChageScene()
    {
        if (PreviesScene != null)
        {
            SceneManager.LoadScene(PreviesScene);

            PreviesScene = SavePreviesScene();
        }
        else
        {
            Debug.Log("Missing a previes scene to load");
        }
    }

    public static void Battle(pomonteam pomons)
    {
        MapToBattel.IsTranerBattle = null;
        MapToBattel.enemyPomons = pomons;
        ChageScene("Battel_Scene");
    }

    public static void Battle(trainer Trainer)
    {
        MapToBattel.IsTranerBattle = Trainer;
        MapToBattel.enemyPomons = Trainer.trainerTeam;
        ChageScene("Battel_Scene");
    }

    private static string SavePreviesScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        return currentScene.name;
    }
}
