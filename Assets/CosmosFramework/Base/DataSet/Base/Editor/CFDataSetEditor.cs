﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace Cosmos{
    /// <summary>
    /// 子类也继承按钮
    /// </summary>
    [CustomEditor(typeof(CFDataSet),true)]
    public class CFDataSetEditor : Editor
    {
        CFDataSet cfDataSet;
        private void OnEnable()
        {
            cfDataSet = target as CFDataSet;
        }
        public override void OnInspectorGUI()
        {
            GUILayout.BeginVertical("box");
            DrawCFButton();
            GUILayout.EndVertical();
            base.OnInspectorGUI();
        }
        /// <summary>
        /// 绘制公共功能按钮
        /// </summary>
       protected virtual void DrawCFButton()
        {
            EditorGUILayout.HelpBox("Preview预览，Reset按钮执行清空下列所有数值", MessageType.Info,true);
            //GUILayout.Label("Preview预览，Reset按钮执行清空下列所有数值");
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Preview", GUILayout.Height(20)))
            {
                cfDataSet.Preview();
            }
            if (GUILayout.Button("Reset",GUILayout.Height(20)))
            {
               var canReset= EditorUtility.DisplayDialog("Reset ScriptableObject", "You will reset ScriptableObject Properties", "Reset", "Cancel");
                if (canReset)
                    cfDataSet.Reset();
            }
            GUILayout.EndHorizontal();
        }
    }
}