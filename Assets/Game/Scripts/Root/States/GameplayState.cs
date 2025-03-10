using MPA.Utilits;
using UnityEngine;
using Game.Rules;
using System;

namespace Game.Root
{
    public class GameplayState : State
    {
        public GameplayState(StateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter(IArguments enteredArgs)
        {
            var scenes = ProjectContext.Get<ScenesLoader>();
            var args = enteredArgs as Arguments;

            scenes.Load(Scenes.GAMEPLAY, () =>
            {
                var entryPoint = GameObject.FindFirstObjectByType<GameplayEntryPoint>();

                if (entryPoint is null)
                    throw new NullReferenceException(nameof(entryPoint));

                entryPoint.Entry(args);
            });
        }

        public class Arguments : IArguments
        {
            public int Level { get; }

            public Arguments(int level)
            {
                Level = level;
            }
        }
    }
}