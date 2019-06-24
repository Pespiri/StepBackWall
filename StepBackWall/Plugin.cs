using IPA;
using IPA.Config;
using IPA.Utilities;
using IPALogger = IPA.Logging.Logger;
using LogLevel = IPA.Logging.Logger.Level;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StepBackWall
{
    class Plugin : IBeatSaberPlugin, IDisablablePlugin
    {
        public static string PluginName = "StepBackWall";

        internal static Ref<PluginConfig> config;
        internal static IConfigProvider configProvider;

        public static bool IsStepBackWallEnabled
        {
            get => config.Value.ReEnableStepBackWall;
            set => config.Value.ReEnableStepBackWall = value;
        }

        public void Init(IPALogger logger, [Config.Prefer("json")] IConfigProvider cfgProvider)
        {
            if (logger != null)
            {
                Logger.log = logger;
                Logger.Log("Logger prepared", LogLevel.Debug);
            }

            configProvider = cfgProvider;
            config = cfgProvider.MakeLink<PluginConfig>((p, v) =>
            {
                if (v.Value == null || v.Value.RegenerateConfig || v.Value == null && v.Value.RegenerateConfig)
                {
                    p.Store(v.Value = new PluginConfig() { RegenerateConfig = false });
                }
                config = v;
            });
            Logger.Log("Configuration loaded", LogLevel.Debug);
        }

        public void OnApplicationStart()
        {
            Logger.Log($"{Plugin.PluginName} has started", LogLevel.Notice);
        }

        public void OnApplicationQuit()
        {
            configProvider.Store(config.Value);
        }

        public void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
        {
            if (nextScene.name == "GameCore")
            {
                new GameObject(Plugin.PluginName).AddComponent<StepBackWall>();
            }
        }

        public void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
        {
            if (scene.name == "MenuCore")
            {
                InGameSettingsUI.CreateGameplaySetupMenu();
                InGameSettingsUI.CreateSettingsMenu();
            }
        }

        public void OnSceneUnloaded(Scene scene) { }
        public void OnUpdate() { }
        public void OnFixedUpdate() { }

        public void OnEnable() { }
        public void OnDisable() { }
    }
}
