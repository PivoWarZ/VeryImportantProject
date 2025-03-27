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
            IsPlayer = true,
            PhysicsLayer = (int)this._bulletConfig.PhysicsLayer,
            Color = this._bulletConfig.Color,
            Damage = this._bulletConfig.Damage,
            Position = _weapon.Position,
            Velocity = _weapon.Rotation * Vector3.up * this._bulletConfig.Speed
        });

    }
}
}
