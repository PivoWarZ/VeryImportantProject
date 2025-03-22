using System;
using UnityEngine;

public class KeyBoardInput : MonoBehaviour
{

    public event Action OnShoot;
    public event Action<Vector2> OnKeyboardInputChanged;
    private void Update()
    {
        KeyBoardInputChanged();
    }

    private void KeyBoardInputChanged()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            OnKeyboardInputChanged(-Vector2.right * Time.fixedDeltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            OnKeyboardInputChanged(Vector2.right * Time.fixedDeltaTime);
        }
        else
        {
            OnKeyboardInputChanged(Vector2.zero);
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

