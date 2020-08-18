using IPA.Config;
using IPA.Config.Stores;
using StepBackWall.Settings.Utilities;

namespace StepBackWall.Settings
{
    public class Configuration
    {
        public static bool EnableStepBackWalls { get; internal set; }

        internal static void Init(Config config)
        {
            PluginConfig.Instance = config.Generated<PluginConfig>();
        }

        internal static void Load()
        {
            EnableStepBackWalls = PluginConfig.Instance.EnableStepBackWall;
        }

        internal static void Save()
        {
            PluginConfig.Instance.EnableStepBackWall = EnableStepBackWalls;
        }
    }
}
