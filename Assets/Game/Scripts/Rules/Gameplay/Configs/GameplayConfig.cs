using Game.Input;
using Game.View;
using UnityEngine;

namespace Game.GameplayRules
{
    [CreateAssetMenu(menuName = Constans.CONFIGS_PATH + "Gameplay Config")]
    public class GameplayConfig : ScriptableObject
    {
        public float PausedTimeScale => _pausedTimeScale;
        public GameplayUI UserInterface => _userInterface;
        public MobileShipInput MobileInput => _mobileInput;
        public EditorShipInput EditorInput => _editorInput;
        public Ship Ship => _ship;
        public LevelConfig[] Levels => _levels;
        public float GameOverDelay => _gameOverDelay;

        [SerializeField] private GameplayUI _userInterface;
        [SerializeField] private MobileShipInput _mobileInput;
        [SerializeField] private EditorShipInput _editorInput;
        [SerializeField] private Ship _ship;
        [SerializeField] private LevelConfig[] _levels;
        [SerializeField, Min(0)] private float _pausedTimeScale;
        [SerializeField, Min(0)] private float _gameOverDelay;
    }
}