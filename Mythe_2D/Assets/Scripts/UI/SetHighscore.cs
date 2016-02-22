using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetHighscore : MonoBehaviour {

    [SerializeField] private Text _highscoreText;
    [SerializeField] private Text _currentScoreText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        SetHighScore();
        SetCurrentScore();
	}
    
    void SetHighScore()
    {
        _highscoreText.text = "Best Score: " + PlayerPrefs.GetInt("ScoreValue");
    }

    void SetCurrentScore()
    {
        _currentScoreText.text = "Your Score: " + PlayerPrefs.GetInt("CurrentScore");
    }
}
