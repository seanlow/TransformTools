using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

using System.Linq;

public static class AlignTools
{
    public enum AlignMode { avg, min, max };
    public enum AlignAxis { x, y, z };
    public static Transform[] selected;

    public static void AlignAverage(AlignAxis _axis)
    {
        if (!Selection.activeTransform) return;
        selected = Selection.transforms;
        float total = 0;
        foreach (var trans in selected)
        {
            switch (_axis)
            {
                case AlignAxis.x:
                    total += trans.position.x;
                break;
                case AlignAxis.y:
                    total += trans.position.y;
                break;
                case AlignAxis.z:
                    total += trans.position.z;
                break;
            }
        }
        float avg = total / selected.Length;
        
        Undo.RecordObjects(Selection.transforms, "Align Average by " + _axis.ToString().ToUpper());
        foreach (var trans in selected)
        {
            switch(_axis)
            {
                case AlignAxis.x:
                    trans.position = new Vector3(avg, trans.position.y, trans.position.z);
                break;
                case AlignAxis.y:
                    trans.position = new Vector3(trans.position.x, avg, trans.position.z);
                    break;
                case AlignAxis.z:
                    trans.position = new Vector3(trans.position.x, trans.position.y, avg);
                break;
            }
        }
    }

    public static void Align(AlignAxis _axis, AlignMode _mode)
    {
        if (!Selection.activeTransform) return;

        switch (_axis)
        {
            case AlignAxis.x:
                selected = Selection.transforms.OrderBy(tr => tr.position.x).ToArray();
            break;
            case AlignAxis.y:
                selected = Selection.transforms.OrderBy(tr => tr.position.y).ToArray();
            break;
            case AlignAxis.z:
                selected = Selection.transforms.OrderBy(tr => tr.position.z).ToArray();
            break;
        }

        Vector3 targetPos = Vector3.zero;

        switch (_mode)
        {
            case AlignMode.min:
                targetPos = selected[0].position;
            break;

            case AlignMode.max:
                targetPos = selected[selected.Length-1].position;
                break;
        }

        Undo.RecordObjects(Selection.transforms, "Align " + _mode.ToString().ToUpper() + " by " + _axis.ToString().ToUpper());

        foreach (var trans in selected)
        {
            switch (_axis)
            {
                case AlignAxis.x:
                    trans.position = new Vector3(targetPos.x, trans.position.y, trans.position.z);
                break;
                case AlignAxis.y:
                    trans.position = new Vector3(trans.position.x, targetPos.y, trans.position.z);
                    break;
                case AlignAxis.z:
                    trans.position = new Vector3(trans.position.x, trans.position.y, targetPos.z);
                    break;
            }
            
        }
    }

    
}

