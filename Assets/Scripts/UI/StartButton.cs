using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class StartButton : MonoBehaviour, IStartGameListener
    {
        [SerializeField] Button _pauseButton;
        void IStartGameListener.OnStartGame()
        {
            _pauseButton.gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
    }

}
