using System;
using System.Linq;
using LogLevel = IPA.Logging.Logger.Level;
using UnityEngine;

namespace StepBackWall
{
    public class StepBackWall : MonoBehaviour
    {
        private void Start()
        {
            try
            {
                if (Plugin.IsStepBackWallEnabled && Resources.FindObjectsOfTypeAll<MoveBackWall>().Count() > 0)
                {
                    Resources.FindObjectsOfTypeAll<MoveBackWall>().First().gameObject.SetActive(true);
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, LogLevel.Error);
            }
        }

        private void OnDestroy() { }
    }
}
