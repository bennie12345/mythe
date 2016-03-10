using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private GameObject _flyingEnemy;
    [SerializeField]private GameObject _otherEnemy;
    //private GameObject _selectedEnemy;
    private string _selectedEnemy;

    private float _whichEnemy;
    private float _secondsBetweenSpawn;

    private float _timeUntilSpawn;
    private float _startTime;

    void Start()
    {
        _whichEnemy = RandomRange(1, 3);
        _startTime = RandomRange(1, 5);
    }

    void EnemyToSpawn()
    {
        if (_whichEnemy <= 2f)
        {
            _selectedEnemy = "FlyingEnemy";
        }
        else
        {
            _selectedEnemy = "OtherEnemy";
        }
    }

    void SpawnEnemy()
    {
        _whichEnemy = RandomRange(1, 3);

        //GameObject enemy = Instantiate(_selectedEnemy) as GameObject;
        ObjectPool.instance.GetObjectForType(_selectedEnemy, true).transform.position = transform.position;

        //enemy.transform.position = transform.position;
    }

    void SpawnDelay()
    {
        _timeUntilSpawn = Time.timeSinceLevelLoad - _startTime;

        if (_timeUntilSpawn >= _secondsBetweenSpawn)
        {
            _startTime = Time.timeSinceLevelLoad;
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

    float RandomRange(float min, float max)
    {
        return Random.Range(min, max);
    }
}