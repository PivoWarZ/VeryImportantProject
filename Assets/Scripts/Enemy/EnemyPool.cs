using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [Header("Spawn")]
        [SerializeField] private EnemyPositions _enemyPositions;
        [SerializeField] private HitPointsComponent _characterHitComponent;
        [SerializeField] private Transform _worldTransform;

        [Header("Pool")]
        [SerializeField] private Transform _container;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _spawnCount = 1;

        private readonly Queue<GameObject> _enemysPool = new();
        
        private void Awake()
        {
            for (var i = 0; i < _spawnCount; i++)
            {
                var enemy = Instantiate(_prefab, _container);
                _enemysPool.Enqueue(enemy);
            }
        }

        public GameObject SpawnEnemy()
        {
            if (!_enemysPool.TryDequeue(out var enemy))
            {
                return null;
            }

            var spawnPosition = _enemyPositions.RandomSpawnPosition();
            var attackPosition = _enemyPositions.RandomAttackPosition();
            enemy.transform.SetParent(_worldTransform);
            enemy.transform.position = spawnPosition.position;
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);
            enemy.GetComponent<EnemyAttackAgent>().SetTarget(_characterHitComponent);
            return enemy;
        }

        public void UnspawnEnemy(GameObject enemy)
        {
            enemy.transform.SetParent(_container);
            _enemysPool.Enqueue(enemy);
        }
    }
}