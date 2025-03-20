using System;
using Game.View;
using MPA.Utilits;
using UnityEngine;

namespace Game.MainMenuRules
{
    public class MainMenu
    {
        public event Action<int> EnterGameplayRequested;

        private SceneReferences _references;

        private LevelSelectionMenu _levelSelectionMenu => _references.LevelsSelectionMenu;
        private FirstMenu _firstMenu => _references.FirstMenu;

        public void Create()
        {
            var lifecycle = new Lifecycle();

            _references = GameObject.FindFirstObjectByType<SceneReferences>();

            if (_references is null)
                throw new NullReferenceException(nameof(_references));

            _levelSelectionMenu.EnterGameplayRequested += OnEnterGameplayRequested;

            _firstMenu.Show();
            _levelSelectionMenu.Hide();

            lifecycle.Add(_levelSelectionMenu);
            lifecycle.Run();
        }

        private void OnEnterGameplayRequested(int level)
        {
            EnterGameplayRequested?.Invoke(level);
        }
    }
}