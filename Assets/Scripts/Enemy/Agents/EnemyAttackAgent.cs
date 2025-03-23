using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : MonoBehaviour
    {
        public delegate void FireHandler(GameObject enemy, Vector2 position, Vector2 direction);

        public event FireHandler OnFire;

        [SerializeField] private WeaponComponent _weaponComponent;
        [SerializeField] private EnemyMoveAgent _moveAgent;
        [SerializeField] private float _countdown;

        private GameObject _target;
        private float currentTime;

        public void SetTarget(GameObject target)
        {
            this._target = target;
        }

        public void Reset()
        {
            this.currentTime = this._countdown;
        }

        private void FixedUpdate()
        {
            if (!this._moveAgent.IsReached)
            {
                return;
            }
            
            if (!this._target.GetComponent<HitPointsComponent>().IsHitPointsExists())
            {
                return;
            }

            this.currentTime -= Time.fixedDeltaTime;
            if (this.currentTime <= 0)
            {
                this.Fire();
                this.currentTime += this._countdown;
            }
        }

        private void Fire()
        {
            var startPosition = this._weaponComponent.Position;
            var vector = (Vector2) this._target.transform.position - startPosition;
            var direction = vector.normalized;
            this.OnFire?.Invoke(this.gameObject, startPosition, direction);
        }
    }
}