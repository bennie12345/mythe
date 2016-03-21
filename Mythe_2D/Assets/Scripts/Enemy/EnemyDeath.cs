using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyDeath : MonoBehaviour {

    private float _enemyDamage = 1f;
    private float _sliceOffset = .1f;
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
            CreatedSlicedEnemy();
        }
	}

    void DestroyEnemy()
    {
        _cameraShakeScript.Shake();
        _scoreScript.UpdateScore(1);
        _slowTimeScript.SlowTheTime();

        if(gameObject.tag == Tags.birdEnemyTag)
        {
            ObjectPool.instance.GetObjectForType(ObjectNames.birdEnemyParticlesName,true).transform.position = transform.position;
        }
        else
        {
            ObjectPool.instance.GetObjectForType(ObjectNames.fishEnemyParticlesName, true).transform.position = transform.position;
        }
        _objectPoolScript.PoolObject(this.gameObject);
    }

    void CreateStonedEnemy()
    {

        if (gameObject.tag == Tags.birdEnemyTag)
        {
            ObjectPool.instance.GetObjectForType(ObjectNames.stonedBirdEnemyName, true).transform.position = transform.position;
        }
        else
        {
            ObjectPool.instance.GetObjectForType(ObjectNames.stonedFishEnemyName, true).transform.position = transform.position;
        }      
    }

    void CreatedSlicedEnemy()
    {
        if (gameObject.tag == Tags.birdEnemyTag)
        {
            GameObject slicedEnemyOne = ObjectPool.instance.GetObjectForType(ObjectNames.birdSlicedEnemyOne, true);
            slicedEnemyOne.transform.position = new Vector2(transform.position.x - _sliceOffset,transform.position.y);

            GameObject slicedEnemyTwo = ObjectPool.instance.GetObjectForType(ObjectNames.birdSlicedEnemyTwo, true);
            slicedEnemyTwo.transform.position = new Vector2(transform.position.x + _sliceOffset, transform.position.y);
        }
        else
            Debug.Log("rip andere enemy's sliced animation");
    }

    void CreateDisintegratedEnemy()
    {
        if (gameObject.tag == Tags.birdEnemyTag)
        {
            //ObjectPool.instance.GetObjectForType(ObjectNames.stonedFlyingEnemyName, true).transform.position = transform.position;
        }
        else
        {
            ObjectPool.instance.GetObjectForType(ObjectNames.fishEnemyDisintegratedName, true).transform.position = transform.position;
        } 
    }

}