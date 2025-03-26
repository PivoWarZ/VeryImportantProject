using ShootEmUp;
using UnityEngine;

public class GameCycleController : MonoBehaviour, IStartGameListener, IFinishGameListener
{
    [SerializeField] GameCycle _gameCycle;
    [SerializeField] GameCycleInput _input;
    [SerializeField] PreparationToStart _prepareToStart;

    private void Awake()
    {
        _prepareToStart.GameReady += _gameCycle.StartGame;  
    }
    void IStartGameListener.OnStartGame()
    {
        _input.OnPauseGame += _gameCycle.PauseGame;
        _input.OnResumeGame += _gameCycle.ResumeGame;
    }

    void IFinishGameListener.OnFinishGame()
    {
        _prepareToStart.GameReady -= _gameCycle.StartGame;
        _input.OnPauseGame -= _gameCycle.PauseGame;
        _input.OnResumeGame -= _gameCycle.ResumeGame;
    }

}
