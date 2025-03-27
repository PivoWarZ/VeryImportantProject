using ShootEmUp;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] InputManager _inputManager;
    [SerializeField] MoveComponent _moveComponent;
    [SerializeField] ShootComponent _shootComponent;

    private void OnEnable()
    {
        _inputManager.OnShootKeyDown += _shootComponent.NeedShoot;
        _inputManager.OnInputChanged += _moveComponent.MoveByRigidbodyVelocity;
    }

    private void OnDisable()
    {
        _inputManager.OnShootKeyDown -= _shootComponent.NeedShoot;
        _inputManager.OnInputChanged -= _moveComponent.MoveByRigidbodyVelocity;
    }
}
