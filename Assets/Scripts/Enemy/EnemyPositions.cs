using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPositions : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPositions;
        [SerializeField] private List<Transform> _attackPositions;

        public Transform RandomSpawnPosition()
        {
            return RandomTransform(_spawnPositions);
        }

        public bool TryGetRandomAttackPosition(out Transform attackPosition)
        {
            attackPosition = TakeFreeTransform(_attackPositions);

            if (attackPosition == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void AddAttackPosition(Transform attackposition)
        {
            _attackPositions.Add(attackposition);
        }
        private Transform RandomTransform(Transform[] transforms)
        {
            var index = Random.Range(0, transforms.Length);
                return transforms[index];

        }

        private Transform TakeFreeTransform(List<Transform> transforms)
        {
            Transform position;

            if (transforms.Count == 0)
            {
                return null;
            }

            var index = Random.Range(0, transforms.Count);
            position = transforms[index];
            _attackPositions.Remove(transforms[index]);
            return position;
        }
    }
}