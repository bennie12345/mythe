using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

    [SerializeField] private Text _scoreText;

    private int _score = 0;
    public int ScoreValue
    {
        get
        {
            return _score;
        }
    }

    public void UpdateScore(int pointsAdded)
    {
        _score += pointsAdded;
        _scoreText.text = " " + _score;
    }

    public void StoreHighscore(int newHighscore)
    {
        int oldHighscore = PlayerPrefs.GetInt("ScoreValue", 0);
        if(newHighscore > oldHighscore)
        {
            PlayerPrefs.SetInt("ScoreValue", newHighscore);
        }
    }
}
