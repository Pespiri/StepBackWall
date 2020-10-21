using System;
using System.Collections.Generic;
using UnityEngine;

namespace StepBackWall.Gameplay
{
    public class StepBackWallEnabler : MonoBehaviour
    {
        private void Start()
        {
            try
            {
                IList<MoveBackWall> moveBackWalls = Resources.FindObjectsOfTypeAll<MoveBackWall>();
                foreach (MoveBackWall moveBackWall in moveBackWalls)
                {
                    moveBackWall.gameObject.SetActive(true);
                }
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex);
            }
        }
    }
}
