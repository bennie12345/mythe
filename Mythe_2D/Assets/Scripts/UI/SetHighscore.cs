using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetHighscore : MonoBehaviour {

    [SerializeField] private Text _highscoreText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        SetHighScore();
	}
    
    void SetHighScore()
    {
        _highscoreText.text = "Best: " + PlayerPrefs.GetInt("ScoreValue");
    }
}
