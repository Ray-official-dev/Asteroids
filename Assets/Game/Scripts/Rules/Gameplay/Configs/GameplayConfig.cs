using Game.Input;
using Game.View;
using UnityEngine;

namespace Game.GameplayRules
{
    [CreateAssetMenu(menuName = Constans.CONFIGS_PATH + "Gameplay/Rules")]
    public class GameplayConfig : ScriptableObject
    {
        public float PausedTimeScale => _pausedTimeScale;
        public float GameOverDelay => _gameOverDelay;
        public LevelConfig[] Levels => _levels;

        [SerializeField] private LevelConfig[] _levels;
        [SerializeField, Min(0)] private float _pausedTimeScale;
        [SerializeField, Min(0)] private float _gameOverDelay;
    }
}