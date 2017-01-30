using UnityEngine;
using System.Collections;

public class DeadEnemies : MonoBehaviour
{
    //rotate the dead enemies
    private void FixedUpdate()
    {
        RotateEnemy();
    }

    private void RotateEnemy()
    {
        transform.Rotate(0, 0, -1);
    }
}
