using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    private Rigidbody2D _rb;

    [SerializeField]
    private float _moveForce = 10;

	// Use this for initialization
	void Start () 
    {
        _rb = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * _moveForce, CrossPlatformInputManager.GetAxis("Vertical") * _moveForce);

        _rb.velocity = moveVec;
	}
}
