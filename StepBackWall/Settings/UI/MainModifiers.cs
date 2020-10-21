using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;

namespace StepBackWall.Settings.UI
{
    public class MainModifiers : NotifiableSingleton<MainModifiers>
    {
        [UIValue("enable-stepback-wall")]
        public bool IsStepBackWallEnabled
        {
            get => Configuration.EnableStepBackWalls;
            set => Configuration.EnableStepBackWalls = value;
        }

        [UIAction("trigger-toggle")]
        public void TriggerEnable(bool val) => IsStepBackWallEnabled = val;
    }
}
