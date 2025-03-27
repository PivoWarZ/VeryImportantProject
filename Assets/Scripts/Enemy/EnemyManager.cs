using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField] private BulletConfig _bulletConfig;
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private float _spawnTime = 3f;
        [SerializeField] private float _bulletSpeed = 2f;

        private readonly HashSet<GameObject> _activeEnemies = new();
        private int _hitPoints;

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnTime);
                var enemy = _enemyPool.SpawnEnemy();

                if (enemy != null)
                {
                    if (_activeEnemies.Add(enemy))
                    {
                        enemy.GetComponent<HitPointsComponent>().OnHpEmpty += OnDestroyed;
                        enemy.GetComponent<EnemyAttackAgent>().OnFire += OnFire;
                        _hitPoints = enemy.GetComponent<HitPointsComponent>().GetHitPoints();
                    }    
                }
            }
        }

        private void OnDestroyed(GameObject enemy)
        {
            if (_activeEnemies.Remove(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().OnHpEmpty -= OnDestroyed;
                enemy.GetComponent<EnemyAttackAgent>().OnFire -= OnFire;
                enemy.GetComponent<HitPointsComponent>().SetHitPoints(_hitPoints);
                _enemyPool.UnspawnEnemy(enemy);

            }
        }

        private void OnFire(GameObject enemy, Vector2 position, Vector2 direction)
        {
            _bulletSystem.FlyBulletBySample(new BulletSample
            {
                IsPlayer = false,
                PhysicsLayer = (int)_bulletConfig.PhysicsLayer,
                Color = _bulletConfig.Color,
                Damage = _bulletConfig.Damage,
                Position = position,
                Velocity = direction * _bulletConfig.Speed,
            });
        }
    }
}