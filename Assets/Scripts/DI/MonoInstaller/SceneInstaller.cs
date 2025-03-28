using System.ComponentModel;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{ 
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private ShootComponent _ShootComponent;
        [SerializeField] private KeyBoardInput _keyBoardInput;
        public override void InstallBindings()
        {
            Container.BindInstance(_moveComponent).AsSingle();
            Container.BindInstance(_ShootComponent).AsSingle();
            Container.BindInstance(_keyBoardInput).AsSingle();
        }
    }
}