using ShootEmUp;
using System;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ConfigInstaller", menuName = "Installers/ConfigInstaller")]
public class ConfigInstaller : ScriptableObjectInstaller<ConfigInstaller>
{
    [SerializeField] InputConfig _keyBoardInputConfig;
    public override void InstallBindings()
    {
        Container.Bind<IkeyBoardInputConfig>().To<InputConfig>().FromInstance(_keyBoardInputConfig);
    }

    [Serializable]
    public class InputConfig : IkeyBoardInputConfig
    {
        [SerializeField] private KeyCode _shoot;
        [SerializeField] private KeyCode _left;
        [SerializeField] private KeyCode _right;

        public KeyCode Shoot => _shoot;
        public KeyCode Left => _left;
        public KeyCode Right => _right;
    }
}