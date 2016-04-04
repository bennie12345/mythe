using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyDeath : MonoBehaviour, IKillable
{

    private float _enemyDamage = 1f;

    protected string _stoneEnemy;
    protected string _slicedEnemy;
    protected string _disintegratedEnemy;

    //private Sounds _sounds;

    private CameraShake _cameraShakeScript;
    private Score _scoreScript;
    private ObjectPool _objectPoolScript;
    //private AudioSource source;

    delegate void SoundDelegate(AudioClip clip);
    SoundDelegate soundDelegate;


    void playSound(AudioClip clip)
    {
        //source.PlayOneShot(clip);
    }

    protected virtual void Start()
    {
        _scoreScript = GameObject.FindWithTag(Tags.UITag).GetComponent<Score>();
        _cameraShakeScript = GameObject.FindWithTag(Tags.mainCameraTag).GetComponent<CameraShake>();
        _objectPoolScript = GameObject.FindWithTag(Tags.objectPoolTag).GetComponent<ObjectPool>();
        //_sounds = GameObject.FindWithTag("SoundsObject").GetComponent<Sounds>();
        //source = GetComponent<AudioSource>();
        //soundDelegate = playSound;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == Tags.playerTag)
        {
            other.SendMessage("ApplyDamage", _enemyDamage);
            //soundDelegate(_sounds.PlayerHit);
            Kill();
        }

        if (other.gameObject.tag == Tags.medusaTag)
        {
            CreateStoneEnemy();
            Kill();
        }

        if (other.gameObject.tag == Tags.swordTag)
        {
            CreatedSlicedEnemy();
            Kill();
        }

        if (other.gameObject.tag == Tags.laserTag)
        {
            CreateDisintegratedEnemy();
            Kill();
        }
    }

    public void Kill()
    {
        _cameraShakeScript.Shake();
        _scoreScript.UpdateScore(1);
        //soundDelegate(_sounds.EnemyDeath);
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
        //soundDelegate(_sounds.DisintegrateSound);
    }

}