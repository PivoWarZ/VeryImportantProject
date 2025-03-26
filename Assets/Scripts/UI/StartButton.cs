using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class StartButton : MonoBehaviour, IStartGameListener
    {
        [SerializeField] private Button _pauseButton;

        void IStartGameListener.OnStartGame()
        {
            _pauseButton.gameObject.SetActive(true);
        }
    }

}
