using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterController : MonoBehaviour
    {
        [SerializeField] private GameObject _character; 
        [SerializeField] private GameManager _gameManager;

        private void OnEnable()
        {
            _character.GetComponent<HitPointsComponent>().OnHpEmpty += OnCharacterDeath;
        }

        private void OnDisable()
        {
            _character.GetComponent<HitPointsComponent>().OnHpEmpty -= OnCharacterDeath;
        }

        private void OnCharacterDeath(GameObject _)
        {
            _gameManager.FinishGame();
        }
    }
}