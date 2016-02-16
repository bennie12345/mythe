using UnityEngine;
using System.Collections;
using UnityEditor;

public class MenuItems : MonoBehaviour
{
    [MenuItem ("Dikke bmw/Clear PlayerPrefs")]
    public static void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("player prefs cleared");
    }
}
