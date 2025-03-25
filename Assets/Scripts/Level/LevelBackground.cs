using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class LevelBackground : MonoBehaviour, IPauseGameListener, IResumeGameListener
    {
        [SerializeField] private Params m_params;

        private Transform myTransform;
        private float startPositionY;
        private float endPositionY;
        private float movingSpeedY;
        private float positionX;
        private float positionZ;

        private void Awake()
        {
            this.startPositionY = this.m_params.m_startPositionY;
            this.endPositionY = this.m_params.m_endPositionY;
            this.movingSpeedY = this.m_params.m_movingSpeedY;
            this.myTransform = this.transform;
            var position = this.myTransform.position;
            this.positionX = position.x;
            this.positionZ = position.z;
        }

        private void FixedUpdate()
        {
            if (this.myTransform.position.y <= this.endPositionY)
            {
                this.myTransform.position = new Vector3(
                    this.positionX,
                    this.startPositionY,
                    this.positionZ
                );
            }

            this.myTransform.position -= new Vector3(
                this.positionX,
                this.movingSpeedY * Time.fixedDeltaTime,
                this.positionZ
            );
        }

        void IPauseGameListener.OnPauseGame()
        {
            this.movingSpeedY = 0;
        }

        void IResumeGameListener.OnResumeGame()
        {
            this.movingSpeedY = this.m_params.m_movingSpeedY;
        }

        [Serializable]
        public sealed class Params
        {
            [SerializeField]
            public float m_startPositionY;

            [SerializeField]
            public float m_endPositionY;

            [SerializeField]
            public float m_movingSpeedY;
        }
    }
}