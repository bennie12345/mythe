using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

    private float _score = 0;
    [SerializeField]private Text _scoreText;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void UpdateScore(float pointsAdded)
    {
        _score += pointsAdded;
        _scoreText.text = "Score: " + _score;
    }
}
