using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyDeath : MonoBehaviour {

    private float _enemyDamage = 1f;
    private CameraShake _cameraShakeScript;
    private Score _scoreScript;
    private SlowTime _slowTimeScript;
    private ObjectPool _objectPoolScript;
    
    [SerializeField]private ParticleSystem _deathParticles;
    [SerializeField]private GameObject stonedEnemy;

    void Start()
    {
        _scoreScript = GameObject.FindWithTag(Tags.UITag).GetComponent<Score>();
        _cameraShakeScript = GameObject.FindWithTag(Tags.mainCameraTag).GetComponent<CameraShake>();
        _slowTimeScript = GameObject.FindWithTag(Tags.UITag).GetComponent<SlowTime>();
        _objectPoolScript = GameObject.FindWithTag(Tags.objectPoolTag).GetComponent<ObjectPool>();
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

        if(other.gameObject.tag == Tags.medusaTag)
        {
            CreateStonedEnemy();
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
        _scoreScript.UpdateScore(1);
        _slowTimeScript.SlowTheTime();
        //Instantiate(_deathParticles, this.transform.position, Quaternion.Euler(0, 90, -90));
        if(gameObject.tag == Tags.enemyTag)
        {
            ObjectPool.instance.GetObjectForType(ObjectNames.flyingEnemyParticlesName,true).transform.position = transform.position;
        }
        else
        {
            ObjectPool.instance.GetObjectForType(ObjectNames.otherEnemyParticlesName, true).transform.position = transform.position;
        }
        _objectPoolScript.PoolObject(this.gameObject);
        //Destroy(this.gameObject);
    }

    void CreateStonedEnemy()
    {
        //Instantiate(stonedEnemy,transform.position,transform.rotation);
        if (gameObject.tag == Tags.enemyTag)
        {
            ObjectPool.instance.GetObjectForType(ObjectNames.stonedFlyingEnemyName, true).transform.position = transform.position;
        }
        else
        {
            ObjectPool.instance.GetObjectForType(ObjectNames.stonedOtherEnemyName, true).transform.position = transform.position;
        }
        
    }

}

 
