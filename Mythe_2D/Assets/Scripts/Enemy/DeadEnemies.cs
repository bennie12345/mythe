using UnityEngine;
using System.Collections;

public class DeadEnemies : MonoBehaviour {

	void FixedUpdate()
    {
        RotateEnemy();
    }

    void RotateEnemy()
    {
        transform.Rotate(0, 0, -1);
    }
}
