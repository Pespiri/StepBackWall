using System;
using System.Collections.Generic;
using UnityEngine;
using IPA.Utilities;
using StepBackWall.Settings;

namespace StepBackWall.Gameplay
{
    public class StepBackWallEnabler : MonoBehaviour
    {
        private static FieldAccessor<MoveBackWall, float>.Accessor fadeInAccessor 
            = FieldAccessor<MoveBackWall, float>.GetAccessor("_fadeInRegion");
        private void Start()
        {
            try
            {
                IList<MoveBackWall> moveBackWalls = Resources.FindObjectsOfTypeAll<MoveBackWall>();
                foreach (MoveBackWall moveBackWall in moveBackWalls)
                {
                    moveBackWall.gameObject.SetActive(true);
                    MoveBackWall wall = moveBackWall;
                    fadeInAccessor(ref wall) = Configuration.FadeInDistance;
                }
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex);
            }
        }
    }
}
