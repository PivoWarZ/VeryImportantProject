using UnityEngine;

namespace ShootEmUp
{
    public class GameUpdater : MonoBehaviour
    {
        [SerializeField] private GameCycle _gameCycle;

        private void Update()
        {
            float deltaTime = Time.deltaTime;
            _gameCycle.GameUpdate(deltaTime);
        }

        private void FixedUpdate()
        {
            float fixedDeltaTime = Time.fixedDeltaTime;
            _gameCycle.GameFixedUpdate(fixedDeltaTime);
        }

        private void LateUpdate()
        {
            float deltaTime = Time.deltaTime;
            _gameCycle.GameLateUpdate(deltaTime);
        }
    }

}