using Game.GameplayRules;
using MPA.Utilits;

namespace Game.Root
{
    public class ConfigsInstaller
    {
        public void Install()
        {
            var configs = ProjectContext.Get<SOConfigsProvider>();

            ProjectContext.Register(configs.Get<AppSettingsConfig>());
            ProjectContext.Register(configs.Get<GameplayConfig>());
        }
    }
}