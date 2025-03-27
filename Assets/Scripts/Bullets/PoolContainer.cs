using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class PoolContainer : MonoBehaviour
    {
        [SerializeField] private Transform _poolContainer;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _worldTransform;

        private readonly Queue<Bullet> _bulletsPool = new();

        public Transform GetContainerTransform()
        {
            return this.transform;
        }

        public Transform GetWorldTransform()
        {
            return _worldTransform;
        }

        public Bullet GetBulletInPool()
        {
            if (_bulletsPool.TryDequeue(out Bullet bullet))
            {
                return bullet;
            }
            else
            {
                bullet = Instantiate(_bulletPrefab, _worldTransform);
                return bullet;
            }
        }

        public void AddBulletInPool(Bullet bullet)
        {
            _bulletsPool.Enqueue(bullet);
        }
    }
}
