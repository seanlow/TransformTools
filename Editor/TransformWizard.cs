using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TransformWizard : EditorWindow
{
    GUIContent xavg, xmax, xmin, yavg, ymin, ymax, zavg, zmin, zmax, distx, disty, distz, scatter, planter;
    static float transMin, transMax, rotMin, rotMax, scaleMin, scaleMax;
    static string randomAxisKey = "TransformRandomAxis";
    static string transMinKey = "TransformRandomSTransMin";
    static string transMaxKey = "TransformRandomSTransMax";
    static string rotMinKey = "TransformRandomSRotMin";
    static string rotMaxKey = "TransformRandomSRotMax";
    static string scaleMinKey = "TransformRandomScaleMin";
    static string scaleMaxKey = "TransformRandomScaleMax";
    int randomAxis;
    string[] axisOption = { "X", "Y", "Z", "All" };

    public static void ShowWindow()
    {
        var window = GetWindow<TransformWizard>();
        window.titleContent = new GUIContent("Transform Wizard/ Settings");
        window.ShowUtility();
    }

    void OnEnable()
    {
        xmin = new GUIContent((Texture)Resources.Load("XMin"), "minimum");
        xavg = new GUIContent((Texture)Resources.Load("XAvg"), "average");
        xmax = new GUIContent((Texture)Resources.Load("XMax"), "maximum");

        ymin = new GUIContent((Texture)Resources.Load("YMin"), "minimum");
        yavg = new GUIContent((Texture)Resources.Load("YAvg"), "average");
        ymax = new GUIContent((Texture)Resources.Load("YMax"), "maximum");

        zmin = new GUIContent((Texture)Resources.Load("ZMin"), "minimum");
        zavg = new GUIContent((Texture)Resources.Load("ZAvg"), "average");
        zmax = new GUIContent((Texture)Resources.Load("ZMax"), "maximum");

        distx = new GUIContent((Texture)Resources.Load("DistX"), "along X");
        disty = new GUIContent((Texture)Resources.Load("DistY"), "along Y");
        distz = new GUIContent((Texture)Resources.Load("DistZ"), "along Z");

        scatter = new GUIContent((Texture)Resources.Load("Scatter"), "scatter in bound");
        planter = new GUIContent((Texture)Resources.Load("Planter"), "planter in bound");

        // Load EditorPrefs
        if (EditorPrefs.HasKey(randomAxisKey))
        {
            randomAxis = EditorPrefs.GetInt(randomAxisKey, randomAxis);
        }
        else randomAxis = 0;

        if (EditorPrefs.HasKey(transMinKey))
        {
            transMin = EditorPrefs.GetFloat(transMinKey, scaleMin);
        }
        else transMin = 1f;
        if (EditorPrefs.HasKey(transMaxKey))
        {
            transMax = EditorPrefs.GetFloat(transMaxKey, scaleMax);
        }
        else transMax = 1f;

        if (EditorPrefs.HasKey(rotMinKey))
        {
            rotMin = EditorPrefs.GetFloat(rotMinKey, rotMin);
        }
        else rotMin = 0f;
        if (EditorPrefs.HasKey(rotMaxKey))
        {
            rotMax = EditorPrefs.GetFloat(rotMaxKey, rotMax);
        }
        else rotMax = 360f;

        if (EditorPrefs.HasKey(scaleMinKey))
        {
            scaleMin = EditorPrefs.GetFloat(scaleMinKey, scaleMin);
        }
        else scaleMin = 1f;
        if (EditorPrefs.HasKey(scaleMaxKey))
        {
            scaleMax = EditorPrefs.GetFloat(scaleMaxKey, scaleMax);
        }
        else scaleMax = 1f;
    }

    void AlignmentGUI()
    {
        GUILayout.Label("Alignment", EditorStyles.boldLabel);
        GUILayout.BeginVertical("box");

        GUILayout.BeginHorizontal();
        GUILayout.Label("X", EditorStyles.boldLabel, GUILayout.MaxWidth(30));
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
        GUILayout.Label("Y", EditorStyles.boldLabel, GUILayout.MaxWidth(30));
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
        GUILayout.Label("Z", EditorStyles.boldLabel, GUILayout.MaxWidth(30));
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
        GUILayout.EndVertical();
    }

    void DistributeGUI()
    {
        GUILayout.Label("Distribute", EditorStyles.boldLabel);
        GUILayout.BeginVertical("box");

        GUILayout.BeginHorizontal();
        GUILayout.Label("", EditorStyles.boldLabel, GUILayout.MaxWidth(30));
        if (GUILayout.Button(distx, GUILayout.Height(35), GUILayout.Width(35)))
        {
            DistributeTools.AlongAxis(0);
        }

        if (GUILayout.Button(disty, GUILayout.Height(35), GUILayout.Width(35)))
        {
            DistributeTools.AlongAxis(1);
        }

        if (GUILayout.Button(distz, GUILayout.Height(35), GUILayout.Width(35)))
        {
            DistributeTools.AlongAxis(2);
        }
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
    }

    void PlacerGUI()
    {
        GUILayout.BeginHorizontal();

        GUILayout.BeginVertical(GUI.skin.box);
        GUILayout.Label("Scatter", EditorStyles.boldLabel);
        if (GUILayout.Button(scatter, GUILayout.Height(35), GUILayout.Width(35)))
        {
            PlaceTools.InBound();
        }
        GUILayout.EndVertical();

        GUILayout.BeginVertical(GUI.skin.box);
        GUILayout.Label("Planter", EditorStyles.boldLabel);
        if (GUILayout.Button(planter, GUILayout.Height(35), GUILayout.Width(35)))
        {
            PlaceTools.Planter();
        }
        GUILayout.EndVertical();


        GUILayout.EndHorizontal();
    }

    void RandomGUI()
    {
        GUILayout.Label("Randomize", EditorStyles.boldLabel);
        GUILayout.BeginVertical("box");

        EditorGUIUtility.labelWidth = 30;
        EditorGUIUtility.fieldWidth = 50;

        GUILayout.Label("Axis", EditorStyles.boldLabel);
        randomAxis = GUILayout.SelectionGrid(randomAxis, axisOption, axisOption.Length, "toggle");

        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

        GUILayout.Label("Local Position", EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();
        transMin = EditorGUILayout.FloatField("Min", transMin);
        transMax = EditorGUILayout.FloatField("Max", transMax);
        if (GUILayout.Button("Position", GUILayout.MaxWidth(75)))
        {            
            RandomTools.RandomPosition(randomAxis, transMin, transMax);
        }
        GUILayout.EndHorizontal();

        GUILayout.Label("Rotation", EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();
        rotMin = EditorGUILayout.FloatField("Min", rotMin);
        rotMax = EditorGUILayout.FloatField("Max", rotMax);
        if (GUILayout.Button("Rotate", GUILayout.MaxWidth(75)))
        {
            RandomTools.RandomRotation(randomAxis, rotMin, rotMax);
        }
        GUILayout.EndHorizontal();

        GUILayout.Label("Local Scale", EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();
        scaleMin = EditorGUILayout.FloatField("Min", scaleMin);
        scaleMax = EditorGUILayout.FloatField("Max", scaleMax);
        if (GUILayout.Button("Scale", GUILayout.MaxWidth(75)))
        {
            RandomTools.RandomScale(randomAxis, scaleMin, scaleMax);
        }

        GUILayout.EndHorizontal();

        GUILayout.EndVertical();

        EditorPrefs.SetInt(randomAxisKey, randomAxis);
        EditorPrefs.SetFloat(transMinKey, transMin);
        EditorPrefs.SetFloat(transMaxKey, transMax);
        EditorPrefs.SetFloat(scaleMinKey, scaleMin);
        EditorPrefs.SetFloat(scaleMaxKey, scaleMax);

    }
    void OnGUI()
    {
        GUILayout.BeginScrollView(new Vector2 (0,0));
        AlignmentGUI();
        DistributeGUI();
        RandomGUI();
        PlacerGUI();
        GUILayout.EndScrollView();
    }
}