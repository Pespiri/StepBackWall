using IPA.Config;
using IPA.Config.Stores;
using StepBackWall.Settings.Utilities;

namespace StepBackWall.Settings
{
    public class Configuration
    {
        public static bool EnableStepBackWalls { get; internal set; }
        public static float FadeInDistance { get; internal set; } = 0.5f;

        internal static void Init(Config config)
        {
            PluginConfig.Instance = config.Generated<PluginConfig>();
        }

        internal static void Load()
        {
            EnableStepBackWalls = PluginConfig.Instance.EnableStepBackWall;
            FadeInDistance = PluginConfig.Instance.FadeInDistance;
        }

        internal static void Save()
        {
            PluginConfig.Instance.EnableStepBackWall = EnableStepBackWalls;
            PluginConfig.Instance.FadeInDistance = FadeInDistance;
        }
    }
}
