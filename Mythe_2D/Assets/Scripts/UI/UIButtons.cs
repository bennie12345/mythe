using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour {
    
    void Start()
    {
        this.gameObject.tag = Tags.UITag;
    }

    void Update()
    {
        QuitApp();
    }

    void QuitApp()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == Scenes.mainMenuScene)
            {
                Application.Quit();
            }

            if (SceneManager.GetActiveScene().name == Scenes.gameScene || SceneManager.GetActiveScene().name == Scenes.gameOverScene || SceneManager.GetActiveScene().name == Scenes.instructionsScreen)
            {
                LoadScene(Scenes.mainMenuScene);
            }
        }
    }

    public void PlayGame()
    {
        LoadScene(Scenes.gameScene);
    }

    public void Instructions()
    {
        LoadScene(Scenes.instructionsScreen);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void LoadScene(string sceneToLoad)
    {
        LoadingScreen.Show();
        SceneManager.LoadScene(sceneToLoad);
    }
}
