using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour {

    private float _enemyDamage = 1f;

   	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.tag == "Player")
        {
            other.SendMessage("ApplyDamage", _enemyDamage);
            Destroy(this.gameObject);
        }
	}

}

 
