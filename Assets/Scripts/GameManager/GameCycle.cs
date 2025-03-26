using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class GameCycle : MonoBehaviour
    {
        private List<IGameIistener> _gameListeners = new();
        private List<IUpdateGameListener> _updateGameListeners = new();
        private List<IFixedUpdateGameListener> _fixedUpdateGameListeners = new();
        private List<ILateUpdateGameListener> _lateUpdateGameListeners = new();

        private enum Cycle
        {
            NotStarted,
            StartGame,
            PauseGame,
            FinishGame,
        }

        private Cycle CurrentGameCycle;

        public void GameUpdate(float deltaTime)
        {
            foreach (var gameListener in _updateGameListeners)
            {
                gameListener.OnUpdate(deltaTime);
            }
        }

        public void GameFixedUpdate(float fixedDeltaTime)
        {
            foreach (var gameListener in _fixedUpdateGameListeners)
            {
                gameListener.OnFixedUpdate(fixedDeltaTime);
            }
        }

        public void GameLateUpdate(float deltaTime)
        {
            foreach (var gameListener in _lateUpdateGameListeners)
            {
                gameListener.OnLateUpdate(deltaTime);
            }
        }


        public void AddGameListener(IGameIistener gameListener)
        {
            _gameListeners.Add(gameListener);

            if (gameListener is IUpdateGameListener updateGameListener)
            {
                _updateGameListeners.Add(updateGameListener);
            }

            if (gameListener is IFixedUpdateGameListener fixedUpdateGameListener)
            {
                _fixedUpdateGameListeners.Add(fixedUpdateGameListener);
            }

            if (gameListener is ILateUpdateGameListener latedUpdateGameListener)
            {
                _lateUpdateGameListeners.Add(latedUpdateGameListener);
            }
        }

        public void StartGame()
        {
            if (CurrentGameCycle != Cycle.NotStarted)
            {
                return;
            }

            Debug.Log("StartGame");
            CurrentGameCycle = Cycle.StartGame;

            foreach (IGameIistener gameListener in _gameListeners)
            {
                if (gameListener is IStartGameListener startGameListener)
                { 
                    startGameListener.OnStartGame();
                }    
            }
        }

        public void PauseGame()
        {
            if (CurrentGameCycle != Cycle.StartGame)
            {
                return;
            }

            Debug.Log("PauseGame");
            CurrentGameCycle = Cycle.PauseGame;

            foreach (IGameIistener gameListener in _gameListeners)
            {
                if (gameListener is IPauseGameListener pauseGameListener)
                { 
                    pauseGameListener.OnPauseGame();
                }
            }
        }

        public void ResumeGame()
        {
            if (CurrentGameCycle != Cycle.PauseGame)
            {
                return;
            }

            Debug.Log("ResumeGame");
            CurrentGameCycle = Cycle.StartGame;

            foreach (IGameIistener gameListener in _gameListeners)
            {
                if (gameListener is IResumeGameListener resumeGameListener)
                { 
                    resumeGameListener.OnResumeGame();
                }
            }
        }

        public void FinishGame()
        {
            Debug.Log("FinishGame");
            CurrentGameCycle = Cycle.FinishGame;

            foreach (IGameIistener gameListener in _gameListeners)
            {
                if (gameListener is IFinishGameListener finishGameListener)
                {
                    finishGameListener.OnFinishGame();
                }
            }
        }
    }
}
