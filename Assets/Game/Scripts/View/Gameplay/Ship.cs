using MPA;
using UnityEngine;

namespace Game.View
{
    public class Ship : MPA.View
    {
        [SerializeField, RequiredReference] Mover _mover;
        [SerializeField, RequiredReference] Shooter _shooter;

        public override void Initialize()
        {
            _mover.Initialize();
            _shooter.Initialize();
        }

        public override void Begin()
        {
            _mover.Begin();
            _shooter.Begin();
        }

        public override void OnTick()
        {
            _mover.OnTick();
            _shooter.OnTick();
        }

        public override void OnFixedTick()
        {
            _mover.OnFixedTick();
            _shooter.OnFixedTick();
        }

        public void Delete()
        {
            Destroy(gameObject);
        }
    }
}