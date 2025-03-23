using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
public class Canvas : MonoBehaviour
{
    [SerializeField] Button _startButon;

    private void Awake()
    {
        _startButon.gameObject.SetActive(true);
    }
}

}
