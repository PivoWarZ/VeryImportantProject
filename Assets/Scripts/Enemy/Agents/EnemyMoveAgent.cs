using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent : MonoBehaviour
    {
        [SerializeField] private MoveComponent _moveComponent;

        private Vector2 _destination;
        private Transform _attackPosition;
        private bool isReached;

        public bool IsReached
        {
            get { return isReached; }
        }

        public Transform AttackPosition
        {
            get { return _attackPosition; }
        }

        public void SetDestination(Vector2 endPoint)
        {
            _destination = endPoint;
            isReached = false;
        }

        public void SetAttackPosition(Transform attackPosition)
        { 
            _attackPosition = attackPosition;
        }

        private void FixedUpdate()
        {

            if (isReached)
            {
                return;
            }
            
            var vector = _destination - (Vector2) transform.position;

            if (vector.magnitude <= 0.25f)
            {
                isReached = true;
                return;
            }

            var direction = vector.normalized * Time.fixedDeltaTime;
            _moveComponent.MoveByRigidbodyVelocity(direction);
        }
    }
}