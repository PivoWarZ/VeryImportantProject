using NUnit.Framework.Constraints;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour
    {
        public float HorizontalDirection { get; private set; }

        [SerializeField]
        private GameObject _character;

        [SerializeField]
        private ShootComponent _shootComponent;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _shootComponent.isFireRequired = true;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.HorizontalDirection = -Vector3.right.x;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                this.HorizontalDirection = Vector3.right.x;
            }
            else
            {
                this.HorizontalDirection = 0;
            }
        }
        
        private void FixedUpdate()
        {
            this._character.GetComponent<MoveComponent>().MoveByRigidbodyVelocity(new Vector2(this.HorizontalDirection, 0) * Time.fixedDeltaTime);
        }
    }
}