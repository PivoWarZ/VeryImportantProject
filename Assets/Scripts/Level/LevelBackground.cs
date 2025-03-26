using UnityEngine;

namespace ShootEmUp
{
    public sealed partial class LevelBackground : MonoBehaviour, IPauseGameListener, IResumeGameListener, IFixedUpdateGameListener, IFinishGameListener
    {
        [SerializeField] private Params _params;

        private Transform myTransform;
        private float startPositionY;
        private float endPositionY;
        private float movingSpeedY;
        private float positionX;
        private float positionZ;

        private void Awake()
        {
            startPositionY = _params.StartPositionY;
            endPositionY = _params.EndPositionY;
            movingSpeedY = _params.MovingSpeedY;
            myTransform = transform;
            var position = myTransform.position;
            positionX = position.x;
            positionZ = position.z;
        }


        void IFixedUpdateGameListener.OnFixedUpdate(float fixedDeltaTime)
        {
            if (myTransform.position.y <= endPositionY)
            {
                myTransform.position = new Vector3(
                    positionX,
                    startPositionY,
                    positionZ
                );
            }

            myTransform.position -= new Vector3(
                positionX,
                movingSpeedY * Time.fixedDeltaTime,
                positionZ
            );
        }

        void IPauseGameListener.OnPauseGame()
        {
            movingSpeedY = 0;
        }

        void IResumeGameListener.OnResumeGame()
        {
            movingSpeedY = _params.MovingSpeedY;
        }

        void IFinishGameListener.OnFinishGame()
        {
            movingSpeedY = 0;
        }
    }
}