using System.Collections;
using UnityEngine;
using Zenject;

public class EnemiesSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private StateMachine _enemy;

    [Header("Spawner Settings")]
    [SerializeField] private float _spawnRate;
    [SerializeField] private int _spawnAmount;
    [SerializeField] private float _spawnRadious;

    private Transform _centreOfCircle;
    private UniversalFactory _enemyFactory;

    private float _spawnTimer;
    private bool _canSpawn = true;

    [Inject] 
    private void Construct(PlayerController player, UniversalFactory factory) {
        _centreOfCircle = player.transform;
        _enemyFactory = factory;
    }

    private void Start() {
        _spawnTimer = 0;
        _canSpawn = true;
    }

    private void Update() {
        if (_spawnTimer > 0) { 
            _spawnTimer -= Time.deltaTime;
        }

        if (_spawnTimer <= 0 && _canSpawn) { 
            _canSpawn = false;
            StopAllCoroutines();
            StartCoroutine(SpawnEnemies());
        }
    }

    private IEnumerator SpawnEnemies() {
        for (int i = 0; i < _spawnAmount; i++) {
            Vector3 spawnPos = GetSpawnPointOutsideRadious();
            _enemyFactory.Create<StateMachine>(_enemy, spawnPos, Quaternion.identity, transform);
            yield return null;
        }

        _spawnTimer = _spawnRate;
        _canSpawn = true;
    }

    private Vector3 GetSpawnPointOutsideRadious() {
        float randomAngle = Random.Range(0f, Mathf.PI * 2f); // Рандомний кут в радіанах

        Vector3 spawnPosition = new Vector3(
            Mathf.Cos(randomAngle),
            0f,
            Mathf.Sin(randomAngle)
        ) * Random.Range(20f, 30f);

        spawnPosition += _centreOfCircle.position;
        spawnPosition.y = _enemy.transform.position.y;

        return spawnPosition;
    }
}
