using System;
using Game.GameplayRules;
using MPA.Utilits;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.View
{
    public class LevelSelectionMenu : Menu
    {
        public event Action<int> EnterGameplayRequested;

        [SerializeField] private Button _nextButton;
        [SerializeField] private Button _prevButton;
        [SerializeField] private Button _playButton;

        [SerializeField] private TMP_Text _level;

        private int _lastLevelIndex;
        private int _levelsAmount;
        private int _currentLevelIndex;

        public override void Initialize()
        {
            base.Initialize();

            _lastLevelIndex = Context.Get<Storage>().GetLastLevelIndex();
            _levelsAmount = Context.Get<GameplayConfig>().Levels.Length;
        }

        public override void Begin()
        {
            base.Begin();

            _nextButton.onClick.AddListener(OnNext);
            _prevButton.onClick.AddListener(OnPrev);
            _playButton.onClick.AddListener(OnPlay);

            Apply();
        }

        public override void Show()
        {
            base.Show();
        }

        public override void Hide()
        {
            base.Hide();
        }

        private void OnNext()
        {
            if (_currentLevelIndex >= _levelsAmount - 1)
                return;

            _currentLevelIndex++;
            Apply();
        }

        private void OnPrev()
        {
            if (_currentLevelIndex == 0)
                return;

            _currentLevelIndex--;
            Apply();
        }

        private void OnPlay()
        {
            if (_currentLevelIndex > _lastLevelIndex)
                return;

            EnterGameplayRequested?.Invoke(_currentLevelIndex);
        }

        private void Apply()
        {
            _level.text = (_currentLevelIndex + 1).ToString();
            var isLocked = _currentLevelIndex > _lastLevelIndex;
            _playButton.interactable = !isLocked;
        }
    }
}