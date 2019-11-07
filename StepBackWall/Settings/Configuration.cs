namespace StepBackWall.Settings
{
    public static class Configuration
    {
        public static bool IsStepBackWallEnabled;
        public static bool ShowCallSource;

        public static void Load()
        {
            IsStepBackWallEnabled = Plugin.config.Value.ReEnableStepBackWall;

            if (Plugin.config.Value.Logging["ShowCallSource"] is bool)
            {
                ShowCallSource = (bool)Plugin.config.Value.Logging["ShowCallSource"];
            }
        }

        public static void Save()
        {
            Plugin.config.Value.ReEnableStepBackWall = IsStepBackWallEnabled;
            Plugin.config.Value.Logging["ShowCallSource"] = ShowCallSource;

            Plugin.configProvider.Store(Plugin.config.Value);
        }
    }
}
