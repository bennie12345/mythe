using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//with every scene change use: LoadingScreen.Show();
public class LoadingScreen : MonoBehaviour
{
    //make a UI image in a seperate canvas and place it at the highest order in layer
    //put the script on the seperate camvas element
    [SerializeField]private Image _loadingScreen;
    private static LoadingScreen instance;

    //initialize instance of loadingscreen and make sure it persists throughout other scenes (DontDestroyOnLoad(this))
    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            Hide();
            return;
        }
        instance = this;
        transform.position = new Vector3(0.5f, 0.5f, 1f);
        DontDestroyOnLoad(this);
        _loadingScreen.enabled = false;
    }

    //check if unity isn't loading a scene, if so, hide the loadingscreen
    private void Update()
    {
        if (!Application.isLoadingLevel)
            Hide();
    }

    //show the loadingscreen
    public static void Show()
    {
        if (!InstanceExists())
        {
            return;
        }
        instance._loadingScreen.enabled = true;
    }

    //hide the loadinscreen
    public static void Hide()
    {
        if (!InstanceExists())
        {
            return;
        }
        instance._loadingScreen.enabled = false;
    }

    //check if the loadingscreen exists
    private static bool InstanceExists()
    {
        if (!instance)
        {
            return false;
        }
        return true;
    }
}