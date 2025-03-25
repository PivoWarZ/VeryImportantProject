using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp 
{ 
    public class PauseButton : MonoBehaviour, IPauseGameListener
    {
        [SerializeField] Button _resumeButton;

        void IPauseGameListener.OnPauseGame()
        {
            _resumeButton.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}

