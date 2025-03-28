using UnityEngine;

namespace ShootEmUp
{
    public class SpawnerBullet : MonoBehaviour
    {
        [SerializeField] private int _spawnCount;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private PoolContainer _poolContainer;
    
        private void Awake()
        {
            CreateBulletPool(_spawnCount, _bulletPrefab, _poolContainer.transform);
        }

        private void CreateBulletPool(int initialCount, Bullet bulletPrefab, Transform pool)
        {
            for (var i = 0; i < initialCount; i++)
            {
                var bullet = Instantiate(bulletPrefab, pool);
                _poolContainer.AddBulletInPool(bullet);
            }
        }


    }
}
