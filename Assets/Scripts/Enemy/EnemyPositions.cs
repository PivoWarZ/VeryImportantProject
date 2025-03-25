using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPositions : MonoBehaviour
    {
        [SerializeField]
        private Transform[] spawnPositions;

        [SerializeField]
        private List<Transform> attackPositions;

        public Transform RandomSpawnPosition()
        {
            return this.RandomTransform(this.spawnPositions);
        }

        public bool TryGetRandomAttackPosition(out Transform attackPosition)
        {
            if (GetFreeTransform(attackPositions, out Transform attackposition))
            { 
                return attackPosition = attackposition; 
            }

            attackPosition = null;

            return false;
        }

        public void AddAttackPosition(Transform attackposition)
        {
            attackPositions.Add(attackposition);
            Debug.Log(attackPositions.Count);
        }
        private Transform RandomTransform(Transform[] transforms)
        {
            var index = Random.Range(0, transforms.Length);
                return transforms[index];

        }

        private bool GetFreeTransform(List<Transform> transforms, out Transform attackPosition)
        {
            if (transforms.Count == 0)
            {
                return attackPosition = null;
            }

            var index = Random.Range(0, transforms.Count);
            Debug.DrawRay(transforms[index].position, Vector2.up, Color.yellow, 5f);
            attackPosition = transforms[index];
            attackPositions.Remove(transforms[index]);
            Debug.Log(attackPositions.Count);
            return attackPosition;
        }

    }
}