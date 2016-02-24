using UnityEngine;
using System.Collections;

public class OtherEnemyMovement : MonoBehaviour
{
    [SerializeField]
    private int _moveSpeed = 1;

    private int _updownMoveSpeed;

    private int _enemyBounds;

    private Vector2 _moveLeft = Vector2.left;
    private Vector2 _moveUpDown = Vector2.down;

    private bool _movingUp;

    void Start()
    {
        _enemyBounds = RandomRange(1, 5);
        _updownMoveSpeed = RandomRange(3, 7);
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
            transform.Translate(_moveUpDown * _updownMoveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(-_moveUpDown * _updownMoveSpeed * Time.deltaTime);
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

    int RandomRange(int min, int max)
    {
        return Random.Range(min, max);
    }

}
