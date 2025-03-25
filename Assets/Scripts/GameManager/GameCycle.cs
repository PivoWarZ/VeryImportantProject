using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class GameCycle : MonoBehaviour
    {
        private List<IGameIistener> _gameListenersList = new();
        enum Cycle
        {
           NotStarted,
           StartGame,
           PauseGame,
        }

        Cycle CurrentGameCycle;

        private void Update()
        {
            if (Input.anyKeyDown && CurrentGameCycle == Cycle.NotStarted)
            {
                StartGame();
                CurrentGameCycle = Cycle.StartGame;
            }

            if (Input.GetKeyDown(KeyCode.Escape) && CurrentGameCycle == Cycle.StartGame)
            {
                PauseGame();
                CurrentGameCycle = Cycle.PauseGame;
            }

            if (Input.GetKeyDown(KeyCode.Tab) && CurrentGameCycle == Cycle.PauseGame)
            {
                ResumeGame();
                CurrentGameCycle = Cycle.StartGame;
            }
        }

        public void AddGameListener(IGameIistener gameListener)
        {
            _gameListenersList.Add(gameListener);
        }

        public void StartGame()
        {
            Debug.Log("StartGame");
        
            foreach (IGameIistener gameListener in _gameListenersList)
            {
                if (gameListener is IStartGameListener startGameListener)
                { 
                    startGameListener.OnStartGame();
                }    
            }
        }

        public void PauseGame()
        {
            Debug.Log("PauseGame");

            foreach (IGameIistener gameListener in _gameListenersList)
            {
                if (gameListener is IPauseGameListener pauseGameListener)
                { 
                    pauseGameListener.OnPauseGame();
                }
            }
        }

        public void ResumeGame()
        {
            Debug.Log("ResumeGame");

            foreach (IGameIistener gameListener in _gameListenersList)
            {
                if (gameListener is IResumeGameListener resumeGameListener)
                { 
                    resumeGameListener.OnResumeGame();
                }
            }
        }

    }

}
