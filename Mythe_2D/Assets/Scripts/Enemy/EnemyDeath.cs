using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyDeath : MonoBehaviour {

    private float _enemyDamage = 1f;
    private CameraShake _cameraShakeScript;
<<<<<<< HEAD
    private Score _scoreScript;
=======
    static ulong addScore = 0;
    static string scoreCount = "0";
    [SerializeField]private Text playerScore;
>>>>>>> origin/master

    void Start()
    {
        _scoreScript = GameObject.FindWithTag(Tags.UITag).GetComponent<Score>();
        _cameraShakeScript = GameObject.FindWithTag(Tags.mainCameraTag).GetComponent<CameraShake>();
    }

   	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.tag == Tags.playerTag)
        {
            other.SendMessage("ApplyDamage", _enemyDamage);
            DestroyEnemy();
        }

        if (other.gameObject.tag == Tags.abilities)
        {
            DestroyEnemy();
        }

        if (other.gameObject.tag == Tags.swordTag)
        {
            DestroyEnemy();
        }
	}

    void DestroyEnemy()
    {
        _cameraShakeScript.Shake();
        Destroy(this.gameObject);
<<<<<<< HEAD
        _scoreScript.UpdateScore(1f);
=======
        addScore = addScore + 1;
        scoreCount = addScore.ToString();
        playerScore.text = scoreCount;
>>>>>>> origin/master
    }

}

 
