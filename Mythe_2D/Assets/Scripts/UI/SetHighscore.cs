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

    void Start () {
        GetHighscore();
        _currentScoreScript = GameObject.FindWithTag(Tags.currentScoreTag).GetComponent<CurrentScore>();
        SetCurrentScore();
    }

    void GetHighscore()
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

    void SetCurrentScore()
    {
        _currentScoreValue = _currentScoreScript.CurrentScoreValue;
        _currentScoreText.text = "Your score: " + _currentScoreValue;
    }
}
