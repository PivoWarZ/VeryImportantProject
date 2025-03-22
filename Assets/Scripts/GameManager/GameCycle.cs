using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class GameCycle : MonoBehaviour
    {
        private List<IStartGameListener> _startList = new();

        public void StartGame()
        {
            for (int i = 0; i < _startList.Count; i++)
            {
                IStartGameListener IStartGameListener = _startList[i];
                IStartGameListener.OnStartGame();
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                StartGame();
            }
        }

        public void AddStartGameListener(IStartGameListener startGameListener)
        {
            _startList.Add(startGameListener);
        }
    }

}
