﻿using System;
using Game.SFX;
using Game.VFX;
using MPA;
using MPA.Utilits;
using UnityEngine;

namespace Game.View
{
    public class Ship : MPA.View, IPrefab
    {
        public event Action<Ship> Exploded;
        public event Action<Vector3, Quaternion> Shooted;

        [SerializeField, RequiredReference] Mover _mover;
        [SerializeField, RequiredReference] Shooter _shooter;

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.collider.TryGetComponent(out Asteroid _))
                return;

            Explode();
        }

        public override void Initialize()
        {
            _mover.Initialize();
            _shooter.Initialize();

            _shooter.Shooted += OnShooted;

            var audio = new ShipSFX(this);
            var effects = new ShipVFX(this);
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

        private void OnShooted(Vector3 pos, Quaternion rot)
        {
            Shooted?.Invoke(pos, rot);
        }

        public void Explode()
        {
            Exploded?.Invoke(this);
            Destroy(gameObject);
        }
    }
}