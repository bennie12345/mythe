using UnityEngine;
using System.Collections;

public class StoneEnemy : MonoBehaviour {

	void Update () {
        rotateEnemy(); 
    }

    void rotateEnemy()
    {
        transform.Rotate(0, 0, -1);
    }
}
