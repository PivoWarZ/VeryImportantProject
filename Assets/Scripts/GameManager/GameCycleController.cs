using ShootEmUp;
using UnityEngine;

public class GameCycleController : MonoBehaviour, IStartGameListener, IFinishGameListener
{
    [SerializeField] GameCycle _gameCycle;
    [SerializeField] GameCycleInput _input;
    void IStartGameListener.OnStartGame()
    {
        _input.OnStartGame += _gameCycle.StartGame;
        _input.OnPauseGame += _gameCycle.PauseGame;
        _input.OnResumeGame += _gameCycle.ResumeGame;
    }

    void IFinishGameListener.OnFinishGame()
    {
        _input.OnStartGame -= _gameCycle.StartGame;
        _input.OnPauseGame -= _gameCycle.PauseGame;
        _input.OnResumeGame -= _gameCycle.ResumeGame;
    }

}
