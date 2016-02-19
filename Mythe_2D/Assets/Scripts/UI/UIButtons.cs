using UnityEngine;
using System.Collections;

public class UIButtons : MonoBehaviour {

    void Update()
    {
        QuitApp();
    }

    void QuitApp()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
