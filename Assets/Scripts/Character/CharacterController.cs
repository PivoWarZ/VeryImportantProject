using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterController : MonoBehaviour, IStartGameListener, IFinishGameListener
    {
        [SerializeField] private GameObject _character; 
        [SerializeField] private GameManager _gameManager;
        private void OnCharacterDeath(GameObject gameObject)
        {
            _gameManager.FinishGame(gameObject);
        }

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