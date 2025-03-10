using System;
using System.Collections.Generic;
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
            var configs = new SOConfigsProvider();

            ProjectContext.Register(new ScenesLoader());
            ProjectContext.Register(configs.Get<AppSettingsConfig>());

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