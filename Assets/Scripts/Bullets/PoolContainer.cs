using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class PoolContainer : MonoBehaviour
    {
        [SerializeField] private Transform _poolContainer;

        private readonly Queue<Bullet> _bulletsPool = new();

        public Transform GetContainerTransform()
        {
            return this.transform;
        }

        public Bullet TryDequeueBulletInPool()
        {
            _bulletsPool.TryDequeue(out Bullet bullet);
            return bullet;
        }

        public void AddBulletInPool(Bullet bullet)
        {
            _bulletsPool.Enqueue(bullet);
        }
    }
}
