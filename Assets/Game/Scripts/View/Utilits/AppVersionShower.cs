using TMPro;
using UnityEngine;

namespace Utilits
{
    [RequireComponent(typeof(TMP_Text))]
    public class AppVersionShower : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<TMP_Text>().text = Application.version;
        }
    }
}