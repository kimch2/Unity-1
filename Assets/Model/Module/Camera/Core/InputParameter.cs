using UnityEngine;
 using System.Runtime.InteropServices;

namespace ETModel {
    public class InputParameter
    {
        public static float RotateSpeed { get; private set; }
        public static float ZoomSpeed { get; private set; }
        public static float SummationX { get; set; }
        public static float SummationY { get; set; }
        public static float SummationZ { get; set; }
        public static float MaxDistance { get; private set; }
        public static float MinDistance { get; private set; }
        public static float ClampMaxX { get; private set; }
        public static float ClampMinX { get; private set; }
        public static float ClampMaxY { get; private set; }
        public static float ClampMinY { get; private set; }


        public static void SetParameter(ViewItemData config)
        {
            RotateSpeed = 1;
            ZoomSpeed = config.Distance;
            SummationX = config.ValueX;
            SummationY = config.ValueY;
            SummationZ = config.Distance;
            MaxDistance = 3f;
            MinDistance = 0.1f;
            ClampMaxX = 360;
            ClampMinX = -360;
            ClampMaxY = 90;
            if (config.ValueX > 0)
            {
                ClampMinY = 0;
            }
            else
            {
                ClampMinY = config.ValueX;
            }
            switch (config.TargetID)
            {
                case "Project_004_Rular":
                    SummationY=GameObject.Find("Project_004_Rular").transform.eulerAngles.y+180;
                    SummationX = 0;
                    break;
                case "Project_004_YBKC":
                    SummationY = GameObject.Find("Project_004_Rular").transform.eulerAngles.y + 180;
                    SummationX = 0;
                    break;
            }
        }
     }
}