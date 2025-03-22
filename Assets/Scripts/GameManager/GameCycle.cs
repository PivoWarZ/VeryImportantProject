using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class GameCycle : MonoBehaviour
    {
        private List<IGameIistener> _gameListenersList = new();

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                StartGame();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
            }
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                ResumeGame();
            }
        }

        public void AddGameListener(IGameIistener gameListener)
        {
            _gameListenersList.Add(gameListener);
        }
        public void StartGame()
        {
            Debug.Log(_gameListenersList.ToString());
            Debug.Log("StartGame");
            foreach (IGameIistener gameListener in _gameListenersList)
            {
                if (gameListener is IStartGameListener startGameListener)
                startGameListener.OnStartGame();
            }
        }

        public void PauseGame()
        {
            Debug.Log("PauseGame");
            foreach (IGameIistener gameListener in _gameListenersList)
            {
                if (gameListener is IPauseGameListener pauseGameListener)
                    pauseGameListener.OnPauseGame();
            }
        }

        public void ResumeGame()
        {
            Debug.Log("ResumeGame");
            foreach (IGameIistener gameListener in _gameListenersList)
            {
                if (gameListener is IResumeGameListener resumeGameListener)
                    resumeGameListener.OnResumeGame();
            }
        }

    }

}
