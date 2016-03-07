using UnityEngine;
using System.Collections;

public class DeadEnemies : MonoBehaviour {

    private Rigidbody2D _rb;
    private float _speed;
    private float _upSpeed = 150;

    void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
       
        if (gameObject.tag == Tags.slicedBirdOneTag)
        {
            _rb.AddForce(transform.up * _upSpeed);
            _speed = Random.Range(2, 6);
        }

        else if(gameObject.tag == Tags.slicedBirdTwoTag)
        {
            _speed = Random.Range(-6, -2);
            _rb.AddForce(transform.up * _upSpeed);
        }
        
    }

	void FixedUpdate() 
    {
        RotateEnemy();
        if(gameObject.tag == Tags.slicedBirdOneTag || gameObject.tag == Tags.slicedBirdTwoTag)
        {

            ThrowApart();
        }
    }

    void RotateEnemy()
    {
        transform.Rotate(0, 0, -1);
    }

    void ThrowApart()
    {
        _rb.AddForce(-transform.right * _speed);
    }
}
