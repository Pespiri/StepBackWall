using System;
using System.Linq;
using LogLevel = IPA.Logging.Logger.Level;
using UnityEngine;

namespace StepBackWall.Gameplay
{
    public class StepBackWallEnabler : MonoBehaviour
    {
#pragma warning disable IDE0051 // Used by MonoBehaviour
        private void Start()
#pragma warning restore IDE0051 // Used by MonoBehaviour
        {
            try
            {
                MoveBackWall[] moveBackWalls = Resources.FindObjectsOfTypeAll<MoveBackWall>();
                if (moveBackWalls.Count() > 0)
                {
                    moveBackWalls.First().gameObject.SetActive(true);
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, LogLevel.Error);
            }
        }
    }
}
