using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public Texture2D texture;
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
        gameObject.AddComponent<GUITexture>().enabled = false;
        GetComponent<GUITexture>().texture = texture;
        transform.position = new Vector3(0.5f, 0.5f, 1f);
        DontDestroyOnLoad(this);
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
        instance.GetComponent<GUITexture>().enabled = true;
    }

    public static void Hide()
    {
        if (!InstanceExists())
        {
            return;
        }
        instance.GetComponent<GUITexture>().enabled = false;
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