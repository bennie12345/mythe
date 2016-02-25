using UnityEngine;
using System.Collections;

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

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

}
