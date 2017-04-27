using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

using System.Linq;

public class AlignToolsWindow: EditorWindow
{
    GUIContent xavg, xmax, xmin, yavg, ymin, ymax, zavg, zmin, zmax;

    public static void ShowWindow()
    {
        var window = GetWindow<AlignToolsWindow>();
        window.titleContent = new GUIContent("Align Tools");
        window.maxSize = new Vector2(135f, 170f);
        window.minSize = window.maxSize;
        //window.ShowUtility();
        //AlignToolsWindow window=(AlignToolsWindow)EditorWindow.GetWindow(typeof(AlignToolsWindow), false, "Align and distribute tool");
        //window.Focus();
        //window.Repaint();        
        //return window;
    }

    void OnEnable()
    {
        xmin = new GUIContent((Texture)Resources.Load("XMin"), "Align X minimum");
        xavg = new GUIContent((Texture)Resources.Load("XAvg"), "Align X average");
        xmax = new GUIContent((Texture)Resources.Load("XMax"), "Align X maximum");

        ymin = new GUIContent((Texture)Resources.Load("YMin"), "Align Y minimum");
        yavg = new GUIContent((Texture)Resources.Load("YAvg"), "Align Y average");
        ymax = new GUIContent((Texture)Resources.Load("YMax"), "Align Y maximum");

        zmin = new GUIContent((Texture)Resources.Load("ZMin"), "Align Z minimum");
        zavg = new GUIContent((Texture)Resources.Load("ZAvg"), "Align Z average");
        zmax = new GUIContent((Texture)Resources.Load("ZMax"), "Align Z maximum");
    }
    void OnGUI()
    {

        GUILayout.BeginArea(new Rect(10, 10, 135, 170));

        GUILayout.BeginHorizontal();
        if (GUILayout.Button(xmin, GUILayout.Height(35), GUILayout.Width(35)))
        {
            AlignTools.Align(AlignTools.AlignAxis.x, AlignTools.AlignMode.min);
        }
        if (GUILayout.Button(xavg, GUILayout.Height(35), GUILayout.Width(35)))
        {
            AlignTools.AlignAverage(AlignTools.AlignAxis.x);
        }
        if (GUILayout.Button(xmax, GUILayout.Height(35), GUILayout.Width(35)))
        {
            AlignTools.Align(AlignTools.AlignAxis.x, AlignTools.AlignMode.max);
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button(ymin, GUILayout.Height(35), GUILayout.Width(35)))
        {
            AlignTools.Align(AlignTools.AlignAxis.y, AlignTools.AlignMode.min);
        }
        if (GUILayout.Button(yavg, GUILayout.Height(35), GUILayout.Width(35)))
        {
            AlignTools.AlignAverage(AlignTools.AlignAxis.y);
        }
        if (GUILayout.Button(ymax, GUILayout.Height(35), GUILayout.Width(35)))
        {
            AlignTools.Align(AlignTools.AlignAxis.y, AlignTools.AlignMode.max);
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button(zmin, GUILayout.Height(35), GUILayout.Width(35)))
        {
            AlignTools.Align(AlignTools.AlignAxis.z, AlignTools.AlignMode.min);
        }
        if (GUILayout.Button(zavg, GUILayout.Height(35), GUILayout.Width(35)))
        {
            AlignTools.AlignAverage(AlignTools.AlignAxis.z);
        }
        if (GUILayout.Button(zmax, GUILayout.Height(35), GUILayout.Width(35)))
        {
            AlignTools.Align(AlignTools.AlignAxis.z, AlignTools.AlignMode.max);
        }
        GUILayout.EndHorizontal();

        GUILayout.EndArea();
    }
}
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
        //Debug.Log("avg: " + avg);
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
                Debug.Log(targetPos.x);
            break;

            case AlignMode.max:
                targetPos = selected[selected.Length-1].position;
                Debug.Log(targetPos.x);
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

