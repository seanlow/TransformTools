using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public static class PlaceTools
{
    public static void InBound()
    {
        if (!Selection.activeTransform) {Debug.Log("No selection"); return;}

        Transform[] selected = Selection.transforms;
        Transform sel = Selection.activeTransform;
        
        var mesh = sel.GetComponent<Renderer>();
        var bound = mesh.bounds;
        Undo.RecordObjects(selected, "Scatter In Bound");

        foreach (var trans in selected)
        {
            if (trans != sel)
            {
                var randx = Random.Range(bound.min[0], bound.max[0]);
                var randy = Random.Range(bound.min[1], bound.max[1]);
                var randz = Random.Range(bound.min[2], bound.max[2]);
                var newPos = new Vector3(randx, randy, randz);
                
                trans.position = newPos;
            }
        }
    }

}
