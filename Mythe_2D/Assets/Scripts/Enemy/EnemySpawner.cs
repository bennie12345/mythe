using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private GameObject _flyingEnemy;
    [SerializeField]private GameObject _otherEnemy;
    private GameObject _selectedEnemy;

    private int _whichEnemy = 1;
    private int _secondsBetweenSpawn;

    private float _timeUntilSpawn;
    private float _startTime;

    void Start()
    {
        _startTime = RandomRange(1, 8);
    }

    void EnemyToSpawn()
    {
        if (_whichEnemy == 1)
        {
            _selectedEnemy = _flyingEnemy;
        }
        else
        {
            _selectedEnemy = _otherEnemy;
        }
    }

    void SpawnEnemy()
    {
        _whichEnemy = RandomRange(1, 3);

        GameObject enemy = Instantiate(_selectedEnemy) as GameObject;

        enemy.transform.position = transform.position;
    }

    void SpawnDelay()
    {
        _timeUntilSpawn = Time.time - _startTime;

        if (_timeUntilSpawn >= _secondsBetweenSpawn)
        {
            _startTime = Time.time;
            _timeUntilSpawn = 0;
            _secondsBetweenSpawn = RandomRange(5, 8);
            SpawnEnemy();
        }
    }

    void Update()
    {
        EnemyToSpawn();

        SpawnDelay();
    }

    int RandomRange(int min, int max)
    {
        return Random.Range(min, max);
    }
}