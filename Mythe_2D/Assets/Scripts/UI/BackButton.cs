using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public static BackButton Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        CheckBackbutton();
    }

    private void CheckBackbutton()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == Scenes.MainMenuScene)
            {
                Application.Quit();
            }

            else if (SceneManager.GetActiveScene().name == Scenes.GameScene)
            {
                //do nothing
            }

            else
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}