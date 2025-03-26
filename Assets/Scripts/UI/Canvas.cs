using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class Canvas : MonoBehaviour, IFinishGameListener
    {
        [SerializeField] Button _startButon;
        [SerializeField] Button _pauseButton;
        [SerializeField] Button _resumeButton;
        [SerializeField] Button _finishGameButton;
        [SerializeField] TextMeshProUGUI _gameOver;

        private void Awake()
        {
            _startButon.gameObject.SetActive(true);
        }

        void IFinishGameListener.OnFinishGame()
        {
            _gameOver.gameObject.SetActive(true);
            _pauseButton.gameObject.SetActive(false);
            _resumeButton.gameObject.SetActive(false);
            _finishGameButton.gameObject.SetActive(false);
        }
    }
}
