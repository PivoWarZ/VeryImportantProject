using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] GameCycle _gameCycle;
        public void FinishGame(GameObject gameObject)
        {
            Debug.Log("Game over!");
            _gameCycle.FinishGame();
            gameObject.SetActive(false);
        }
    }
}