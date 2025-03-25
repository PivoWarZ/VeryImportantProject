using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [Header("Spawn")]
        [SerializeField] private EnemyPositions _enemyPositions;
        [SerializeField] private GameObject _character;
        [SerializeField] private Transform _worldTransform;

        [Header("Pool")]
        [SerializeField] private Transform _container;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _spawnCount = 20;

        private readonly Queue<GameObject> _enemyPool = new();
        
        private void Awake()
        {
            for (var i = 0; i < _spawnCount; i++)
            {
                var enemy = Instantiate(_prefab, _container);
                _enemyPool.Enqueue(enemy);
            }
        }

        public GameObject SpawnEnemy()
        {
            Debug.Log("Spawn");
            if (!_enemyPool.TryDequeue(out var enemy))
            {
                Debug.Log("TryDequeue");
                return null;
            }

            if (_enemyPositions.TryGetRandomAttackPosition(out Transform attackPosition))
            {
                Debug.Log("AttackPosition = " + attackPosition.position);
                enemy.transform.SetParent(_worldTransform);
                var spawnPosition = _enemyPositions.RandomSpawnPosition();
                enemy.transform.position = spawnPosition.position;
                enemy.GetComponent<EnemyAttackAgent>().SetTarget(_character);
                enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);
                return enemy;
            }
            else
            {
                Debug.Log("SpawnNULL");
                return null;
            }
        }

        public void UnspawnEnemy(GameObject enemy)
        {
            var atttackPosition = enemy.GetComponent<EnemyMoveAgent>().AttackPosition;
            _enemyPositions.AddAttackPosition(atttackPosition);
            enemy.transform.SetParent(this._container);
            this._enemyPool.Enqueue(enemy);
        }
    }
}