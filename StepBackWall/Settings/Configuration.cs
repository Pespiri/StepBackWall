using IPA.Config;
using IPA.Utilities;
using StepBackWall.Settings.Utilities;
using LogLevel = IPA.Logging.Logger.Level;

namespace StepBackWall.Settings
{
    public class Configuration
    {
        private static bool isInit = false;
        private static Ref<PluginConfig> config;
        private static IConfigProvider configProvider;

        public static bool IsStepBackWallEnabled;
        public static bool ShowCallSource;

        internal static void Init(IConfigProvider cfgProvider)
        {
            if (!isInit && cfgProvider != null)
            {
                configProvider = cfgProvider;
                config = cfgProvider.MakeLink<PluginConfig>((p, v) =>
                {
                    if (v.Value == null || v.Value.RegenerateConfig || v.Value == null && v.Value.RegenerateConfig)
                    {
                        p.Store(v.Value = new PluginConfig() { RegenerateConfig = false });
                    }
                    config = v;
                });

                isInit = true;
            }
        }

        public static void Load()
        {
            if (isInit)
            {
                IsStepBackWallEnabled = config.Value.ReEnableStepBackWall;

                if (config.Value.Logging["ShowCallSource"] is bool)
                {
                    ShowCallSource = (bool)config.Value.Logging["ShowCallSource"];
                }

                Logger.Log("Configuration has been loaded.", LogLevel.Debug);
            }
        }

        public static void Save()
        {
            if (isInit)
            {
                config.Value.ReEnableStepBackWall = IsStepBackWallEnabled;
                config.Value.Logging["ShowCallSource"] = ShowCallSource;

                configProvider.Store(config.Value);
            }
        }
    }
}
