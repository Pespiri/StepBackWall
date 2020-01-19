using BeatSaberMarkupLanguage.Attributes;

namespace StepBackWall.Settings.UI
{
    public class MainSettings : PersistentSingleton<MainSettings>
    {
        [UIValue("enable-stepback-wall")]
        public bool IsStepBackWallEnabled
        {
            get => Configuration.EnableStepBackWalls;
            set => Configuration.EnableStepBackWalls = value;
        }
    }
}
