using UnityEngine;
using System.Collections;

public class EnemyAwake : MonoBehaviour {
    public Animation anim;

    void Start() {
        anim = GetComponent<Animation>();
    }
    void Update() {
    }
   	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Bullet")
			Destroy(this.gameObject);
        

	}

}

 
