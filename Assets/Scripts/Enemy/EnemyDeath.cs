using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyDeath : MonoBehaviour, IKillable
{
    //parent class for enemy deaths
    private float _enemyDamage = 1f;

    protected string StoneEnemy;
    protected string SlicedEnemy;
    protected string DisintegratedEnemy;
    protected string DeadEnemy;

    private Sounds _sounds;

    private CameraShake _cameraShakeScript;
    private Score _scoreScript;
    private ObjectPool _objectPoolScript;
    private AudioSource _source;

    private delegate void SoundDelegate(AudioClip clip);

    private SoundDelegate _soundDelegate;


    private void playSound(AudioClip clip)
    {
        _source.PlayOneShot(clip);
    }

    protected virtual void Start()
    {
        _scoreScript = GameObject.FindWithTag(Tags.UITag).GetComponent<Score>();
        _cameraShakeScript = GameObject.FindWithTag(Tags.MainCameraTag).GetComponent<CameraShake>();
        _objectPoolScript = GameObject.FindWithTag(Tags.ObjectPoolTag).GetComponent<ObjectPool>();
        _sounds = GameObject.FindWithTag("SoundsObject").GetComponent<Sounds>();
        _source = _sounds.GetComponent<AudioSource>();
        _soundDelegate = playSound;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == Tags.PlayerTag)
        {
            other.SendMessage("ApplyDamage", _enemyDamage);
            _soundDelegate(_sounds.PlayerHitSound);
            CreateDeadEnemy();
            Kill();
        }

        if (other.gameObject.tag == Tags.MedusaTag)
        {
            CreateStoneEnemy();
            Kill();
        }

        if (other.gameObject.tag == Tags.SwordTag)
        {
            CreatedSlicedEnemy();
            Kill();
        }

        if (other.gameObject.tag == Tags.LaserTag)
        {
            CreateDisintegratedEnemy();
            Kill();
        }
    }

    public void Kill()
    {
        _cameraShakeScript.Shake();
        _scoreScript.UpdateScore(10);
        _objectPoolScript.PoolObject(this.gameObject);
    }

    private void CreateStoneEnemy()
    {
        ObjectPool.instance.GetObjectForType(StoneEnemy, true).transform.position = transform.position;
        _soundDelegate(_sounds.EnemyStoneDeathSound);
    }

    private void CreatedSlicedEnemy()
    {
        ObjectPool.instance.GetObjectForType(SlicedEnemy, true).transform.position = transform.position;
        _soundDelegate(_sounds.EnemySwordDeathSound);
    }

    private void CreateDisintegratedEnemy()
    {
        ObjectPool.instance.GetObjectForType(DisintegratedEnemy, true).transform.position = transform.position;
        _soundDelegate(_sounds.EnemyDisintegratDeathSound);
    }

    private void CreateDeadEnemy()
    {
        ObjectPool.instance.GetObjectForType(DeadEnemy, true).transform.position = transform.position;
    }

}