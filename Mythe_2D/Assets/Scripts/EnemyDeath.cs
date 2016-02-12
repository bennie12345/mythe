using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour {

   	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
	}

}

 
