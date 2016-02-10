using UnityEngine;
using System.Collections;

public class ArrowProperties : MonoBehaviour {

    [SerializeField]private float speed = 2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Fire(speed);
	}

    void Fire(float projectileSpeed)
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
