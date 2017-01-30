using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{

    private void Start()
    {
        this.gameObject.tag = Tags.UITag;
    }

    private void Update()
    {
        QuitApp();
    }

    private void QuitApp()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == Scenes.MainMenuScene)
            {
                Application.Quit();
            }

            if (SceneManager.GetActiveScene().name == Scenes.GameScene || SceneManager.GetActiveScene().name == Scenes.GameOverScene || SceneManager.GetActiveScene().name == Scenes.InstructionsScene)
            {
                LoadScene(Scenes.MainMenuScene);
            }
        }
    }

    public void PlayGame()
    {
        LoadScene(Scenes.GameScene);
    }

    public void Instructions()
    {
        LoadScene(Scenes.InstructionsScene);
    }

    public void MainMenu()
    {
        LoadScene(Scenes.MainMenuScene);
    }
    public void Credits()
    {
        LoadScene(Scenes.CreditsScene);
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