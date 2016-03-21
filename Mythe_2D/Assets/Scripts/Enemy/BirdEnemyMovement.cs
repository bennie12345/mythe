using UnityEngine;
using System.Collections;

public class BirdEnemyMovement : MonoBehaviour {
    [SerializeField] private int _moveSpeed;
    private Vector2 _moveLeft = Vector2.right;

	void FixedUpdate () 
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        transform.Translate(_moveLeft * _moveSpeed * Time.deltaTime);
    }
}
