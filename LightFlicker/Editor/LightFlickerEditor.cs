using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LightFlicker))]
public class LightFlickerEditor : Editor
{
    private const float _graphHeight = 90f;

    private SerializedProperty _pattern = default;
    private SerializedProperty _preset = default;
    private SerializedProperty _normalBrightness = default;
    private SerializedProperty _patternDuration = default;
    private SerializedProperty _lerp = default;
    private SerializedProperty _lerpSpeed = default;

    private GUIStyle _cacheStyle = default;
    private GUIStyle _style = default;
    private AnimationCurve _patternCurve = default;
    private Rect _graphRect = default;

    private void Awake()
    {
        _pattern = serializedObject.FindProperty(nameof(_pattern));
        _preset = serializedObject.FindProperty(nameof(_preset));
        _normalBrightness = serializedObject.FindProperty(nameof(_normalBrightness));
        _patternDuration = serializedObject.FindProperty(nameof(_patternDuration));
        _lerp = serializedObject.FindProperty(nameof(_lerp));
        _lerpSpeed = serializedObject.FindProperty(nameof(_lerpSpeed));
        _patternCurve = new AnimationCurve();
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        _cacheStyle = GUI.skin.label;
        _style = _cacheStyle;

        DrawPreviewGraph();
        DrawHeaderInfo();
        GUILayout.Space(10);
        DrawProperties();

        GUI.skin.label = _cacheStyle;
        serializedObject.ApplyModifiedProperties();
    }

    private Keyframe[] GetKeyframes()
    {
        var keyframes = new List<Keyframe>();
        for (int i = 0; i < _pattern.arraySize; i++)
        {
            keyframes.Add
            (
                new Keyframe 
                { 
                    time = i, 
                    value = (_pattern.stringValue[i] - 'a') / 12.5f
                }
            );
        }

        // "Magic Keyframe" for array size = 1
        if (_pattern.arraySize <= 1)
        {
            keyframes.Add(new Keyframe { time = 1, value = keyframes[0].value });
        }
        return keyframes.ToArray();
    }

    private void DrawPreviewGraph()
    {
        GUILayout.Label("Flickering Pattern Preview", EditorStyles.boldLabel);
        using (var scope = new GUILayout.HorizontalScope(GUILayout.Height(_graphHeight)))
        {
            using (var scope2 = new GUILayout.VerticalScope(GUILayout.Width(40)))
            {
                _style.alignment = TextAnchor.MiddleLeft;
                GUILayout.Label("200%", GUILayout.Width(40), GUILayout.Height(_graphHeight / 3));
                GUILayout.Label("100%", GUILayout.Width(40), GUILayout.Height(_graphHeight / 3));
                GUILayout.Label("0%", GUILayout.Width(40), GUILayout.Height(_graphHeight / 3));
            }

            GUI.enabled = false;
            _patternCurve.keys = GetKeyframes();
            EditorGUILayout.CurveField("", _patternCurve, Color.yellow, new Rect(0, 0, _pattern.arraySize - 1, 2), GUILayout.ExpandWidth(true), GUILayout.Height(_graphHeight));
            GUI.enabled = true;
        }
    }

    private void DrawHeaderInfo()
    {
        GUILayout.BeginHorizontal();
        using (var scope = new GUILayout.VerticalScope())
        {
            _style.fontStyle = FontStyle.Italic;
            _style.alignment = TextAnchor.MiddleCenter;
            GUILayout.Label("Normal Brightness scale from a to z:", _style);
            GUILayout.Label("a - 0%, m - 100%, z - 200%", _style);
            _style.fontStyle = FontStyle.Normal;
            _style.alignment = TextAnchor.MiddleLeft;
        }
        GUILayout.EndHorizontal();
    }

    private void DrawProperties()
    {
        GUILayout.Label("Flicker Pattern", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(_pattern);
        EditorGUILayout.PropertyField(_preset);
        EditorGUILayout.PropertyField(_normalBrightness);

        GUILayout.Space(10);
        GUILayout.Label("Speed Settings", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(_patternDuration);
        EditorGUILayout.PropertyField(_lerp);
        EditorGUILayout.PropertyField(_lerpSpeed);
    }
}
