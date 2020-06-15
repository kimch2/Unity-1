//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;
//using System;

//namespace ETModel
//{
//    [CustomEditor(typeof(InputSetting))]
//    public class CameraInputEditor : Editor
//    {
//        public SerializedProperty Input;

//        public SerializedProperty Speed;
//        public SerializedProperty NewX, NewY, NewZ;
//        public SerializedProperty SummationX, SummationY, SummationZ;
//        public SerializedProperty NewPosX, NewPosY;
//        public SerializedProperty MaxDistance, MinDistance;
//        public SerializedProperty ClampMaxX, ClampMinX;
//        public SerializedProperty ClampMaxY, ClampMinY;

//        private SerializedObject _target;
//        private void OnEnable()
//        {
//            Input = serializedObject.FindProperty("Input");
//        }

//        public override void OnInspectorGUI()
//        {
//            serializedObject.Update();
//            EditorGUILayout.PropertyField(Input, new GUIContent("配置文件"));
//            GUILayout.Space(5);

//            if (Input.objectReferenceValue != null)
//            {
//                if (_target == null)
//                    _target = new SerializedObject(Input.objectReferenceValue);
//                Speed = _target.FindProperty("Speed");
//                NewX = _target.FindProperty("NewX");
//                NewY = _target.FindProperty("NewY");
//                NewZ = _target.FindProperty("Speed");
//                SummationX = _target.FindProperty("SummationX");
//                SummationY = _target.FindProperty("SummationY");
//                SummationZ = _target.FindProperty("SummationZ");
//                NewPosX = _target.FindProperty("NewPosX");
//                NewPosY = _target.FindProperty("NewPosY");
//                MaxDistance = _target.FindProperty("MaxDistance");
//                MinDistance = _target.FindProperty("MinDistance");
//                ClampMaxX = _target.FindProperty("ClampMaxX");
//                ClampMinX = _target.FindProperty("ClampMinX");
//                ClampMaxY = _target.FindProperty("ClampMaxY");
//                ClampMinY = _target.FindProperty("ClampMinY");
 
//                DrawInspector();
//            }
//            serializedObject.ApplyModifiedProperties();
//        }

//        private void DrawInspector()
//        {
//            EditorGUILayout.BeginVertical("box");
//            EditorGUILayout.PropertyField(Speed, new GUIContent("Speed"));
//            GUILayout.Space(5);
//            EditorGUILayout.PropertyField(NewX, new GUIContent("NewX"));
//            GUILayout.Space(5);
//            EditorGUILayout.PropertyField(NewY, new GUIContent("NewY"));
//            GUILayout.Space(5);
//            EditorGUILayout.PropertyField(NewZ, new GUIContent("NewZ"));
//            GUILayout.Space(5);
//            EditorGUILayout.PropertyField(SummationX, new GUIContent("SummationX"));
//            GUILayout.Space(5);
//            EditorGUILayout.PropertyField(SummationY, new GUIContent("SummationY"));
//            GUILayout.Space(5);
//            EditorGUILayout.PropertyField(SummationZ, new GUIContent("SummationZ"));
//            GUILayout.Space(5);
//            EditorGUILayout.PropertyField(NewPosX, new GUIContent("NewPosX"));
//            GUILayout.Space(5);
//            EditorGUILayout.PropertyField(NewPosY, new GUIContent("NewPosY"));
//            GUILayout.Space(5);
//            EditorGUILayout.PropertyField(MaxDistance, new GUIContent("MaxDistance"));
//            GUILayout.Space(5);
//            EditorGUILayout.PropertyField(MinDistance, new GUIContent("MinDistance"));
//            GUILayout.Space(5);
//            EditorGUILayout.PropertyField(ClampMaxX, new GUIContent("ClampMaxX"));
//            GUILayout.Space(5);
//            EditorGUILayout.PropertyField(ClampMinX, new GUIContent("ClampMinX"));
//            GUILayout.Space(5);
//            EditorGUILayout.PropertyField(ClampMaxY, new GUIContent("ClampMaxY"));
//            GUILayout.Space(5);
//            EditorGUILayout.PropertyField(ClampMinY, new GUIContent("ClampMinY"));
//            GUILayout.Space(5);
//            EditorGUILayout.EndVertical();
//        }
//    }
//}
