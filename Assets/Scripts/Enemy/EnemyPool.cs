using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [Header("Spawn")]
        [SerializeField]
        private EnemyPositions _enemyPositions;

        [SerializeField]
        private GameObject _character;

        [SerializeField]
        private Transform _worldTransform;

        [Header("Pool")]
        [SerializeField]
        private Transform _container;

        [SerializeField]
        private GameObject _prefab;

        [SerializeField]
        private int _spawnCount = 20;

        private readonly Queue<GameObject> enemyPool = new();
        
        private void Awake()
        {
            for (var i = 0; i < _spawnCount; i++)
            {
                var enemy = Instantiate(this._prefab, this._container);
                this.enemyPool.Enqueue(enemy);
            }

        }

        public GameObject SpawnEnemy()
        {
            if (!this.enemyPool.TryDequeue(out var enemy))
            {
                return null;
            }

            if (_enemyPositions.TryGetRandomAttackPosition(out Transform freeAttackPosition))
            { 
            
                enemy.transform.SetParent(this._worldTransform);

                var spawnPosition = this._enemyPositions.RandomSpawnPosition();

                enemy.transform.position = spawnPosition.position;

                var attackPosition = freeAttackPosition;

                enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);

                enemy.GetComponent<EnemyAttackAgent>().SetTarget(this._character);

                return enemy;
            }

            return null;

        }

        public void UnspawnEnemy(GameObject enemy)
        {
            enemy.transform.SetParent(this._container);
            this.enemyPool.Enqueue(enemy);
        }
    }
}