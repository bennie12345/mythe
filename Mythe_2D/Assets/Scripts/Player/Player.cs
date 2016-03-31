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
        flashingScreen = GameObject.FindWithTag(Tags.flashingScreenObjectTag).GetComponent<FlashingScreen>();
        _scoreScript = GameObject.FindWithTag(Tags.UITag).GetComponent<Score>();
        _slowTimeScript = GameObject.FindWithTag(Tags.UITag).GetComponent<SlowTime>();
        _rb2D = this.GetComponent<Rigidbody2D>();
        this.gameObject.tag = Tags.playerTag;
        _sword = GameObject.FindWithTag(Tags.swordTag);
        _currentScoreScript = GameObject.FindWithTag(Tags.currentScoreTag).GetComponent<CurrentScore>();
    }
	
	// Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();

        Kill();

        SwordIsUsed();

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