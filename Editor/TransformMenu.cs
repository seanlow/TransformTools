using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//#if UNITY_EDITOR
using UnityEditor;
//#endif

namespace TransformTools
{
    public class TransformMenu : EditorWindow
    {
        [MenuItem("Transform/Transform Wizard #%t",false,0)]
        static void TransformWindow()
        {
            TransformWizard.ShowWindow();
        }
        
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

        [MenuItem("Transform/Distribute by X", false, 50)]
        static void DistributeX()
        {
            DistributeTools.AlongAxis(0);
        }

        [MenuItem("Transform/Distribute by Y", false, 51)]
        static void DistributeY()
        {
            DistributeTools.AlongAxis(1);
        }

        [MenuItem("Transform/Distribute by Z", false, 52)]
        static void DistributeZ()
        {
            DistributeTools.AlongAxis(2);
        }

        [MenuItem("Transform/Scatter In Bound", false, 70)]
        static void PlaceInBound()
        {
            PlaceTools.InBound();
        }        
    }
}
