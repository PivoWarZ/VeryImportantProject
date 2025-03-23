using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour, IStartGameListener, IPauseGameListener, IResumeGameListener
    {

        [SerializeField]
        private MoveComponent _moveComponent;

        [SerializeField]
        private ShootComponent _shootComponent;

        [SerializeField]
        private KeyBoardInput _keyBoardInput;

        private void OnDisable()
        {
            OutControl();
        }

        void IPauseGameListener.OnPauseGame()
        {
            OutControl();
        }

        void IResumeGameListener.OnResumeGame()
        {
            TakeControl();
        }

        void IStartGameListener.OnStartGame()
        {
            TakeControl();
        }

        private void TakeControl()
        {
            _keyBoardInput.OnShoot += _shootComponent.Shoot;
            _keyBoardInput.OnKeyboardInputChanged += _moveComponent.MoveByRigidbodyVelocity;
        }

        private void OutControl()
        {
            _keyBoardInput.OnShoot -= _shootComponent.Shoot;
            _keyBoardInput.OnKeyboardInputChanged -= _moveComponent.MoveByRigidbodyVelocity;
        }
    }   
}