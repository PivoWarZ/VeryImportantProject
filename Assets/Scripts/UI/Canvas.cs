using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class Canvas : MonoBehaviour, IFinishGameListener, IStartGameListener, IResumeGameListener, IPauseGameListener
    {
        [SerializeField] Button _pauseButton;
        [SerializeField] Button _resumeButton;
        [SerializeField] Button _finishGameButton;
        [SerializeField] TextMeshProUGUI _gameOver;

        void IFinishGameListener.OnFinishGame()
        {
            _pauseButton.gameObject.SetActive(false);
            _resumeButton.gameObject.SetActive(false);
            _finishGameButton.gameObject.SetActive(false);
            _gameOver.gameObject.SetActive(true);
        }

        void IStartGameListener.OnStartGame()
        {
            _pauseButton.gameObject.SetActive(true);
        }

        void IPauseGameListener.OnPauseGame()
        {
            _pauseButton.gameObject.SetActive(false);
            _resumeButton.gameObject.SetActive(true);
            _finishGameButton.gameObject.SetActive(true);
        }

        void IResumeGameListener.OnResumeGame()
        {
            _pauseButton.gameObject.SetActive(true);
            _resumeButton.gameObject.SetActive(false);
            _finishGameButton.gameObject.SetActive(false);
        }

    }
}
