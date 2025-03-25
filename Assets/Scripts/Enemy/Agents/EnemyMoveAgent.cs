using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent : MonoBehaviour
    {
        public bool IsReached
        {
            get { return this.isReached; }
        }

        public Transform AttackPosition
        {
            get { return attackPosition; }
        }

        [SerializeField] private MoveComponent moveComponent;

        private Vector2 _destination;
       
        private Transform attackPosition;

        private bool isReached;


        public void SetDestination(Transform endPoint)
        {
            this._destination = endPoint.position;
            attackPosition = endPoint;
            this.isReached = false;
        }

        private void FixedUpdate()
        {

            if (this.isReached)
            {
                return;
            }
            
            var vector = this._destination - (Vector2) this.transform.position;
            if (vector.magnitude <= 0.25f)
            {
                this.isReached = true;
                return;
            }

            var direction = vector.normalized * Time.fixedDeltaTime;
            this.moveComponent.MoveByRigidbodyVelocity(direction);
        }
    }
}