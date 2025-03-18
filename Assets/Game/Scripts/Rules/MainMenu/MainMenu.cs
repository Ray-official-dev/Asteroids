using System;
using MPA.Utilits;
using UnityEngine;

namespace Game.Root
{
    public class MainMenu
    {
        public event Action<int> EnterGameplayRequested;

        public void Create()
        {
            var lifecycle = new Lifecycle();

            var levelsMenu = GameObject.FindFirstObjectByType<MainMenuSceneReferences>().LevelsPanel;
            levelsMenu.EnterGameplayRequested += OnEnterGameplayRequested;

            lifecycle.Add(levelsMenu);
            lifecycle.Run();
        }

        private void OnEnterGameplayRequested(int level)
        {
            EnterGameplayRequested?.Invoke(level);
        }
    }
}