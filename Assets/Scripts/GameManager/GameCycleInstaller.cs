using ShootEmUp;
using UnityEngine;

public class GameCycleInstaller : MonoBehaviour
{
    [SerializeField] GameCycle _gameCycle;
    [SerializeField] EnemyManager _enemyManager;
    [SerializeField] InputManager _inputManager;
    private void Start()
    {
        _gameCycle.AddGameListener(_enemyManager);
        _gameCycle.AddGameListener(_inputManager);

    }
}
