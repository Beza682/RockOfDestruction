using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SoundEditor))]
public class SoundEditorGUI : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        SoundEditor editor = (SoundEditor)target;

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Key", GUILayout.MaxWidth(60));
        editor.key = EditorGUILayout.TextField(editor.key);
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Add"))
            editor.Loading(editor.key);
        else if (GUILayout.Button("Delete"))
            editor.Deleting(editor.key);
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("sndList"), true);
        serializedObject.ApplyModifiedProperties();
    }
}