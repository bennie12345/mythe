using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SetHighscore : MonoBehaviour {

    private CurrentScore _currentScoreScript;
    [SerializeField] private Text _highscoreText;
    private int _highscoreValue;
    [SerializeField] private Text _currentScoreText;
    private int _currentScoreValue;
    private Animator _anim;

    private void Start () {
        GetHighscore();
        _currentScoreScript = GameObject.FindWithTag(Tags.CurrentScoreTag).GetComponent<CurrentScore>();
        _anim = GameObject.FindWithTag("Victory").GetComponent<Animator>();
        SetCurrentScore();
        CheckForVictory();
    }

    private void GetHighscore()
    {
        if (File.Exists(Application.persistentDataPath + "/HighScoreData.kappa"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/HighScoreData.kappa", FileMode.Open);

            HighScore saveData = (HighScore)bf.Deserialize(file);
            _highscoreValue = saveData.highScore;
            file.Close();
        }
        _highscoreText.text = "Best Score: " + _highscoreValue;
    }

    private void SetCurrentScore()
    {
        _currentScoreValue = _currentScoreScript.CurrentScoreValue;
        _currentScoreText.text = "Your score: " + _currentScoreValue;
    }

    private void CheckForVictory()
    {
        if(_currentScoreValue >= 500)
        {
            _anim.SetBool("Win", true);
        }
    }
}
