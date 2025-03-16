using ShootEmUp;
using System.Collections.Generic;
using UnityEngine;

public class PoolContainer : MonoBehaviour
{
    private readonly Queue<Bullet> _bulletPool = new();
    public Transform GetContainerTransform()
    {
        return this.transform;
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
