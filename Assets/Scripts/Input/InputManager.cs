using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour, IStartGameListener
    {

        [SerializeField]
        private MoveComponent _moveComponent;

        [SerializeField]
        private ShootComponent _shootComponent;

        [SerializeField]
        private KeyBoardInput _keyBoardInput;

        private void OnDisable()
        {
            _keyBoardInput.OnShoot -= _shootComponent.Shoot;
            _keyBoardInput.OnKeyboardInputChanged -= _moveComponent.MoveByRigidbodyVelocity;
        }

        void IStartGameListener.OnStartGame()
        {
            _keyBoardInput.OnShoot += _shootComponent.Shoot;
            _keyBoardInput.OnKeyboardInputChanged += _moveComponent.MoveByRigidbodyVelocity;
        }
    }   
}