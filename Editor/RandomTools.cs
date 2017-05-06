using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

using System.Linq;

public class RandomTools
{
    public static void RandomPosition(int _axis, float _min, float _max)
    {
        if (!Selection.activeTransform) { Debug.Log("No selection"); return; }
        var selectedTransforms = Selection.transforms;
        Undo.RecordObjects(Selection.transforms, "Random Position");

        foreach (var trans in selectedTransforms)
        {
            Vector3 pos = trans.localPosition;
            float rand = Random.Range(_min, _max);

            if (_axis == 0) trans.localPosition = new Vector3(rand, pos.y, pos.z);
            if (_axis == 1) trans.localPosition = new Vector3(pos.x, rand, pos.z);
            if (_axis == 2) trans.localPosition = new Vector3(pos.x, pos.y, rand);
            if (_axis == 3) trans.localPosition = 
                new Vector3(Random.Range(_min, _max), Random.Range(_min, _max), Random.Range(_min, _max));
        }
    }

    public static void RandomRotation(int _axis, float _min, float _max)
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
            if (_axis == 3) rot =
                new Vector3(Random.Range(_min, _max), Random.Range(_min, _max), Random.Range(_min, _max));

            trans.eulerAngles = rot;
        }
    }

    public static void RandomScale(int _axis, float _min, float _max)
    {
        if (!Selection.activeTransform) return;
        var selectedTransforms = Selection.transforms;
        Undo.RecordObjects(Selection.transforms, "Random Scale");
        foreach (var trans in selectedTransforms)
        {

            Vector3 scale = trans.localScale;
            float rand = System.Math.Abs(Random.Range(_min, _max));

            if (_axis == 0) scale = new Vector3(rand, scale.y, scale.z);
            if (_axis == 1) scale = new Vector3(scale.x, rand, scale.z);
            if (_axis == 2) scale = new Vector3(scale.x, scale.y, rand);
            if (_axis == 3) scale =
                new Vector3(System.Math.Abs(Random.Range(_min, _max)), System.Math.Abs(Random.Range(_min, _max)), System.Math.Abs(Random.Range(_min, _max)));

            trans.localScale = scale;
        }

    }
}
