using UnityEngine;
using System.Collections;

public class EnemyAwake : MonoBehaviour {


    void Start() {

    }
    void Update() {
    }

   	void OnTriggerEnter2D(Collider2D other)
	{
        Debug.Log("triggerd");
		if (other.gameObject.tag == "Bullet")
			Destroy(this.gameObject);
        

	}

}

 
