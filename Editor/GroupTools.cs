using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public static class GroupTools
{
    public static void Group()
    {
        var go = new GameObject("New Group");
        Undo.RegisterCreatedObjectUndo(go, "Create Group Node");
        if (!Selection.activeTransform)
        {
            Undo.SetTransformParent(go.transform, null, "Parent New Group to world");
        }

        else
        {
            Undo.SetTransformParent(go.transform, Selection.activeTransform.parent, "Parent New Group");
            foreach (var transform in Selection.transforms)
            {
                Undo.SetTransformParent(transform, go.transform, "Group Selected");
            }
        }
        Selection.activeGameObject = go;
    }

    public static void Ungroup()
    {
        if (!Selection.activeTransform || Selection.activeTransform.childCount == 0) return;
        Transform[] selected = Selection.transforms;

        foreach (var trans in selected)
        {
            List<Transform> children = new List<Transform>(trans.childCount);
            foreach (Transform child in trans)
            {
                children.Add(child);
            }

            foreach (var child in children)
            {
                Undo.SetTransformParent(child, trans.parent, "Ungroup Selected");                
            }

            Undo.DestroyObjectImmediate(trans.gameObject);

        }

    }
}
