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
        [UIValue("fade-in-distance")]
        public float FadeInDistance
        {
            get => Configuration.FadeInDistance;
            set => Configuration.FadeInDistance = value;
        }
    }
}
