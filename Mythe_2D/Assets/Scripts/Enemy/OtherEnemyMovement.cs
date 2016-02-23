using UnityEngine;
using System.Collections;

public class OtherEnemyMovement : MonoBehaviour
{
    [SerializeField]
    private int _moveSpeed = 1;

    private float _enemyBounds;

    private Vector2 _moveLeft = Vector2.left;
    private Vector2 _moveUpDown = Vector2.down;

    private bool _movingUp;

    void Start()
    {
        _enemyBounds = Random.Range(1, 5);
    }

    void FixedUpdate()
    {
        MoveEnemy();
       
    }

    void MoveEnemy()
    {
        transform.Translate(_moveLeft * _moveSpeed * Time.deltaTime);

        if (_movingUp == false)
        {
            transform.Translate(_moveUpDown * _moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(-_moveUpDown * _moveSpeed * Time.deltaTime);
        }

        if (this.transform.position.y >= _enemyBounds)
        {
            _movingUp = false;
        }

        if (this.transform.position.y <= -_enemyBounds)
        {
            _movingUp = true;
        }
    }

}
