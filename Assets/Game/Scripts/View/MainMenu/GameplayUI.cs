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

        [SerializeField, RequiredReference] TMP_Text _asteroids;
        [SerializeField, RequiredReference] TMP_Text _round;
        [Space(10)]
        [SerializeField, RequiredReference] Button _pausedButton;
        [SerializeField, RequiredReference] Button _resumeButton;
        [SerializeField, RequiredReference] Button _returnButton;

        private Gameplay _gameplay;
        private int _asteroidsSpawnedAmount;
        private int _asteroidsCurrentAmount;

        public override void Initialize()
        {
            _gameplay = Context.Get<Gameplay>();
        }

        public override void Begin()
        {
            _gameplay.AsteroidsContainer.AsteroidsAmountChanged += OnAsteroidsAmountChanged;
            _gameplay.AsteroidsSpawner.AmountSpawned += OnAsteroidsSpawned;
            _pausedButton.onClick.AddListener(OnPauseClicked);
            _resumeButton.onClick.AddListener(OnResumeClicked);
            _returnButton.onClick.AddListener(OnReturnClicked);
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

        private void OnAsteroidsSpawned(int value)
        {
            _asteroidsSpawnedAmount = value;
            Show();
        }

        private void Show()
        {
            _asteroids.text = $"{_asteroidsCurrentAmount}/{_asteroidsSpawnedAmount}";
        }

        private void OnAsteroidsAmountChanged(int value)
        {
            _asteroidsCurrentAmount = value;
            Show();
        }
    }
}