using System;
using System.Collections.Generic;
using Game.SFX;
using MPA.Utilits;
using UnityEngine;

namespace Game.Root
{
    public class EntryPoint
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Run()
        {
            var point = new EntryPoint();
            point.Entry();
        }

        public void Entry()
        {
            ProjectContext.Register(new SOConfigsProvider());
            ProjectContext.Register(new ResourceProvider());

            var configsInstaller = new ConfigsInstaller();
            configsInstaller.Install();

            ProjectContext.Register(new ScenesLoader());
            ProjectContext.Register(new Storage());
            ProjectContext.Register(new AudioClickHandler());

            var game = new StateMachine();

            var states = new Dictionary<Type, State>()
            {
                [typeof(MainMenuState)] = new MainMenuState(game),
                [typeof(GameplayState)] = new GameplayState(game)
            };

            game.AddStates(states);
            game.EnterIn<MainMenuState>();
        }
    }
}