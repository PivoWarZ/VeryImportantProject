using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp 
{
    public class ResumeButton : MonoBehaviour, IResumeGameListener
    {
        [SerializeField] Button _pauseButton;

        void IResumeGameListener.OnResumeGame()
        {
            _pauseButton.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}

