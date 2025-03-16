using Game.Input;
using Game.View;
using UnityEngine;

namespace Game.Rules
{
    [CreateAssetMenu(menuName = Constans.CONFIGS_PATH + "Gameplay Config")]
    public class GameplayConfig : ScriptableObject
    {
        public MobileShipInput MobileInput => _mobileInput;
        public EditorShipInput EditorInput => _editorInput;
        public Ship Ship => _ship;
        public LevelConfig[] Levels => _levels;

        [SerializeField] private MobileShipInput _mobileInput;
        [SerializeField] private EditorShipInput _editorInput;
        [SerializeField] private Ship _ship;
        [SerializeField] private LevelConfig[] _levels;
    }
}