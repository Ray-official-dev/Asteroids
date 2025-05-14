using MPA.Utilits;
using Game.VFX;
using Game.SFX;

namespace Game.GameplayRules
{
    public class ConfigsInstaller
    {
        public void Install()
        {
            var provider = Context.Get<SOConfigsProvider>();

            SceneContext.Register(provider.Get<AsteroidsSpawnerConfig>());
            SceneContext.Register(provider.Get<ShipSFXConfig>());
            SceneContext.Register(provider.Get<BulletSFXConfig>());
            SceneContext.Register(provider.Get<ShipVFXConfig>());
            SceneContext.Register(provider.Get<BulletVFXConfig>());
            SceneContext.Register(provider.Get<AsteroidVFXConfig>());
            SceneContext.Register(provider.Get<AsteroidsSFXConfig>());
        }
    }
}