using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private GameObject _enemy;

    private float _timeUntilSpawn = 0f;
    [SerializeField]private float _startTime = 0f;
    [SerializeField]private float _secondsBetweenSpawn = 3f;
    // Use this for initialization
    void Start()
    {

    }

    void SpawnEnemy()
    {
            GameObject enemy = Instantiate(_enemy) as GameObject;

            enemy.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        _timeUntilSpawn = Time.time - _startTime;

        if (_timeUntilSpawn >= _secondsBetweenSpawn)
        {
            _startTime = Time.time;
            _timeUntilSpawn = 0;
            _secondsBetweenSpawn = Random.Range(3, 8);
            SpawnEnemy();
        }
    }
}