using UnityEngine;
using System.Collections;

public class DeadEnemies : MonoBehaviour {

	void Update () {
        rotateEnemy(); 
    }

    void rotateEnemy()
    {
        transform.Rotate(0, 0, -1);
    }
}
