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
        // so activeTransform is last selected or first selected?
        Transform[] selected = Selection.transforms;
        Transform sel = Selection.activeTransform;
        var mesh = sel.GetComponent<Renderer>();
        var bound = mesh.bounds;
        Undo.RecordObjects(selected, "Place In Bound");
        //Debug.Log(sel.name);

        foreach (var trans in selected)
        {
            if (trans != sel)
            {
                //Debug.Log(trans.name);
                var randx = Random.Range(bound.min[0], bound.max[0]);
                var randy = Random.Range(bound.min[1], bound.max[1]);
                var randz = Random.Range(bound.min[2], bound.max[2]);
                var newPos = new Vector3(randx, randy, randz);
                
                trans.position = newPos;
                //Debug.Log(newPos.x +","+ newPos.y +","+ newPos.z);
            }
        }

        
    }
}
