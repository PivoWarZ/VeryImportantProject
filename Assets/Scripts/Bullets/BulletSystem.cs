using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : MonoBehaviour, IPauseGameListener, IResumeGameListener, IFixedUpdateGameListener, IFinishGameListener
    {
        [SerializeField] private PoolContainer _poolContainer;
        [SerializeField] private LevelBounds _bulletLevelBounds;
        
        private readonly HashSet<Bullet> _activeBullets = new();
        private readonly List<Bullet> _removeBulletsList = new();

        void IFixedUpdateGameListener.OnFixedUpdate(float fixedDeltaTime)
        {
            _removeBulletsList.Clear();
            _removeBulletsList.AddRange(_activeBullets);

            for (int i = 0, count = _removeBulletsList.Count; i < count; i++)
            {
                var bullet = _removeBulletsList[i];
                if (!_bulletLevelBounds.InBounds(bullet.transform.position))
                {
                    RemoveBullet(bullet);
                }
            }
        }

        public void FlyBulletBySample(BulletSample bulletSample)
        {
            var bullet = _poolContainer.GetBulletInPool();
            bullet.transform.SetParent(_poolContainer.GetWorldTransform());
            bullet.SetPosition(bulletSample.Position);
            bullet.SetColor(bulletSample.Color);
            bullet.SetPhysicsLayer(bulletSample.PhysicsLayer);
            bullet.Damage = bulletSample.Damage;
            bullet.IsPlayer = bulletSample.IsPlayer;
            bullet.SetVelocity(bulletSample.Velocity);

            if (_activeBullets.Add(bullet))
            {
                bullet.OnCollisionEntered += OnBulletCollision;
            }
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            BulletUtils.DealDamage(bullet, collision.gameObject);
            RemoveBullet(bullet);
        }

        private void RemoveBullet(Bullet bullet)
        {
            if (_activeBullets.Remove(bullet))
            {
                bullet.OnCollisionEntered -= OnBulletCollision;
                bullet.transform.SetParent(_poolContainer.GetContainerTransform());
                _poolContainer.AddBulletInPool(bullet);
            }
        }

        void IResumeGameListener.OnResumeGame()
        {
            foreach (var bullet in _activeBullets)
            {
                bullet.GetComponent<Rigidbody2D>().simulated = true;
            }
        }

        void IPauseGameListener.OnPauseGame()
        {
            foreach (var bullet in _activeBullets)
            {
                bullet.GetComponent<Rigidbody2D>().simulated = false;
            }
        }

        void IFinishGameListener.OnFinishGame()
        {
            foreach (var bullet in _activeBullets)
            {
                bullet.OnCollisionEntered -= OnBulletCollision;
                bullet.transform.SetParent(_poolContainer.GetContainerTransform());
                _poolContainer.AddBulletInPool(bullet);
            }
        }
    }
}