using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private GameObject _flyingEnemy;
    [SerializeField]private GameObject _otherEnemy;
    
    private string _selectedEnemy;

    private float _whichEnemy;
    private float _secondsBetweenSpawn;

    private bool _isSpawning;

    void Start()
    {
        _whichEnemy = RandomRange(1, 3);
        _isSpawning = true;
        StartCoroutine(SpawnDelay());
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

        ObjectPool.instance.GetObjectForType(_selectedEnemy, true).transform.position = transform.position;
    }

    void Update()
    {
        EnemyToSpawn();
    }

    float RandomRange(float min, float max)
    {
        return Random.Range(min, max);
    }

    IEnumerator SpawnDelay()
    {
        while(_isSpawning)
        {
            _secondsBetweenSpawn = RandomRange(5, 8);
            yield return new WaitForSeconds(_secondsBetweenSpawn);
            SpawnEnemy();
        }
    }
}