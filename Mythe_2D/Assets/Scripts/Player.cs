using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    private Rigidbody2D _rb2D;
    private float _health = 2f;
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
        
	}
	
	// Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();

        KillPlayer();

        SwordIsUsed();
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
            StartCoroutine(SwordCooldown());
        }
    }

    IEnumerator SwordCooldown()
    {
        yield return new WaitForSeconds(2);
        _usingSword = false;
    }
}
