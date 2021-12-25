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
    private SerializedProperty _intensityCurve = default;
    private SerializedProperty _playingInEditMode = default;

    private static Texture2D _red = null;
    private GUIStyle _cacheStyle = default;
    private GUIStyle _style = default;

    private LightFlicker Target => (LightFlicker) target;
    private SerializedProperty Pattern { get => GetPropertyByName(_pattern, nameof(_pattern)); }
    private SerializedProperty Preset { get => GetPropertyByName(_preset, nameof(_preset)); }
    private SerializedProperty NormalBrightness { get => GetPropertyByName(_normalBrightness, nameof(_normalBrightness)); }
    private SerializedProperty PatternDuration { get => GetPropertyByName(_patternDuration, nameof(_patternDuration)); }
    private SerializedProperty Lerp { get => GetPropertyByName(_lerp, nameof(_lerp)); }
    private SerializedProperty IntensityCurve { get => GetPropertyByName(_intensityCurve, nameof(_intensityCurve)); }
    private SerializedProperty PlayingInEditMode { get => GetPropertyByName(_playingInEditMode, nameof(_playingInEditMode)); }
    
    private static Texture2D Red
    {
        get
        {
            if (_red == null)
            {
                _red = new Texture2D(1, 1);
                _red.SetPixel(0, 0, Color.red);
                _red.Apply();
            }
            return _red;
        }
    }

    public override void OnInspectorGUI()
    {
        Repaint();
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

    private SerializedProperty GetPropertyByName(SerializedProperty property, string name)
    {
        if (property == null)
        {
            property = serializedObject.FindProperty(name);
        }
        return property;
    }

    private void DrawPreviewGraph()
    {
        GUILayout.Label("Flickering Pattern Preview", EditorStyles.boldLabel);
        using (var _ = new GUILayout.HorizontalScope(GUILayout.Height(_graphHeight)))
        {
            using (var __ = new GUILayout.VerticalScope(GUILayout.Width(40)))
            {
                _style.alignment = TextAnchor.MiddleLeft;
                GUILayout.Label("200%", GUILayout.Width(40), GUILayout.Height(_graphHeight / 3));
                GUILayout.Label("100%", GUILayout.Width(40), GUILayout.Height(_graphHeight / 3));
                GUILayout.Label("0%", GUILayout.Width(40), GUILayout.Height(_graphHeight / 3));
            }

            GUI.enabled = false;
            EditorGUILayout.CurveField("", IntensityCurve.animationCurveValue, Color.yellow, new Rect(0, 0, Pattern.arraySize, 2), GUILayout.ExpandWidth(true), GUILayout.Height(_graphHeight));
            if ((Application.isPlaying || PlayingInEditMode.boolValue) && Target.Progress >= 0)
            {
                var rect = GUILayoutUtility.GetLastRect();
                GUI.DrawTexture(new Rect(rect.x + Target.Progress * rect.width, rect.y, 1, rect.height), Red);
            }
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
            GUILayout.Label("Normal Brightness scaled from a to z:", _style);
            GUILayout.Label("a - 0%, m - 100%, z - 200%", _style);
            _style.fontStyle = FontStyle.Normal;
            _style.alignment = TextAnchor.MiddleLeft;
        }
        GUILayout.EndHorizontal();
    }

    private void DrawProperties()
    {
        DropOptionalButton();

        GUILayout.Space(10);
        GUILayout.Label("Flicker Pattern", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(Pattern);
        EditorGUILayout.PropertyField(Preset);
        EditorGUILayout.PropertyField(NormalBrightness);
        EditorGUILayout.HelpBox("Normal Brightness overrides the Light component's Intensity value.", MessageType.Info);

        GUILayout.Space(10);
        GUILayout.Label("Speed Settings", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(PatternDuration);
        EditorGUILayout.PropertyField(Lerp);
    }

    private void DropOptionalButton()
    {
        if (EditorApplication.isPlaying)
        {
            GUI.enabled = false;
            GUILayout.Button("Preview Button Unavailable in Play Mode");
            GUI.enabled = true;
        }
        else
        {
            if (PlayingInEditMode.boolValue)
            {
                var color = GUI.backgroundColor;
                GUI.backgroundColor = Color.red;
                if (GUILayout.Button($"{'\u25aa'} Stop Preview"))
                {
                    PlayingInEditMode.boolValue = false;
                }
                GUI.backgroundColor = color;
            }
            else
            {
                var color = GUI.backgroundColor;
                GUI.backgroundColor = Color.green;
                if (GUILayout.Button($"{'\u25b8'} Play Preview"))
                {
                    PlayingInEditMode.boolValue = true;
                }
                GUI.backgroundColor = color;
            }
        }
    }
}
