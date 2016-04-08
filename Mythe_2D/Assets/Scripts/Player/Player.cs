using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Player : MonoBehaviour, IKillable {

    private FlashingScreen flashingScreen;
    private Score _scoreScript;
    private CurrentScore _currentScoreScript;
    private SlowTime _slowTimeScript;
    private Rigidbody2D _rb2D;
    private Animator _anim;

    [SerializeField]private float _health = 2f;
    public float Health
    {
        get
        {
            return _health;
        }
        
        set
        {
            _health = value;
        }
    }
    private float _playerBoundX = 6.5f;
    private float _playerBoundY = 4f;

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

    private bool _usingMedusaHead = false;
    public bool UsingMedusaHead
    {
        get
        {
            return _usingMedusaHead;
        }

        set
        {
            _usingMedusaHead = value;
        }
    }

    private bool _usingLaser = false;
    public bool UsingLaser
    {
        get
        {
            return _usingLaser;
        }

        set
        {
            _usingLaser = value;
        }
    }


    [SerializeField]private float _moveSpeed;
    public float MoveSpeed
    {
        get
        {
            return _moveSpeed;
        }

        set
        {
            _moveSpeed = value;
        }
    }

	// Use this for initialization
	void Start () 
    {
        _anim = GetComponent<Animator>();
        flashingScreen = GameObject.FindWithTag(Tags.flashingScreenObjectTag).GetComponent<FlashingScreen>();
        _scoreScript = GameObject.FindWithTag(Tags.UITag).GetComponent<Score>();
        _slowTimeScript = GameObject.FindWithTag(Tags.UITag).GetComponent<SlowTime>();
        _rb2D = this.GetComponent<Rigidbody2D>();
        this.gameObject.tag = Tags.playerTag;
        _currentScoreScript = GameObject.FindWithTag(Tags.currentScoreTag).GetComponent<CurrentScore>();
    }
	
	// Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();

        Kill();

        SwordIsUsed();

        MedusaHeadIsUsed();

        LaserIsUsed();

        PlayerBounds();
    }

    void MovePlayer()
    {
        Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * _moveSpeed, CrossPlatformInputManager.GetAxis("Vertical") * _moveSpeed);

        _rb2D.velocity = moveVec;
    }

    void ApplyDamage(float _damage)
    {
        if (_usingSword == false)
        {
            _slowTimeScript.SlowTheTime();
            _health -= _damage;
            flashingScreen.StartFade();
        }
    }

    public void Kill()
    {
        if (_health <= 0)
        {
            Time.timeScale = 1.0f;
            _scoreScript.StoreHighscore(_scoreScript.ScoreValue);
            _currentScoreScript.CurrentScoreValue = _scoreScript.ScoreValue;
            LoadingScreen.Show();
            SceneManager.LoadScene(Scenes.gameOverScene);
        }
    }

    void SwordIsUsed()
    {
        if (_usingSword == true)
        {
            StartCoroutine(ItemDuration("Sword", 2.5f));
            _anim.SetBool("isUsingSword", true);
        }
        else
        {
            _anim.SetBool("isUsingSword", false);
        }
    }

    void MedusaHeadIsUsed()
    {
        if (_usingMedusaHead == true)
        {
            StartCoroutine(ItemDuration("MedusaHead", 2f));
            _anim.SetBool("isUsingMedusaHead", true);
        }
        else
        {
            _anim.SetBool("isUsingMedusaHead", false);
        }
    }

    void LaserIsUsed()
    {
        if (_usingLaser == true)
        {
            StartCoroutine(ItemDuration("Laser", 2f));
            _anim.SetBool("isUsingLaser", true);
        }
        else
        {
            _anim.SetBool("isUsingLaser", false);
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

    IEnumerator ItemDuration(string whichItem, float itemDuration)
    {
        yield return new WaitForSeconds(itemDuration);
        if(whichItem == "Laser")
        {
            _usingLaser = false;
        }
        else if(whichItem == "MedusaHead")
        {
            _usingMedusaHead = false;
        }
        else
        {
            UsingSword = false;
        }
        
    }
}