using ShootEmUp;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{ 
    [CreateAssetMenu(fileName = "ConfigInstaller", menuName = "Installers/ConfigInstaller")]
    public partial class ConfigInstaller : ScriptableObjectInstaller<ConfigInstaller>
    {
        [SerializeField] InputConfig _keyBoardInputConfig;
        [SerializeField] BulletConfig _playerBullet;
        public override void InstallBindings()
        {
            Container.Bind<IkeyBoardInputConfig>().To<InputConfig>().FromInstance(_keyBoardInputConfig).AsSingle();
            Container.Bind<BulletConfig>().FromInstance(_playerBullet).AsSingle();
        }
    }
}
