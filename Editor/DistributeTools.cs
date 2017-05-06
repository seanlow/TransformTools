using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

using System.Linq;

public class DistributeTools
{
    public static void AlongAxis(int axis)
    {
        if (!Selection.activeTransform) { Debug.Log("No selection"); return; }

        List<Transform> selected;
        var count = Selection.transforms.Length;
        float distance, gap, startPoint;
        var newPos = Vector3.zero;
        switch (axis)
        {
            case (0):
                selected = Selection.transforms.OrderBy(tr => tr.position.x).ToList();
                distance = selected[count - 1].position.x - selected[0].position.x;
                startPoint = selected[0].position.x;
                break;
            case (1):
                selected = Selection.transforms.OrderBy(tr => tr.position.y).ToList();
                distance = selected[count - 1].position.y - selected[0].position.y;
                startPoint = selected[0].position.y;
                break;
            case (2):
                selected = Selection.transforms.OrderBy(tr => tr.position.z).ToList();
                distance = selected[count - 1].position.z - selected[0].position.z;
                startPoint = selected[0].position.z;
                break;
            default:
                selected = null;
                distance = startPoint = 0;
                break;
        }
        
        gap = distance / (count - 1);

        var start = selected[0];
        var end = selected[count - 1];

        Undo.RecordObjects(selected.ToArray(), "Distribute");
        selected.Remove(start);
        selected.Remove(end);        

        switch (axis)
        {
            case(0):
                for (int i = 0; i < selected.Count; i++)
                {
                    var trans = selected[i];
                    newPos = new Vector3(startPoint + gap * (i + 1), trans.position.y, trans.position.z);
                    trans.position = newPos;
                }
                break;

            case (1):
                for (int i = 0; i < selected.Count; i++)
                {
                    var trans = selected[i];
                    newPos = new Vector3(trans.position.x, startPoint + gap * (i + 1), trans.position.z);
                    trans.position = newPos;
                }
                break;

            case (2):
                for (int i = 0; i < selected.Count; i++)
                {
                    var trans = selected[i];
                    newPos = new Vector3(trans.position.x, trans.position.y, startPoint + gap * (i + 1));
                    trans.position = newPos;
                }
                break;
        }
    }
}
