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
            Debug.Log(endPoint);
            _destination = endPoint;
            Debug.Log("des " + _destination);
            //_attackPosition = endPoint;
            Debug.Log(_attackPosition);
            isReached = false;
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