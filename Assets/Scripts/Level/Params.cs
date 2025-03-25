using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed partial class LevelBackground
    {
        [Serializable]
        public sealed class Params
        {
            [SerializeField] public float StartPositionY;
            [SerializeField] public float EndPositionY;
            [SerializeField] public float MovingSpeedY;
        }
    }
}