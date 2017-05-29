using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    //private AsyncOperation _async = null;
    [SerializeField] private string _sceneToLoad;
    [SerializeField] private GameObject _loadScreen;
    [SerializeField] private bool _isUsingLoadingScreen;

    // Use this for initialization
    public void LoadTheScene ()
    {
        if (_isUsingLoadingScreen)
        {
            _loadScreen.SetActive(true);
            StartCoroutine(LoadNextScene(_sceneToLoad));
        }

        else
        {
            SceneManager.LoadScene(_sceneToLoad);
        }
    }

    private IEnumerator LoadNextScene(string scene)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(scene);
    }
}
