using UnityEngine;

namespace ShootEmUp
{
    public class GameCycle : MonoBehaviour
    {

        [SerializeField] InputManager _inputManager;
        private void StartGame()
        {
            _inputManager.StartGame();
        }
    }

}
