using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Player : MonoBehaviour, IKillable {

    private FlashingScreen _flashingScreen;
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

    public bool UsingSword { get; set; }

    public bool UsingMedusaHead { get; set; }

    public bool UsingLaser { get; set; }


    [SerializeField]private float _moveSpeed;

    public Player()
    {
        UsingLaser = false;
        UsingMedusaHead = false;
        UsingSword = false;
    }

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
    private void Start () 
    {
        _anim = GetComponent<Animator>();
        _flashingScreen = GameObject.FindWithTag(Tags.FlashingScreenObjectTag).GetComponent<FlashingScreen>();
        _scoreScript = GameObject.FindWithTag(Tags.UITag).GetComponent<Score>();
        _slowTimeScript = GameObject.FindWithTag(Tags.UITag).GetComponent<SlowTime>();
        _rb2D = this.GetComponent<Rigidbody2D>();
        this.gameObject.tag = Tags.PlayerTag;
        _currentScoreScript = GameObject.FindWithTag(Tags.CurrentScoreTag).GetComponent<CurrentScore>();
    }
	
	// Update is called once per frame
    private void FixedUpdate()
    {
        MovePlayer();

        Kill();

        SwordIsUsed();

        MedusaHeadIsUsed();

        LaserIsUsed();

        PlayerBounds();
    }

    private void MovePlayer()
    {
        var moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * _moveSpeed, CrossPlatformInputManager.GetAxis("Vertical") * _moveSpeed);

        _rb2D.velocity = moveVec;
    }

    private void ApplyDamage(float damage)
    {
        if (UsingSword != false) return;
        _slowTimeScript.SlowTheTime();
        _health -= damage;
        _flashingScreen.StartFade();
    }

    public void Kill()
    {
        if (!(_health <= 0)) return;
        Time.timeScale = 1.0f;
        _scoreScript.StoreHighscore(_scoreScript.ScoreValue);
        _currentScoreScript.CurrentScoreValue = _scoreScript.ScoreValue;
        LoadingScreen.Show();
        SceneManager.LoadScene(Scenes.GameOverScene);
    }

    private void SwordIsUsed()
    {
        switch (UsingSword)
        {
            case true:
                StartCoroutine(ItemDuration("Sword", 2.5f));
                _anim.SetBool("isUsingSword", true);
                break;
            default:
                _anim.SetBool("isUsingSword", false);
                break;
        }
    }

    private void MedusaHeadIsUsed()
    {
        switch (UsingMedusaHead)
        {
            case true:
                StartCoroutine(ItemDuration("MedusaHead", 2f));
                _anim.SetBool("isUsingMedusaHead", true);
                break;
            default:
                _anim.SetBool("isUsingMedusaHead", false);
                break;
        }
    }

    private void LaserIsUsed()
    {
        switch (UsingLaser)
        {
            case true:
                StartCoroutine(ItemDuration("Laser", 2f));
                _anim.SetBool("isUsingLaser", true);
                break;
            default:
                _anim.SetBool("isUsingLaser", false);
                break;
        }
    }

    private void PlayerBounds()
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

    private IEnumerator ItemDuration(string whichItem, float itemDuration)
    {
        yield return new WaitForSeconds(itemDuration);
        switch (whichItem)
        {
            case "Laser":
                UsingLaser = false;
                break;
            case "MedusaHead":
                UsingMedusaHead = false;
                break;
            default:
                UsingSword = false;
                break;
        }
    }
}