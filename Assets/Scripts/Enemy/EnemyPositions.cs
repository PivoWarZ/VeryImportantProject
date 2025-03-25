using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
            if (TryGetFreeTransform(attackPositions, out Transform freePosition))
            { 
                return attackPosition = freePosition; 
            }

            attackPosition = null;
            return false;
        }

        private Transform RandomTransform(Transform[] transforms)
        {
            var index = Random.Range(0, transforms.Length);
                return transforms[index];

        }

        private bool TryGetFreeTransform(List<Transform> transforms, out Transform freePosition)
        {
            if (transforms.Count == 0)
            {
                return freePosition = null;
            }
            var index = Random.Range(0, transforms.Count);
            RaycastHit2D hit = Physics2D.Raycast(transforms[index].position, -Vector3.forward, 1f);
            Debug.DrawRay(transforms[index].position, Vector2.up, Color.yellow, 5f);
            Debug.Log(hit.collider);

            if (!hit)
            {
                freePosition = transforms[index];
                transforms.Remove(transforms[index]);
                Debug.Log(transforms.Count);
                return freePosition;
            }
            else
            {
                foreach (var position in transforms)
                {
                    hit = Physics2D.Raycast(position.position, -Vector2.up, 1f);
                    Debug.DrawRay(position.position, Vector2.up, Color.yellow, 5f);

                    if (!hit)
                    {
                        freePosition = position;
                        transforms.Remove(position);
                        Debug.Log(transforms.Count);
                        return freePosition;
                    }
                }

            }
            Debug.Log(transforms.Count);
            return freePosition = null;
        }

    }
}