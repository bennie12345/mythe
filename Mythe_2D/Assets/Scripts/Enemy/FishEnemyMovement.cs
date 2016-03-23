using UnityEngine;
using System.Collections;

public class FishEnemyMovement : MonoBehaviour
{
    [SerializeField]
    private int _moveSpeed = 1;
    //private int _updownMoveSpeed;
    

    private Vector2 _moveLeft = Vector2.left;
    private Vector2 _targetPos;

    private bool _movingUp;

    private float _smoothMoveSpeed = .75f;
    private float _enemyBounds;
    private float _enemyBoundsOffset = 0.5f;

    void Start()
    {
        _enemyBounds = 4;
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
            _targetPos = new Vector2(transform.position.x, -_enemyBounds);
            transform.position = Vector2.Lerp(transform.position, _targetPos, Time.deltaTime/2 * _smoothMoveSpeed);
        }
        else
        {
            //transform.Translate(-_moveUpDown * _updownMoveSpeed * Time.deltaTime);
            _targetPos = new Vector2(transform.position.x, _enemyBounds);
            transform.position = Vector2.Lerp(transform.position, _targetPos, Time.deltaTime/2 * _smoothMoveSpeed);
        }

        if (this.transform.position.y >= _enemyBounds - _enemyBoundsOffset)
        {
            _movingUp = false;
        }

        if (this.transform.position.y <= -_enemyBounds + _enemyBoundsOffset)
        {
            _movingUp = true;
        }
    }

    int RandomRange(int min, int max)
    {
        return Random.Range(min, max);
    }

}
