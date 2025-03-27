using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour
    {
        public event Action <Vector2> OnInputChanged;
        public event Action OnShootKeyDown;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnShootKeyDown?.Invoke();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                OnInputChanged?.Invoke(-Vector2.right);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                OnInputChanged?.Invoke(Vector2.right);
            }
            else
            {
                OnInputChanged?.Invoke(Vector2.zero);
            }
        }
    }
}