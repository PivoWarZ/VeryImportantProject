using UnityEngine;

namespace ShootEmUp
{
    public class ShootComponent : MonoBehaviour
    {
        public bool IsFireRequired;

        [SerializeField] private BulletConfig _bulletConfig;
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private WeaponComponent _weapon;

        private void FixedUpdate()
        {
            if (IsFireRequired)
            {
                OnFlyBullet();
                IsFireRequired = false;
            }
        }

        private void OnFlyBullet()
        {
            _bulletSystem.FlyBulletBySample(new BulletSample
            {
                IsPlayer = true,
                PhysicsLayer = (int)_bulletConfig.PhysicsLayer,
                Color = _bulletConfig.Color,
                Damage = _bulletConfig.Damage,
                Position = _weapon.Position,
                Velocity = _weapon.Rotation * Vector3.up * _bulletConfig.Speed
            });
        }
    }
}
