using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : MonoBehaviour, IFixedUpdateGameListener
    {
        public event Action<GameObject, Vector2, Vector2> OnFire;

        [SerializeField] private WeaponComponent _weaponComponent;
        [SerializeField] private EnemyMoveAgent _moveAgent;
        [SerializeField] private float _countdown;

        private HitPointsComponent _target;
        private float _currentTime;

        public void SetTarget(HitPointsComponent target)
        {
            _target = target;
        }

        public void Reset()
        {
            _currentTime = _countdown;
        }

        public void OnFixedUpdate(float fixedDeltaTime)
        {
            if (!_moveAgent.IsReached)
            {
                return;
            }

            if (!_target.IsHitPointsExists())
            {
                return;
            }

            _currentTime -= Time.fixedDeltaTime;

            if (_currentTime <= 0)
            {
                Fire();
                _currentTime += _countdown;
            }
        }

        private void Fire()
        {
            var startPosition = _weaponComponent.Position;
            var vector = (Vector2) _target.transform.position - startPosition;
            var direction = vector.normalized;
            OnFire?.Invoke(gameObject, startPosition, direction);
        }
    }
}