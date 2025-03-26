using Game.GameplayRules;
using MPA;
using MPA.Utilits;
using TMPro;
using UnityEngine;

namespace Game.View
{
    public class Gameplay : MPA.View
    {
        [SerializeField, RequiredReference] TMP_Text _asteroids;
        [SerializeField, RequiredReference] TMP_Text _round;

        private IReadOnlyAsteroidsContainer _asteroidsContainer;
        private IReadOnlyAsteroidsSpawner _asteroidsSpawner;
        private IReadOnlyCountdownTimer _roundTimer;

        private int _asteroidsSpawnedAmount;
        private int _asteroidsCurrentAmount;

        public override void Initialize()
        {
            _asteroidsContainer = Context.Get<IReadOnlyAsteroidsContainer>();
            _asteroidsSpawner = Context.Get<IReadOnlyAsteroidsSpawner>();
            _roundTimer = Context.Get<IReadOnlyCountdownTimer>();
        }

        public override void Begin()
        {
            _asteroidsContainer.AsteroidsAmountChanged += OnAsteroidsAmountChanged;
            _asteroidsSpawner.AmountSpawned += OnAsteroidsSpawned;
        }

        public override void OnTick()
        {
            _round.text = _roundTimer.GetFormattedTime();
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