using UnityEngine;

namespace ShootEmUp
{
    public class GameCycleInstaller : MonoBehaviour
    {
        [SerializeField] GameCycle _gameCycle;
        [SerializeField] EnemyManager _enemyManager;
        [SerializeField] InputManager _inputManager;
        [SerializeField] BulletSystem _bulletSystem;
        [SerializeField] LevelBackground _levelBackGround;
        [SerializeField] KeyBoardInput _keyBoardInput;
        [SerializeField] ShootComponent _shootComponent;
        [SerializeField] CharacterController _characterController;
        [SerializeField] Canvas _canvas;
        [SerializeField] GameCycleInput _gameCycleInput;
        [SerializeField] GameCycleController _gameCycleController;

        private void Start()
        {
            _gameCycle.AddGameListener(_enemyManager);
            _gameCycle.AddGameListener(_inputManager);
            _gameCycle.AddGameListener(_bulletSystem);
            _gameCycle.AddGameListener(_levelBackGround);
            _gameCycle.AddGameListener(_keyBoardInput);
            _gameCycle.AddGameListener(_shootComponent);
            _gameCycle.AddGameListener(_characterController);
            _gameCycle.AddGameListener(_canvas);
            _gameCycle.AddGameListener(_gameCycleInput);
            _gameCycle.AddGameListener(_gameCycleController);
        }
    }
}