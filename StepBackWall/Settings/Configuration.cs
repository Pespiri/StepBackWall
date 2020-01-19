using IPA.Config;
using IPA.Utilities;
using StepBackWall.Settings.Utilities;

namespace StepBackWall.Settings
{
    public class Configuration
    {
        private static Ref<PluginConfig> config;
        private static IConfigProvider configProvider;

        public static bool EnableStepBackWalls { get; internal set; }

        internal static void Init(IConfigProvider cfgProvider)
        {
            configProvider = cfgProvider;
            config = cfgProvider.MakeLink<PluginConfig>((p, v) =>
            {
                if (v.Value == null || v.Value.RegenerateConfig)
                {
                    p.Store(v.Value = new PluginConfig() { RegenerateConfig = false });
                }
                config = v;
            });
        }

        internal static void Load()
        {
            EnableStepBackWalls = config.Value.EnableStepBackWall;
        }

        internal static void Save()
        {
            config.Value.EnableStepBackWall = EnableStepBackWalls;

            configProvider.Store(config.Value);
        }
    }
}
