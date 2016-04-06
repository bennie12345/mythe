using UnityEngine;
using System.Collections;

public class Sounds : MonoBehaviour {

    [SerializeField]private AudioClip _playerHitSound;
    public AudioClip PlayerHitSound
    {
        get
        {
            return _playerHitSound;
        }
        set
        {
            _playerHitSound = value;
        }
    }

    [SerializeField]private AudioClip _enemyStoneDeathSound;
    public AudioClip EnemyStoneDeathSound
    {
        get
        {
            return _enemyStoneDeathSound;
        }
        set
        {
            _enemyStoneDeathSound = value;
        }
    }

    [SerializeField]private AudioClip _enemyDisintegrateDeathSound;
    public AudioClip EnemyDisintegratDeathSound
    {
        get
        {
            return _enemyDisintegrateDeathSound;
        }
        set
        {
            _enemyDisintegrateDeathSound = value;
        }
    }

    [SerializeField]private AudioClip _enemySwordDeathSound;
    public AudioClip EnemySwordDeathSound
    {
        get
        {
            return _enemySwordDeathSound;
        }
        set
        {
            _enemySwordDeathSound = value;
        }
    }

    [SerializeField]private AudioClip _swordSound;
    public AudioClip SwordSound
    {
        get
        {
            return _swordSound;
        }
        set
        {
            _medusaSound = value;
        }
    }

    [SerializeField]private AudioClip _medusaSound;
    public AudioClip MedusaSound
    {
        get
        {
            return _medusaSound;
        }
        set
        {
            _medusaSound = value;
        }
    }

    [SerializeField]private AudioClip _laserSound;
    public AudioClip LaserSound
    {
        get
        {
            return _laserSound;
        }
        set
        {
            _laserSound = value;
        }
    }

	void Start () {
        this.gameObject.tag = Tags.soundsObjectTag;
	}
}