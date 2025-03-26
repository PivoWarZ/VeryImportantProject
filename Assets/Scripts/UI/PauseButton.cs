using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp 
{ 
    public class PauseButton : MonoBehaviour, IPauseGameListener
    {
        [SerializeField] Button _resumeButton;
        [SerializeField] Button _finishGameButton;

        void IPauseGameListener.OnPauseGame()
        {
            _finishGameButton.gameObject.SetActive(true);
            _resumeButton.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}

