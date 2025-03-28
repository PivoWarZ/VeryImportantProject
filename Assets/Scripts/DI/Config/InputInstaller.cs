using ShootEmUp;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{ 
    [CreateAssetMenu(fileName = "ConfigInstaller", menuName = "Installers/ConfigInstaller")]
    public partial class ConfigInstaller : ScriptableObjectInstaller<ConfigInstaller>
    {
        [SerializeField] InputConfig _keyBoardInputConfig;
        public override void InstallBindings()
        {
            Container.Bind<IkeyBoardInputConfig>().To<InputConfig>().FromInstance(_keyBoardInputConfig).AsSingle();
        }
    }
}
