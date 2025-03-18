using Game.View;
using UnityEngine;

namespace Game.Root
{
    public class MainMenuSceneReferences : MonoBehaviour
    {
        public LevelSelectionPanel LevelsPanel => _levelsPanel;
        [SerializeField] private LevelSelectionPanel _levelsPanel;
    }
}