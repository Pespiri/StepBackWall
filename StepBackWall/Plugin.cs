using IPA;
using IPA.Config;
using IPA.Loader;
using IPA.Utilities;
using StepBackWall.Gameplay;
using StepBackWall.Settings;
using StepBackWall.Settings.UI;
using StepBackWall.Settings.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;
using LogLevel = IPA.Logging.Logger.Level;

namespace StepBackWall
{
    class Plugin : IBeatSaberPlugin, IDisablablePlugin
    {
        public static string PluginName = "StepBackWall";
        public static SemVer.Version PluginVersion = new SemVer.Version("0.0.0"); // Default

        internal static Ref<PluginConfig> config;
        internal static IConfigProvider configProvider;

        public void Init(IPALogger logger, [Config.Prefer("json")] IConfigProvider cfgProvider, PluginLoader.PluginMetadata metadata)
        {
            Logger.log = logger;

            configProvider = cfgProvider;
            config = cfgProvider.MakeLink<PluginConfig>((p, v) =>
            {
                if (v.Value == null || v.Value.RegenerateConfig || v.Value == null && v.Value.RegenerateConfig)
                {
                    p.Store(v.Value = new PluginConfig() { RegenerateConfig = false });
                }
                config = v;
            });

            if (metadata?.Version != null)
            {
                PluginVersion = metadata.Version;
            }
        }

        public void OnApplicationStart() => Load();
        public void OnApplicationQuit() => Unload();
        public void OnEnable() => Load("been enabled");
        public void OnDisable() => Unload();

        public void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
        {
            if (nextScene.name == "GameCore")
            {
                if (Configuration.IsStepBackWallEnabled)
                {
                    new GameObject(PluginName).AddComponent<StepBackWallEnabler>();
                }
            }
        }

        public void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
        {
            if (scene.name == "MenuCore")
            {
                SettingsUI.CreateGameplaySetupMenu();
                SettingsUI.CreateSettingsMenu();
            }
        }

        public void OnSceneUnloaded(Scene scene) { }
        public void OnUpdate() { }
        public void OnFixedUpdate() { }

        private void Load(string msg = "started")
        {
            Configuration.Load();
            Logger.Log($"{PluginName} v{PluginVersion} has {msg}.", LogLevel.Notice);
        }

        private void Unload()
        {
            Configuration.Save();
        }
    }
}
