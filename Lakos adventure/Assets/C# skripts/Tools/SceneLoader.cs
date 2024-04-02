using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

/// <summary>
/// used to load scenes ind difrent wayes
/// </summary>
public static class SceneLoader
{
    
    public enum ScenesToLoad
    {
        Battle,
        Startereer,
        ElderRuins
    }

    private static string PreviesScene;


    /// <summary>
    /// findes the scene name using a Enum. this makes scene loading less proven to human error
    /// </summary>
    /// <param name="withToLoad"></param>
    /// <returns></returns>
    private static string FindeLoad(ScenesToLoad withToLoad)
    {
        string sceneName = null;

        // findes the scene name using the ScenesToLoad enum. and then saves it ind the sceneName value
        switch (withToLoad)
        {
            case ScenesToLoad.Battle:
                sceneName = "Battel_Scene";
                break;

            case ScenesToLoad.Startereer:
                sceneName = "outdoors";
                break;

            case ScenesToLoad.ElderRuins:
                sceneName = "Elder_ruins";
                break;


        }

        return sceneName;
    }

    // is four when we need to load a spisifk scene
    public static void ChageScene(ScenesToLoad sceneToLoad)
    {

        SceneManager.LoadScene(FindeLoad(sceneToLoad));

        PreviesScene = SavePreviesScene();
    }

    // closes the aplication
    public static void close()
    {
        Application.Quit();
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
        ChageScene(ScenesToLoad.Battle);
    }

    public static void Battle(trainer Trainer)
    {
        MapToBattel.IsTranerBattle = Trainer;
        MapToBattel.enemyPomons = Trainer.trainerTeam;
        ChageScene(ScenesToLoad.Battle);
    }

    private static string SavePreviesScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        return currentScene.name;
    }


}
