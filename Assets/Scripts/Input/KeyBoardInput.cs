using ShootEmUp;
using System;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{ 
    public partial class KeyBoardInput : MonoBehaviour, IUpdateGameListener
    {
        public event Action OnShoot;
        public event Action<Vector2> OnKeyboardInputChanged;

        [Inject] IkeyBoardInputConfig _keyBoardConfig;

        void IUpdateGameListener.OnUpdate(float deltaTime)
        {
            KeyBoardInputChanged();
        }

        private void KeyBoardInputChanged()
        {
            if (Input.GetKeyDown(_keyBoardConfig.Shoot))
            {
                Shoot();
            }

            if (Input.GetKey(_keyBoardConfig.Left))
            {
                MovePosition(-Vector2.right * Time.fixedDeltaTime);
            }
            else if (Input.GetKey(_keyBoardConfig.Right))
            {
                MovePosition(Vector2.right * Time.fixedDeltaTime);
            }
            else
            {
                MovePosition(Vector2.zero);
            }
        }

        public void Shoot()
        {
            OnShoot?.Invoke();
        }

        public void MovePosition(Vector2 direction)
        {
            OnKeyboardInputChanged?.Invoke(direction);
        }
    }
}
