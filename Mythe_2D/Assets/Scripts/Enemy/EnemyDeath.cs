using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyDeath : MonoBehaviour, IKillable{

    private float _enemyDamage = 1f;

    protected string _stoneEnemy;
    protected string _slicedEnemy;
    protected string _disintegratedEnemy;

    private CameraShake _cameraShakeScript;
    private Score _scoreScript;
    private SlowTime _slowTimeScript;
    private ObjectPool _objectPoolScript;

    protected void Start()
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
            Kill();
        }

        if(other.gameObject.tag == Tags.medusaTag)
        {
            CreateStoneEnemy();
            Kill();
        }

        if (other.gameObject.tag == Tags.swordTag)
        {
            CreatedSlicedEnemy();
            Kill();
        }

        if(other.gameObject.tag == Tags.laserTag)
        {
            CreateDisintegratedEnemy();
            Kill();
        }
	}

    public void Kill()
    {
        _cameraShakeScript.Shake();
        _scoreScript.UpdateScore(1);
        _slowTimeScript.SlowTheTime();
        _objectPoolScript.PoolObject(this.gameObject);
    }

    void CreateStoneEnemy()
    {
        ObjectPool.instance.GetObjectForType(_stoneEnemy, true).transform.position = transform.position;
    }

    void CreatedSlicedEnemy()
    {
        ObjectPool.instance.GetObjectForType(_slicedEnemy, true).transform.position = transform.position;
    }

    void CreateDisintegratedEnemy()
    {
        ObjectPool.instance.GetObjectForType(_disintegratedEnemy, true).transform.position = transform.position;
    }

}