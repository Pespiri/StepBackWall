using BeatSaberMarkupLanguage.GameplaySetup;
using BeatSaberMarkupLanguage.Settings;

namespace StepBackWall.Settings.UI
{
    internal class SettingsUI
    {
        public static bool created = false;

        public static void CreateMenu()
        {
            if (!created)
            {
                BSMLSettings.instance.AddSettingsMenu("StepBack Wall", "StepBackWall.Settings.UI.Views.mainsettings.bsml", MainSettings.instance);
                GameplaySetup.instance.AddTab("StepBack Wall", "StepBackWall.Settings.UI.Views.mainmodifiers.bsml", MainModifiers.instance);
                created = true;
            }
        }

        public static void RemoveMenu()
        {
            if (created)
            {
                BSMLSettings.instance.RemoveSettingsMenu(MainSettings.instance);
                GameplaySetup.instance.RemoveTab("StepBack Wall");
                created = false;
            }
        }
    }
}
