using System;
using UnityEngine;

namespace ShootEmUp
{
    public class GameCycleInput : MonoBehaviour, IUpdateGameListener
    {
        public Action OnStartGame;
        public Action OnPauseGame;
        public Action OnResumeGame;

        private void KeybordInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnStartGame?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnPauseGame?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                OnResumeGame?.Invoke();
            }
        }

        void IUpdateGameListener.OnUpdate(float deltaTime)
        {
            KeybordInput();
        }
    }
}

