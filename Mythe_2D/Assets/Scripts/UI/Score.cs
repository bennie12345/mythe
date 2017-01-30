using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Score : MonoBehaviour {

    [SerializeField] private Text _scoreText;

    private int _oldHighscore;
    [SerializeField]private int _score = 0;
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

    private IEnumerator PassiveScore()
    {
        UpdateScore(1);
        yield return new WaitForSeconds(1f);
    }

    private void GivePassiveScore()
    {
        StartCoroutine(PassiveScore());
    }

    private void Start()
    {
        GetHighscore();

        InvokeRepeating("GivePassiveScore", 1, 1f);
    }

    public void StoreHighscore(int newHighscore)
    {
        if(newHighscore > _oldHighscore)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/HighScoreData.kappa");
            HighScore saveScore = new HighScore();
            saveScore.highScore = newHighscore;

            bf.Serialize(file, saveScore);
            file.Close();
        }
    }

    public void GetHighscore()
    {
        if (File.Exists(Application.persistentDataPath + "/HighScoreData.kappa"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/HighScoreData.kappa", FileMode.Open);

            HighScore saveData = (HighScore)bf.Deserialize(file);
            _oldHighscore = saveData.highScore;
            file.Close();
        }
    }
}

[System.Serializable]
public class HighScore
{
    public int highScore;
}
 