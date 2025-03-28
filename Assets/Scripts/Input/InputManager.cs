using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour, IStartGameListener, IPauseGameListener, IResumeGameListener, IFinishGameListener
    {
        [Inject] private MoveComponent _moveComponent;
        [Inject] private ShootComponent _shootComponent;
        [Inject] private KeyBoardInput _keyBoardInput;

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
        void IFinishGameListener.OnFinishGame()
        {
           OutControl();
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