using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PointCloud))]
public class PointCloudEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Regenerate Points"))
        {
            var pointCloud = (PointCloud)target;
            pointCloud.GeneratePoints();
            UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
        }
    }
}
