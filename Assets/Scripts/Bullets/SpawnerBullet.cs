using ShootEmUp;
using UnityEngine;

public class SpawnerBullet : MonoBehaviour
{
    [SerializeField] private int _spawnCount;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private PoolContainer _container;
    

    private void Awake()
    {
        CreateBulletPool(_spawnCount, _prefab, _container.transform);
    }

    private void CreateBulletPool(int initialCount, Bullet bulletPrefab, Transform pool)
    {
        for (var i = 0; i < initialCount; i++)
        {
            var bullet = Instantiate(bulletPrefab, pool);
            _container.AddBulletInPool(bullet);
        }
    }


}
