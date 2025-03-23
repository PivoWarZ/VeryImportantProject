using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : MonoBehaviour, IPauseGameListener, IResumeGameListener
    {

        [SerializeField] private PoolContainer _poolContainer;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _worldTransform;
        [SerializeField] private LevelBounds _bulletLevelBounds;
        
        private readonly HashSet<Bullet> activeBullets = new();
        private readonly List<Bullet> removeBulletList = new();
        private void FixedUpdate()
        {
            this.removeBulletList.Clear();
            this.removeBulletList.AddRange(this.activeBullets);

            for (int i = 0, count = this.removeBulletList.Count; i < count; i++)
            {
                var bullet = this.removeBulletList[i];
                if (!this._bulletLevelBounds.InBounds(bullet.transform.position))
                {
                    this.RemoveBullet(bullet);
                }
            }
        }
        public void FlyBulletBySample(BulletSample bulletSample)
        {
            var bullet = _poolContainer.TryDequeueBulletInPool();

            if (bullet)
            {
                bullet.transform.SetParent(this._worldTransform);
            }
            else
            {
                bullet = Instantiate(this._bulletPrefab, this._worldTransform);
            }

            bullet.SetPosition(bulletSample.position);
            bullet.SetColor(bulletSample.color);
            bullet.SetPhysicsLayer(bulletSample.physicsLayer);
            bullet.damage = bulletSample.damage;
            bullet.isPlayer = bulletSample.isPlayer;
            bullet.SetVelocity(bulletSample.velocity);

            if (this.activeBullets.Add(bullet))
            {
                bullet.OnCollisionEntered += this.OnBulletCollision;
            }
        }
        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            BulletUtils.DealDamage(bullet, collision.gameObject);
            this.RemoveBullet(bullet);
        }

        private void RemoveBullet(Bullet bullet)
        {
            if (this.activeBullets.Remove(bullet))
            {
                bullet.OnCollisionEntered -= this.OnBulletCollision;
                bullet.transform.SetParent(_poolContainer.GetContainerTransform());
                _poolContainer.AddBulletInPool(bullet);
            }
        }

        void IResumeGameListener.OnResumeGame()
        {
            foreach (var bullet in activeBullets)
            {
                bullet.GetComponent<Rigidbody2D>().simulated = true;
            }
        }

        void IPauseGameListener.OnPauseGame()
        {
            foreach (var bullet in activeBullets)
            {
                bullet.GetComponent<Rigidbody2D>().simulated = false;
            }
        }
    }
}