using Game.Input;
using Game.View;
using UnityEngine;

namespace Game.Rules
{
    [CreateAssetMenu(menuName = Constans.CONFIGS_PATH + "Gameplay Config")]
    public class GameplayConfig : ScriptableObject
    {
        public MobileInputControl Input => _input;
        public ShipView Ship => _ship;

        [SerializeField] private MobileInputControl _input;
        [SerializeField] private ShipView _ship;
    }
}