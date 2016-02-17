using UnityEngine;
using System.Collections;

public class SaveLoadResources : MonoBehaviour {

    [SerializeField]private int gold;
    public int Gold
    {
        get { return gold; }
    }

    public void SaveResources()
    {
        PlayerPrefs.SetInt("Gold", gold);
        Debug.Log("resources saved");
    }

    public void LoadResources()
    {
        if(PlayerPrefs.HasKey("Gold"))
        {
            gold = PlayerPrefs.GetInt("Gold");
            Debug.Log("resources loaded");
        }
       
    }
}
