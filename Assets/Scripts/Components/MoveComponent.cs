using UnityEngine;

namespace ShootEmUp
{
    public sealed class MoveComponent : MonoBehaviour
    {
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private float _speed = 10.0f;

        public void MoveByRigidbodyVelocity(Vector2 vector)
        {
            var nextPosition = rigidbody2D.position + vector * _speed;
            rigidbody2D.MovePosition(nextPosition);
        }
    }
}