using BeatSaberMarkupLanguage.Settings;
using IPA;
using IPA.Config;
using IPA.Loader;
using StepBackWall.Gameplay;
using StepBackWall.Settings;
using StepBackWall.Settings.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;

namespace StepBackWall
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        public static string PluginName => "StepBackWall";
        public static SemVer.Version PluginVersion { get; private set; } = new SemVer.Version("0.0.0"); // Default

        [Init]
        public void Init(IPALogger logger, Config config, PluginMetadata metadata)
        {
            Logger.log = logger;
            Configuration.Init(config);

            if (metadata?.Version != null)
            {
                PluginVersion = metadata.Version;
            }
        }

        [OnEnable]
        public void OnEnable() => Load();
        [OnDisable]
        public void OnDisable() => Unload();
        [OnExit]
        public void OnApplicationQuit() => Unload();

        private void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
        {
            if (nextScene.name == "GameCore")
            {
                if (Configuration.EnableStepBackWalls)
                {
                    new GameObject(PluginName).AddComponent<StepBackWallEnabler>();
                }
            }
            else if (nextScene.name == "MenuViewControllers" && prevScene.name == "EmptyTransition")
            {
                BSMLSettings.instance.AddSettingsMenu("StepBack Wall", "StepBackWall.Settings.UI.Views.mainsettings.bsml", MainSettings.instance);
            }
        }

        private void Load()
        {
            Configuration.Load();
            AddEvents();
            Logger.log.Info($"{PluginName} v{PluginVersion} has started.");
        }

        private void Unload()
        {
            Configuration.Save();
            RemoveEvents();
        }

        private void AddEvents()
        {
            RemoveEvents();
            SceneManager.activeSceneChanged += OnActiveSceneChanged;
        }

        private void RemoveEvents()
        {
            SceneManager.activeSceneChanged -= OnActiveSceneChanged;
        }
    }
}
