using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CurrentScore : MonoBehaviour {

    private int _score;
    public int CurrentScoreValue
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
        }
    }

    private void Awake()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag(Tags.CurrentScoreTag);
        if(obj.Length > 1)
        {
            Destroy(obj[1]);
        }

        DontDestroyOnLoad(this.gameObject);
    }

}
