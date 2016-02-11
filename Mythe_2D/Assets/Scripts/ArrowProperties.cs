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
        DestroyArrow();
	}

    void Fire(float projectileSpeed)
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyArrow()
    {
        Destroy(this.gameObject, 3.5f);
    }
}
