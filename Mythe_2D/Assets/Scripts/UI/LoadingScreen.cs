using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//with every scene change use: LoadingScreen.Show();
public class LoadingScreen : MonoBehaviour
{
    //make a UI image in a seperate canvas and place it at the highest order in layer
    //put the script on the seperate camvas element
    [SerializeField]private GameObject _loadingScreen;
    private static LoadingScreen _instance;

    //initialize _instance of loadingscreen and make sure it persists throughout other scenes (DontDestroyOnLoad(this))
    private void Awake()
    {
        if (_instance)
        {
            Destroy(gameObject);
            Hide();
            return;
        }
        _instance = this;
        transform.position = new Vector3(0.5f, 0.5f, 1f);
        DontDestroyOnLoad(this);
        _loadingScreen.SetActive(false);
    }

    //show the loadingscreen
    public static void Show()
    {
        if (!InstanceExists())
        {
            return;
        }
        _instance._loadingScreen.SetActive(true);
    }

    //hide the loadinscreen
    public static void Hide()
    {
        if (!InstanceExists())
        {
            return;
        }
        _instance._loadingScreen.SetActive(false);
    }

    //check if the loadingscreen exists
    private static bool InstanceExists()
    {
        if (!_instance)
        {
            return false;
        }
        return true;
    }
}