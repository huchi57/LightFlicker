using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LightFlicker))]
public class LightFlickerEditor : Editor
{
    private SerializedProperty _pattern = default;
    private SerializedProperty _preset = default;
    private SerializedProperty _normalBrightness = default;
    private SerializedProperty _patternDuration = default;
    private SerializedProperty _lerp = default;
    private SerializedProperty _lerpSpeed = default;
    private GUIStyle _cacheStyle = default;
    private GUIStyle _style = default;

    private void Awake()
    {
        _pattern = serializedObject.FindProperty(nameof(_pattern));
        _preset = serializedObject.FindProperty(nameof(_preset));
        _normalBrightness = serializedObject.FindProperty(nameof(_normalBrightness));
        _patternDuration = serializedObject.FindProperty(nameof(_patternDuration));
        _lerp = serializedObject.FindProperty(nameof(_lerp));
        _lerpSpeed = serializedObject.FindProperty(nameof(_lerpSpeed));
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        _cacheStyle = GUI.skin.label;
        _style = _cacheStyle;

        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        _style.alignment = TextAnchor.MiddleLeft;
        GUILayout.Label("Alphabet [ a -", _style);
        GUILayout.Label("Strength [ 0%", _style);
        GUILayout.EndVertical();
        GUILayout.BeginVertical();
        _style.alignment = TextAnchor.MiddleCenter;
        GUILayout.Label("- m -", _style);
        GUILayout.Label("100%", _style);
        GUILayout.EndVertical();
        GUILayout.BeginVertical();
        _style.alignment = TextAnchor.MiddleRight;
        GUILayout.Label("- z ]", _style);
        GUILayout.Label("200% ]", _style);
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

        GUILayout.Space(10);
        GUILayout.Label("Flicker Pattern", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(_pattern);
        EditorGUILayout.PropertyField(_preset);
        EditorGUILayout.PropertyField(_normalBrightness);

        GUILayout.Space(10);
        GUILayout.Label("Speed Settings", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(_patternDuration);
        EditorGUILayout.PropertyField(_lerp);
        EditorGUILayout.PropertyField(_lerpSpeed);

        GUI.skin.label = _cacheStyle;
        serializedObject.ApplyModifiedProperties();
    }
}
