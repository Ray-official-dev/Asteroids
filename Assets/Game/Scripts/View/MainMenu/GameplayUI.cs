using System;
using Game.GameplayRules;
using MPA;
using MPA.Utilits;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.View
{
    public class GameplayUI : MPA.View
    {
        public event Action EnterInMainMenuRequested;

        [SerializeField, RequiredReference] TMP_Text _level;
        [SerializeField, RequiredReference] TMP_Text _round;
        [Space(10)]
        [SerializeField, RequiredReference] Button _pausedButton;
        [SerializeField, RequiredReference] Button _resumeButton;
        [SerializeField, RequiredReference] Button _returnButton;

        private Gameplay _gameplay;
        private string _levelTextFormat;

        public override void Initialize()
        {
            _gameplay = Context.Get<Gameplay>();
        }

        public override void Begin()
        {
            _gameplay.LevelChanged += LevelUpdated;

            _pausedButton.onClick.AddListener(OnPauseClicked);
            _resumeButton.onClick.AddListener(OnResumeClicked);
            _returnButton.onClick.AddListener(OnReturnClicked);

            _levelTextFormat = _level.text;
            LevelUpdated(_gameplay.CurrentLevel);
        }

        private void OnReturnClicked()
        {
            _gameplay.ReturnInMainMenu();
        }

        private void OnResumeClicked()
        {
            _gameplay.Resume();
        }

        private void OnPauseClicked()
        {
            _gameplay.Pause();
        }

        public override void OnTick()
        {
            _round.text = _gameplay.RoundTimer.GetFormattedTime();
        }

        private void LevelUpdated(int level)
        {
            _level.text = string.Format(_levelTextFormat, level);
        }
    }
}