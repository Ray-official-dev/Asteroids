
using UnityEngine;

namespace Game.Root
{
    [CreateAssetMenu(fileName = "MPA/Core/AppSettingsConfig")]
    public class AppSettingsConfig : ScriptableObject
    {
        [SerializeField, Min(0)] private int _targetFrameRate;

        public void Apply()
        {
            Application.targetFrameRate = _targetFrameRate;
        }
    }
}