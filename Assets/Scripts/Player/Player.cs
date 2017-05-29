using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IKillable {

    public delegate void PlayerHitAction();
    public static event PlayerHitAction OnPlayerHit;

    private Score _scoreScript;
    private CurrentScore _currentScoreScript;
    
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

    public bool UsingSword { get; set; }

    public bool UsingMedusaHead { get; set; }

    public bool UsingLaser { get; set; }

    public Player()
    {
        UsingLaser = false;
        UsingMedusaHead = false;
        UsingSword = false;
    }

	// Use this for initialization
    private void Start () 
    {
        _anim = GetComponent<Animator>();
        _scoreScript = GameObject.FindWithTag(Tags.UITag).GetComponent<Score>();
        gameObject.tag = Tags.PlayerTag;
        _currentScoreScript = GameObject.FindWithTag(Tags.CurrentScoreTag).GetComponent<CurrentScore>();
    }
	
	// Update is called once per frame
    private void Update()
    {
        Kill();

        SwordIsUsed();

        MedusaHeadIsUsed();

        LaserIsUsed();
    }

    

    private void ApplyDamage(float damage)
    {
        if (UsingSword != false) return;
        _health -= damage;
        if (OnPlayerHit != null)
        {
            OnPlayerHit();
        }
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