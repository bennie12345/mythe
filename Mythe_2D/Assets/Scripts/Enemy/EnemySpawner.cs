using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    //spawner for both enemies which randomly spawns one of two enemies
    [SerializeField]private GameObject _flyingEnemy;
    [SerializeField]private GameObject _otherEnemy;
    
    private string _selectedEnemy;

    private float _whichEnemy;
    private float _secondsBetweenSpawn;

    private bool _isSpawning;

    private void Start()
    {
        _whichEnemy = RandomRange(1, 3);
        _isSpawning = true;
        StartCoroutine(SpawnDelay());
    }

    private void EnemyToSpawn()
    {
        if (_whichEnemy <= 2f)
        {
            _selectedEnemy = "BirdEnemy";
        }
        else
        {
            _selectedEnemy = "FishEnemy";
        }
    }

    private void SpawnEnemy()
    {
        _whichEnemy = RandomRange(1, 3);

        ObjectPool.instance.GetObjectForType(_selectedEnemy, true).transform.position = transform.position;
    }

    private void Update()
    {
        EnemyToSpawn();
    }

    private float RandomRange(float min, float max)
    {
        return Random.Range(min, max);
    }

    private IEnumerator SpawnDelay()
    {
        while(_isSpawning)
        {
            _secondsBetweenSpawn = RandomRange(5, 8);
            yield return new WaitForSeconds(_secondsBetweenSpawn);
            SpawnEnemy();
        }
    }
}