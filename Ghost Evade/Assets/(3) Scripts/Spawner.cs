using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Object Lists")]
    [SerializeField] private Obstacle[] _obstacles;
    [SerializeField] private Obstacle[] _goodies;

    [Header("Spawn Settings")]
    [SerializeField, Range(0, 100)] private float _goodieChance = 10;
    [SerializeField] private Vector2 _spawnRange;
    [SerializeField] private Vector2 _spawnDir;

    [Header("Spawn Timer")]
    [SerializeField] private float _spawnRate = 3;
    [SerializeField] private float _spawnRateMin = 0.5f;
    [SerializeField] private float _spawnRampUp = 0.01f;
    private float _timeSinceLastSpawned = 0;

    private void Update()
    {
        if (_obstacles.Length <= 0 || GameManager.Instance.IsDead) return;

        _timeSinceLastSpawned += Time.deltaTime;

        if (_timeSinceLastSpawned < _spawnRate) return;

        float _goodieRoll = Random.Range(0, 100);

        if (_goodieRoll < _goodieChance) SpawnGoodie();
        else SpawnObstacle();
    }

    private void SpawnObstacle()
    {
        Vector3 range = new Vector3(Random.Range(-_spawnRange.x, _spawnRange.x), Random.Range(-_spawnRange.y, _spawnRange.y), 0);
        Obstacle obs = Instantiate(_obstacles[Random.Range(0, _obstacles.Length)], transform.position + range, Quaternion.identity); //Sets a local script variable to a new instance.
        obs.SetDirection(_spawnDir); //Sets the direction.

        _timeSinceLastSpawned = 0;

        if (_spawnRate > _spawnRateMin) _spawnRate -= _spawnRampUp;
    }

    private void SpawnGoodie()
    {
        Vector3 range = new Vector3(Random.Range(-_spawnRange.x, _spawnRange.x), Random.Range(-_spawnRange.y, _spawnRange.y), 0);
        Obstacle good = Instantiate(_goodies[Random.Range(0, _goodies.Length)], transform.position + range, Quaternion.identity); //Sets a local script variable to a new instance.
        good.SetDirection(_spawnDir); //Sets the direction.

        _timeSinceLastSpawned = 0;

        if (_spawnRate > _spawnRateMin) _spawnRate -= _spawnRampUp;
    }
}
