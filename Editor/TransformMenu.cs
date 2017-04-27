using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TransformTools
{
    public class TransformMenu : EditorWindow
    {
        [MenuItem("Transform/Group %g",false,1)]
        static void GroupSelections()
        {GroupTools.Group();}

        [MenuItem("Transform/Ungroup #%g", false, 1)]
        static void Ungroup()
        {GroupTools.Ungroup();}

        [MenuItem("Transform/Align X/Average", false, 21)]
        static void AlignX_Avg()
        {AlignTools.AlignAverage(AlignTools.AlignAxis.x);}

        [MenuItem("Transform/Align X/Min", false, 21)]
        static void AlignX_Min()
        {AlignTools.Align(AlignTools.AlignAxis.x, AlignTools.AlignMode.min);}

        [MenuItem("Transform/Align X/Max", false, 21)]
        static void AlignX_Max()
        {AlignTools.Align(AlignTools.AlignAxis.x, AlignTools.AlignMode.max);}

        [MenuItem("Transform/Align Y/Average", false, 21)]
        static void AlignY_Avg()
        { AlignTools.AlignAverage(AlignTools.AlignAxis.y); }

        [MenuItem("Transform/Align Y/Min", false, 21)]
        static void AlignY_Min()
        { AlignTools.Align(AlignTools.AlignAxis.y, AlignTools.AlignMode.min); }

        [MenuItem("Transform/Align Y/Max", false, 21)]
        static void AlignY_Max()
        { AlignTools.Align(AlignTools.AlignAxis.y, AlignTools.AlignMode.max); }

        [MenuItem("Transform/Align Z/Average", false, 21)]
        static void AlignZ_Avg()
        { AlignTools.AlignAverage(AlignTools.AlignAxis.z); }

        [MenuItem("Transform/Align Z/Min", false, 21)]
        static void AlignZ_Min()
        { AlignTools.Align(AlignTools.AlignAxis.z, AlignTools.AlignMode.min); }

        [MenuItem("Transform/Align Z/Max", false, 21)]
        static void AlignZ_Max()
        { AlignTools.Align(AlignTools.AlignAxis.z, AlignTools.AlignMode.max); }

        [MenuItem("Transform/Align Tool Window",false,21)]
        static void ShowAlignToolWindow()
        {
            AlignToolsWindow.ShowWindow();
        }

        [MenuItem("Transform/Distribute by X #%x", false, 50)]
        static void DistributeX()
        {
            DistributeTools.AlongAxis(0);
        }

        [MenuItem("Transform/Distribute by Y #%y", false, 51)]
        static void DistributeY()
        {
            DistributeTools.AlongAxis(1);
        }

        [MenuItem("Transform/Distribute by Z #%z", false, 52)]
        static void DistributeZ()
        {
            DistributeTools.AlongAxis(2);
        }

        [MenuItem("Transform/Random Transition/X", false, 70)]
        static void RandomPosX()
        {
            RandomTools.RandomPosition(0, 1f);
        }

        [MenuItem("Transform/Random Transition/Y", false, 71)]
        static void RandomPosY()
        {
            RandomTools.RandomPosition(1, 1f);
        }

        [MenuItem("Transform/Random Transition/Z", false, 72)]
        static void RandomPosZ()
        {
            RandomTools.RandomPosition(2, 1f);
        }

        [MenuItem("Transform/Random Rotation/X", false, 73)]
        static void RandomRotX()
        {
            RandomTools.RandomRotation(0);
        }

        [MenuItem("Transform/Random Rotation/Y", false, 74)]
        static void RandomRotY()
        {
            RandomTools.RandomRotation(1);
        }

        [MenuItem("Transform/Random Rotation/Z", false, 75)]
        static void RandomRotZ()
        {
            RandomTools.RandomRotation(2);
        }

        [MenuItem("Transform/Random Scale", false, 76)]
        static void RandomScale()
        {
            RandomTools.RandomScale(1f);
        }

        [MenuItem("Transform/Place In Bound", false, 90)]
        static void PlaceInBound()
        {
            PlaceTools.InBound();
        }
    }
}
