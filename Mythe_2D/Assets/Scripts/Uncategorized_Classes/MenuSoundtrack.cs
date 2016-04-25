using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuSoundtrack : MonoBehaviour {

	void Update()
    {
        if (SceneManager.GetActiveScene().name == Scenes.mainMenuScene || SceneManager.GetActiveScene().name == Scenes.instructionsScene || SceneManager.GetActiveScene().name == Scenes.creditsScene)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
