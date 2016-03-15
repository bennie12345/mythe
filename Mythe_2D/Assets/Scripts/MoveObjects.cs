using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveObjects : MonoBehaviour
{
    [SerializeField]
    private float speed = 0f;
    [SerializeField]
    private float horizontal_direction = 0f;
    private Vector3 _direction;
    private bool spawn = false;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("spawnUpdate", 0.5f, Random.Range(0, 0));
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(new Vector3(speed * horizontal_direction * Time.deltaTime, 0, 0));
        if(_direction.x < 0)
        {
            InvokeRepeating("spawn", 0.5f, 1);
            spawn = true;
        }
	}
}
