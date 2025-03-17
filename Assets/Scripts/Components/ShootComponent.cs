using UnityEngine;

namespace ShootEmUp
{
    public class ShootComponent : MonoBehaviour
{
    [SerializeField] private BulletConfig _bulletConfig;
    [SerializeField] private BulletSystem _bulletSystem;
    [SerializeField] private WeaponComponent _weapon;
    public bool isFireRequired;
    private void FixedUpdate()
    {
        if (this.isFireRequired)
        {
            this.OnFlyBullet();
            this.isFireRequired = false;
        }
    }

    private void OnFlyBullet()
    {
        _bulletSystem.FlyBulletBySample(new BulletSample
        {
            isPlayer = true,
            physicsLayer = (int)this._bulletConfig.physicsLayer,
            color = this._bulletConfig.color,
            damage = this._bulletConfig.damage,
            position = _weapon.Position,
            velocity = _weapon.Rotation * Vector3.up * this._bulletConfig.speed
        });

    }
}
}
