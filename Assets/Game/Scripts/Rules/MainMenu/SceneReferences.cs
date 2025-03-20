using Game.View;
using MPA;
using UnityEngine;

namespace Game.MainMenuRules
{
    public class SceneReferences : MonoBehaviour
    {
        public LevelSelectionMenu LevelsSelectionMenu => _levelsMenu;
        public FirstMenu FirstMenu => _firstMenu;

        [SerializeField, RequiredReference] LevelSelectionMenu _levelsMenu;
        [SerializeField, RequiredReference] FirstMenu _firstMenu;
    }
}