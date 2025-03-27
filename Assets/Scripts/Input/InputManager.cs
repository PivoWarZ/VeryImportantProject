using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour
    {
        public float HorizontalDirection { get; private set; }

        [SerializeField] private GameObject _character;
        [SerializeField] private ShootComponent _shootComponent;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _shootComponent.IsFireRequired = true;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                HorizontalDirection = -Vector3.right.x;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                HorizontalDirection = Vector3.right.x;
            }
            else
            {
                HorizontalDirection = 0;
            }
        }
        
        private void FixedUpdate()
        {
            _character.GetComponent<MoveComponent>().MoveByRigidbodyVelocity(new Vector2(HorizontalDirection, 0) * Time.fixedDeltaTime);
        }
    }
}