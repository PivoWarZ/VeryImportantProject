using ShootEmUp;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "WeaponInstaller", menuName = "Installers/WeaponInstaller")]
public class WeaponInstaller : ScriptableObjectInstaller<WeaponInstaller>
{
    [SerializeField] private BulletConfig _playerWeapon;
    [SerializeField] private BulletConfig _enemyWeapon;
    public override void InstallBindings()
    {
        Container.Bind<BulletConfig>().FromInstance(_playerWeapon).WhenInjectedInto<ShootComponent>();
        Container.Bind<BulletConfig>().FromInstance(_enemyWeapon).WhenInjectedInto<EnemyManager>();
    }
}