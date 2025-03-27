using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class HitPointsComponent : MonoBehaviour
    {
        public event Action<GameObject> OnHitPointsOver;

        [SerializeField] private int _hitPoints;

        public bool IsHitPointsExists() 
        {
            return _hitPoints > 0;
        }

        public void TakeDamage(int damage)
        {
            _hitPoints -= damage;

            if (_hitPoints <= 0)
            {
                OnHitPointsOver?.Invoke(gameObject);
            }
        }

        public int GetHitPoints()
        { 
            return _hitPoints;
        }

        public void SetHitPoints(int hitPoints)
        { 
            _hitPoints = hitPoints;
        }
    }
}