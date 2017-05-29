using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuSoundtrack : MonoBehaviour
{
    public static MenuSoundtrack Instance;
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    //play the menu soundtrack only in menu/credits/instructions screens
    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == Scenes.MainMenuScene || scene.name == Scenes.InstructionsScene || scene.name == Scenes.CreditsScene)
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }
}
