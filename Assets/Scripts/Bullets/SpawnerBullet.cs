using ShootEmUp;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBullet : MonoBehaviour
{
    [SerializeField] private int _spawnCount;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform _container;
    private readonly Queue<Bullet> _bulletPool = new();

    private void Awake()
    {
        CreateBulletPool(_spawnCount, _prefab, _container);
    }

    private void CreateBulletPool(int initialCount, Bullet bulletPrefab, Transform pool)
    {
        for (var i = 0; i < initialCount; i++)
        {
            var bullet = Instantiate(bulletPrefab, pool);
            AddBulletInPool(bullet);
        }
    }

    public Transform GetContainerTransform()
    {
        return _container;
    }

    public Bullet TryDequeueBulletInPool()
    {
        _bulletPool.TryDequeue(out Bullet bullet);

        return bullet;
    }

    public void AddBulletInPool(Bullet bullet)
    {
        _bulletPool.Enqueue(bullet);
    }
}
