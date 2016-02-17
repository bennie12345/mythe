using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour {

    private float _enemyDamage = 1f;
    private CameraShake _cameraShakeScript;

    void Start()
    {
        _cameraShakeScript = GameObject.FindWithTag(Tags.mainCameraTag).GetComponent<CameraShake>();
    }

   	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.tag == Tags.playerTag)
        {
            _cameraShakeScript.Shake();
            other.SendMessage("ApplyDamage", _enemyDamage);
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == Tags.abilities)
        {
            _cameraShakeScript.Shake();
            Destroy(this.gameObject);
        }
	}

}

 
