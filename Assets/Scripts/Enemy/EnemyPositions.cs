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
            Debug.Log(attackPosition);

            if (attackPosition == null)
            {
                Debug.Log("FALSE");
                return false;
            }
            else
            {
                Debug.Log("RETURN");
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

        //private bool GetFreeTransform(List<Transform> transforms, out Transform attackPosition)
        //{
        //    if (transforms.Count == 0)
        //    {
        //        return attackPosition = null;
        //    }

        //    var index = Random.Range(0, transforms.Count);
        //    attackPosition = transforms[index];
        //    _attackPositions.Remove(transforms[index]);
        //    return attackPosition;
        //}


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