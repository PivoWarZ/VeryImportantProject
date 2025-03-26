using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class PreparationToStart : MonoBehaviour
    {
        public event Action GameReady;

        [SerializeField] private TextMeshProUGUI _countdown;
        [SerializeField] private Button _startButton;
        [SerializeField] private int _startContdown = 3;
        [SerializeField] private float _waitTime = 1;

        public void Countdown()
        {
            _startButton.gameObject.SetActive(false);
            _countdown.gameObject.SetActive(true);
            StartCoroutine(ReadyForGame());
        }

        private IEnumerator ReadyForGame()
        {
            for (int i = _startContdown; i > 0; i--)
            {
                _countdown.text = _startContdown.ToString();
                yield return new WaitForSeconds(_waitTime);
                _startContdown--;
            }
            _countdown.text = "Ready";
            GameReady?.Invoke();
            yield return new WaitForSeconds(_waitTime);
            _countdown.gameObject.SetActive(false);
            yield break;
        }
    }
}

