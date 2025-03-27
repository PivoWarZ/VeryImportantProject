using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent : MonoBehaviour
    {
        [SerializeField] private MoveComponent _moveComponent;

        private Vector2 _destination;
        private float _targetDistance = 0.25f;
        private bool isReached;

        public bool IsReached
        {
            get { return isReached; }
        }

        public void SetDestination(Vector2 endPoint)
        {
            _destination = endPoint;
            isReached = false;
        }

        private void FixedUpdate()
        {
            if (isReached)
            {
                return;
            }
            
            var vector = _destination - (Vector2) transform.position;

            if (vector.magnitude <= _targetDistance)
            {
                isReached = true;
                return;
            }

            var direction = vector.normalized * Time.fixedDeltaTime;
            _moveComponent.MoveByRigidbodyVelocity(direction);
        }
    }
}