using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterController : MonoBehaviour, IStartGameListener, IFinishGameListener
    {
        [SerializeField] private GameObject _character; 
        [SerializeField] private GameManager _gameManager;
        private void OnCharacterDeath(GameObject _) => _gameManager.FinishGame();

        void IStartGameListener.OnStartGame()
        {
            _character.GetComponent<HitPointsComponent>().OnHitPointsEmpty += OnCharacterDeath;
        }

        void IFinishGameListener.OnFinishGame()
        {
            _character.GetComponent<HitPointsComponent>().OnHitPointsEmpty -= OnCharacterDeath;
        }
    }
}