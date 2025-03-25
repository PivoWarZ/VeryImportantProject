using ShootEmUp;
using System;
using UnityEngine;

public class KeyBoardInput : MonoBehaviour, IUpdateGameListener
{
    public event Action OnShoot;
    public event Action<Vector2> OnKeyboardInputChanged;

    void IUpdateGameListener.OnUpdate(float deltaTime)
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
            MovePosition(-Vector2.right * Time.fixedDeltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
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