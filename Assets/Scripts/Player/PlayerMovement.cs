using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]private float _moveSpeed = 7;

    private Rigidbody2D _rb2D;
    // Use this for initialization
    void Start ()
    {
        _rb2D = this.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
		MovePlayer();
	}

    private void MovePlayer()
    {
        var moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * _moveSpeed, CrossPlatformInputManager.GetAxis("Vertical") * _moveSpeed);

        _rb2D.velocity = moveVec;
    }
}
