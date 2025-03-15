using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : MonoBehaviour
    {
        [SerializeField]
        private int initialCount = 50;
        
        [SerializeField] private Transform container;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Transform worldTransform;
        [SerializeField] private LevelBounds bulletLevelBounds;

        private readonly Queue<Bullet> bulletPool = new();
        private readonly HashSet<Bullet> activeBullets = new();
        private readonly List<Bullet> removeBulletList = new();
        
        private void Awake()
        {
            CreateBulletPool(initialCount, this.bulletPrefab, this.container);
        }
        
        private void FixedUpdate()
        {
            this.removeBulletList.Clear();
            this.removeBulletList.AddRange(this.activeBullets);

            for (int i = 0, count = this.removeBulletList.Count; i < count; i++)
            {
                var bullet = this.removeBulletList[i];
                if (!this.bulletLevelBounds.InBounds(bullet.transform.position))
                {
                    this.RemoveBullet(bullet);
                }
            }
        }

        public void FlyBulletBySample(BulletSample bulletSample)
        {
            if (this.bulletPool.TryDequeue(out var bullet))
            {
                bullet.transform.SetParent(this.worldTransform);
            }
            else
            {
                bullet = Instantiate(this.bulletPrefab, this.worldTransform);
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
                bullet.transform.SetParent(this.container);
                this.bulletPool.Enqueue(bullet);
            }
        }

        private void CreateBulletPool(int initialCount, Bullet bulletPrefab, Transform pool)
        {
            for (var i = 0; i < initialCount; i++)
            {
                var bullet = Instantiate(bulletPrefab, pool);
            }
        }

        public struct BulletSample
        {
            public Vector2 position;
            public Vector2 velocity;
            public Color color;
            public int physicsLayer;
            public int damage;
            public bool isPlayer;
        }
    }
}