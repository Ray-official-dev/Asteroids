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
        public Mover Ship => _ship;

        [SerializeField] private MobileShipInput _mobileInput;
        [SerializeField] private EditorShipInput _editorInput;
        [SerializeField] private Mover _ship;
    }
}