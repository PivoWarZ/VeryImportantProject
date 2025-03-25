using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour, IStartGameListener, IPauseGameListener, IResumeGameListener
    {
        [SerializeField] 
        private BulletConfig _bulletConfig;

        [SerializeField]
        private EnemyPool _enemyPool;

        [SerializeField]
        private BulletSystem _bulletSystem;

        [SerializeField]
        private float _spawnTime = 3f;

        private readonly HashSet<GameObject> _activeEnemies = new();

        private int _hitPoints;

        private IEnumerator CourutineToSpawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnTime);
                var enemy = this._enemyPool.SpawnEnemy();
                if (enemy != null)
                {
                    if (this._activeEnemies.Add(enemy))
                    {
                        enemy.GetComponent<HitPointsComponent>().hpEmpty += this.OnDestroyed;
                        enemy.GetComponent<EnemyAttackAgent>().OnFire += this.OnFire;
                        _hitPoints = enemy.GetComponent<HitPointsComponent>().GetHitPoints();
                    }
                }
            }
        }

        private void OnDestroyed(GameObject enemy)
        {

            if (_activeEnemies.Remove(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().hpEmpty -= this.OnDestroyed;
                enemy.GetComponent<EnemyAttackAgent>().OnFire -= this.OnFire;
                enemy.GetComponent<HitPointsComponent>().SetHitPoints(_hitPoints);
                _enemyPool.UnspawnEnemy(enemy);

            }
        }

        private void OnFire(GameObject enemy, Vector2 position, Vector2 direction)
        {
            _bulletSystem.FlyBulletBySample(new BulletSample
            {
                isPlayer = false,
                physicsLayer = (int)this._bulletConfig.physicsLayer,
                color = _bulletConfig.color,
                damage = this._bulletConfig.damage,
                position = position,
                velocity = direction * _bulletConfig.speed,
            });
        }

        private IEnumerator StartAfterPause()
        { 
            var startTime = _spawnTime;
            _spawnTime = Time.time % _spawnTime;
            StartCoroutine(CourutineToSpawn());
            yield return new WaitForSeconds(_spawnTime);
            _spawnTime = startTime;

        }

        void IStartGameListener.OnStartGame()
        {
            StartCoroutine(CourutineToSpawn());
        }

        void IPauseGameListener.OnPauseGame()
        {
            StopAllCoroutines();

            foreach (var enemy in _activeEnemies)
            {
                enemy.GetComponent<EnemyAttackAgent>().OnFire -= this.OnFire;
                enemy.GetComponent<Rigidbody2D>().simulated = false;
            }
        }

        void IResumeGameListener.OnResumeGame()
        {
            StartCoroutine(StartAfterPause());

            foreach (var enemy in _activeEnemies)
            {
                enemy.GetComponent<EnemyAttackAgent>().OnFire += this.OnFire;
                enemy.GetComponent<Rigidbody2D>().simulated = true;
            }
        }
    }
}