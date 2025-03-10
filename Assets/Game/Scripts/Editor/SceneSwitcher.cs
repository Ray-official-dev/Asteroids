using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public static class SceneSwitcher
{
    [MenuItem("Scenes/Gameplay")]
    public static void SwitchToGameplay()
    {
        string scenePath = @"Assets\Game\Resources\Scenes\Gameplay.unity";

        if (!System.IO.File.Exists(scenePath))
        {
            Debug.LogError("Scene not found");
            return;
        }

        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene(scenePath);
    }
}