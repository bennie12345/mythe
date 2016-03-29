using UnityEngine;
using System.Collections;

public class Sounds : MonoBehaviour {

    [SerializeField]private AudioClip _playerHit;
    public AudioClip PlayerHit
    {
        get
        {
            return _playerHit;
        }
        set
        {
            _playerHit = value;
        }
    }

    [SerializeField]private AudioClip _enemyDeath;
    public AudioClip EnemyDeath
    {
        get
        {
            return _enemyDeath;
        }
        set
        {
            _enemyDeath = value;
        }
    }

    [SerializeField]private AudioClip _disintegrateSound;
    public AudioClip DisintegrateSound
    {
        get
        {
            return _disintegrateSound;
        }
        set
        {
            _disintegrateSound = value;
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

    [SerializeField]private AudioClip _firingMahLazor;
    public AudioClip FiringMahLazor
    {
        get
        {
            return _firingMahLazor;
        }
        set
        {
            _firingMahLazor = value;
        }
    }

	void Start () {
        this.gameObject.tag = Tags.soundsObjectTag;
	}
}