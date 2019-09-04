using CustomUI.Settings;
using CustomUI.Utilities;
using CustomUI.GameplaySettings;
using LogLevel = IPA.Logging.Logger.Level;
using UnityEngine;

namespace StepBackWall.UI
{
    public class SettingsUI : MonoBehaviour
    {
        private static ToggleOption stepBackWallToggle;
        private static BoolViewController stepBackWallController;

        private static readonly Sprite optionIcon = UIUtilities.LoadSpriteFromResources($"{Plugin.PluginName}.Resources.icon_playersettings.png");

        /// <summary>
        /// Adds an additional submenu in the "Settings" page
        /// </summary>
        public static void CreateSettingsMenu()
        {
            SubMenu subMenu = CustomUI.Settings.SettingsUI.CreateSubMenu(Plugin.PluginName);

            stepBackWallController = subMenu.AddBool("Enable 'Step Back' wall", "Default = On");
            stepBackWallController.GetValue += delegate { return Configuration.IsStepBackWallEnabled; };
            stepBackWallController.SetValue += delegate (bool value)
            {
                ChangeStepBackWallState(value);
                Logger.Log($"'Enable 'Step Back' wall' (IsStepBackWallEnabled) in the main settings is set to '{value}'", LogLevel.Debug);
            };
        }

        /// <summary>
        /// Adds a toggle option to the in-game "Gameplay Setup" window. It can be found in the right panel of the Player Settings
        /// </summary>
        public static void CreateGameplaySetupMenu()
        {
            stepBackWallToggle = GameplaySettingsUI.CreateToggleOption(GameplaySettingsPanels.PlayerSettingsRight, "Enable 'Step Back' wall", "Default: On", optionIcon);
            stepBackWallToggle.GetValue = Configuration.IsStepBackWallEnabled;
            stepBackWallToggle.OnToggle += (bool value) =>
            {
                Configuration.IsStepBackWallEnabled = value;
                Logger.Log($"Toggle is very '{(value ? "toggled" : "untoggled")}! Value is now '{value}'", LogLevel.Debug);
            };
        }

        private static void ChangeStepBackWallState(bool state) => stepBackWallToggle.SetToggleState(state);
    }
}
