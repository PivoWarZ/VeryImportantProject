using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp 
{
    public class ResumeButton : MonoBehaviour, IResumeGameListener
    {
        [SerializeField] Button _pauseButton;
        [SerializeField] Button _finishGameButton;

        void IResumeGameListener.OnResumeGame()
        {
            _pauseButton.gameObject.SetActive(true);
            _finishGameButton.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}

