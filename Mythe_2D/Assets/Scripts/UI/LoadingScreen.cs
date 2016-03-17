using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField]private Image _loadingScreen;
    static LoadingScreen instance;

    void Awake()
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

    void Update()
    {
        if (!Application.isLoadingLevel)
            Hide();
    }

    public static void Show()
    {
        if (!InstanceExists())
        {
            return;
        }
        instance._loadingScreen.enabled = true;
    }

    public static void Hide()
    {
        if (!InstanceExists())
        {
            return;
        }
        instance._loadingScreen.enabled = false;
    }

    static bool InstanceExists()
    {
        if (!instance)
        {
            return false;
        }
        return true;

    }

}