using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    private Rigidbody2D _rb2D;
    private float _health = 2f;
    private float _playerBoundX = 6.5f;
    private float _playerBoundY = 4f;
    private float _swordDuration = 2f;
    private GameObject _sword;
    private bool _usingSword = false;
    public bool UsingSword
    {
        get
        {
            return _usingSword;
        }

        set
        {
            _usingSword = value;
        }
    }

    [SerializeField]private float _moveForce = 10;

	// Use this for initialization
	void Start () 
    {
        _rb2D = this.GetComponent<Rigidbody2D>();
        this.gameObject.tag = Tags.playerTag;
        _sword = GameObject.FindWithTag(Tags.swordTag);
	}
	
	// Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();

        KillPlayer();

        SwordIsUsed();

        PlayerBounds();
    }

    void MovePlayer()
    {
        Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * _moveForce, CrossPlatformInputManager.GetAxis("Vertical") * _moveForce);

        _rb2D.velocity = moveVec;
    }

    void ApplyDamage(float _damage)
    {
        if (_usingSword == false)
        {
            _health -= _damage;
        }
    }

    void KillPlayer()
    {
        if (_health == 0)
        {
            //Destroy(this.gameObject)
        }
    }

    void SwordIsUsed()
    {
        if (_usingSword)
        {
            StartCoroutine(SwordDuration());
            _sword.SetActive(true);
        }
        else
        {
            _sword.SetActive(false);
        }
    }

    void PlayerBounds()
    {
        if (transform.position.x <= -_playerBoundX)
        {
            transform.position = new Vector2(-_playerBoundX, transform.position.y);
        }
        else if (transform.position.x >= _playerBoundX)
        {
            transform.position = new Vector2(_playerBoundX, transform.position.y);
        }
        if (transform.position.y <= -_playerBoundY)
        {
            transform.position = new Vector2(transform.position.x, -_playerBoundY);
        }
        else if (transform.position.y >= _playerBoundY)
        {
            transform.position = new Vector2(transform.position.x, _playerBoundY);
        }
    }

    IEnumerator SwordDuration()
    {
        yield return new WaitForSeconds(_swordDuration);
        _usingSword = false;

    }
}
