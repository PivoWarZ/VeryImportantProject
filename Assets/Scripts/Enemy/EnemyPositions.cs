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

        public List<Transform> GetAttackPosition() => attackPositions;

        public Transform RandomSpawnPosition()
        {
            return this.RandomTransform(this.spawnPositions);
        }

        public Transform RandomAttackPosition()
        {
            return this.RandomFreeTransform(this.attackPositions);
        }

        private Transform RandomTransform(Transform[] transforms)
        {
            var index = Random.Range(0, transforms.Length);
                return transforms[index];

        }

        private Transform RandomFreeTransform(List<Transform> transforms)
        {
            var index = Random.Range(0, transforms.Count);
            RaycastHit2D hit = Physics2D.Raycast(transforms[index].position, -Vector3.forward, 1f);
            Debug.DrawRay(transforms[index].position, Vector2.up, Color.yellow, 5f);
            Debug.Log(hit.collider);
            if (!hit)
            {
                return transforms[index];
            }
            else
            {
                int count = 0;
                while (hit)
                {
                    count++;
                    Debug.Log("Count  =  " + count);
                    Debug.Log("Index  =  " + index);
                    index++;

                    if (index >= transforms.Count-1)
                    { 
                        index = 0;
                    }

                    hit = Physics2D.Raycast(transforms[index].position, -Vector3.forward, 1f);
                }

                return transforms[index];
            }


        }
    }
}