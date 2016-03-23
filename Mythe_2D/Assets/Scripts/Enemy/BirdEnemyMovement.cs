﻿using UnityEngine;
using System.Collections;

public class BirdEnemyMovement : MonoBehaviour {
    [SerializeField] private float _moveSpeed;
    private Vector2 _moveLeft = Vector2.right;

    private float _irregularMovementDuration = 0.5f;
    private float _repeatRate;

    private Animator _animator;

    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    void OnEnable()
    {
        _repeatRate = Random.Range(1, 3);
        InvokeRepeating("StartIrregularMovement", 1, _repeatRate);
    }

	void FixedUpdate () 
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        transform.Translate(_moveLeft * _moveSpeed * Time.deltaTime);
    }

    void StartIrregularMovement()
    {
        if (gameObject.activeSelf)
        {
            StartCoroutine(IrregularMovement());
        }
    }

    IEnumerator IrregularMovement()
    {
        _moveSpeed = -8;
        _animator.speed = 2;
        yield return new WaitForSeconds(_irregularMovementDuration);
        while (_moveSpeed < -4)
        {
            _moveSpeed += 1;
            _animator.speed -= .25f;
            yield return new WaitForSeconds(0.2f);
        }
        
        
    }
}
