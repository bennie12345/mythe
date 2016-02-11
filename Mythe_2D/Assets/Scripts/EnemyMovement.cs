using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
    [SerializeField] private int movespeed = 1;
    private Vector3 userDirection = Vector3.right;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(userDirection * movespeed * Time.deltaTime);
	
	}
}
