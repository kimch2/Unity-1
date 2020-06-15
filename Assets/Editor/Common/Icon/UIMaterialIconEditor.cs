using ETModel;
using UnityEditor;
using UnityEngine;

namespace ETEditor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(UIMaterialIcon))]
    public class UIMaterialIconEditor : Editor
    {
        private SerializedProperty icon;
        private SerializedProperty size;
        private SerializedProperty color;
        private SerializedProperty raycastTarget;
        private SerializedProperty font;

        void OnEnable()
        {
            icon = serializedObject.FindProperty("icon");
            size = serializedObject.FindProperty("size");
            color = serializedObject.FindProperty("color");
            raycastTarget = serializedObject.FindProperty("raycastTarget");
            font = serializedObject.FindProperty("font");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(size, new GUIContent("Size"));
            EditorGUILayout.PropertyField(color, new GUIContent("Color"));
            EditorGUILayout.PropertyField(raycastTarget, new GUIContent("RaycastTarget"));
            EditorGUILayout.PropertyField(font, new GUIContent("Font"));

            if (GUILayout.Button(new GUIContent("Pick Icon", "选择图标"), GUILayout.ExpandWidth(true), GUILayout.Height(36)))
            {
                MaterialIconPickerWindow.Show(this);
            }

            EditorGUILayout.LabelField(icon.stringValue, EditorStyles.centeredGreyMiniLabel, GUILayout.ExpandWidth(true), GUILayout.Height(36));

            serializedObject.ApplyModifiedProperties();
        }
    }
}