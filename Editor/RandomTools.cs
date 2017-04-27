using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

using System.Linq;

public class RandomTools
{
    public static void RandomPosition(int _axis, float _range)
    {
        if (!Selection.activeTransform) return;
        var selectedTransforms = Selection.transforms;
        Undo.RecordObjects(Selection.transforms, "Random Position");

        foreach (var trans in selectedTransforms)
        {
            Vector3 pos = trans.position;
            float rand = Random.Range(-_range, _range);

            if (_axis == 0) trans.position = new Vector3(pos.x + rand, pos.y, pos.z);
            if (_axis == 1) trans.position = new Vector3(pos.x, pos.y + rand, pos.z);
            if (_axis == 2) trans.position = new Vector3(pos.x, pos.y, pos.z + rand);
        }
    }

    public static void RandomRotation(int _axis)
    {
        if (!Selection.activeTransform) return;
        var selectedTransforms = Selection.transforms;
        Undo.RecordObjects(Selection.transforms, "Random Rotation");

        foreach (var trans in selectedTransforms)
        {
            Vector3 rot = trans.eulerAngles;

            if (_axis == 0) rot.x = Random.Range(0, 360f);
            if (_axis == 1) rot.y = Random.Range(0, 360f);
            if (_axis == 2) rot.z = Random.Range(0, 360f);

            trans.eulerAngles = rot;
        }
    }

    public static void RandomScale(float _range)
    {
        if (!Selection.activeTransform) return;
        var selectedTransforms = Selection.transforms;
        Undo.RecordObjects(Selection.transforms, "Random Scale");
        foreach (var trans in selectedTransforms)
        {
            float rand = System.Math.Abs(Random.Range(-_range, _range));
            trans.localScale = new Vector3(rand, rand, rand);
        }

    }
}
