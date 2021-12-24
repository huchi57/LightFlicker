using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Light))]
public class LightFlicker : MonoBehaviour
{
    // [Header("Flicker Pattern (a: 0% / m: 100% / z: 200% Normal Brightness)")]
    [SerializeField] private string _pattern = "m";
    [SerializeField] private LightFlickerUtility.Preset _preset = LightFlickerUtility.Preset.Normal;
    [SerializeField] private float _normalBrightness = 1;

    // [Header("Speed Settings")]
    [SerializeField] private float _patternDuration = 1;
    [SerializeField] private bool _lerp = true;

    // Serialized for custom editor
    [SerializeField] [HideInInspector] private bool _playingInEditMode = false;
    [SerializeField] [HideInInspector] private AnimationCurve _intensityCurve = new AnimationCurve();

    // Internal variables
    private Light _light = default;
    private string _cachedPattern = default;
    private LightFlickerUtility.Preset _cachedPreset = default;
    private float _timer = 0;

    public string Pattern 
    { 
        get => _pattern; 
        set 
        { 
            _pattern = RestrictToLowercaseAlphabets(value); 
        } 
    }

    public LightFlickerUtility.Preset PresetPattern 
    { 
        get => _preset; 
        set 
        { 
            _preset = value; 
            _pattern = LightFlickerUtility.GetPatterFromPreset(_preset, _pattern); 
        } 
    }

    private Light Light
    {
        get
        {
            if (_light == null)
            {
                _light = GetComponent<Light>();
            }
            return _light;
        }
    }

    public float NormalBrightness { get => _normalBrightness; set => _normalBrightness = value; }
    public float PatternDuration { get => _patternDuration; set => _patternDuration = value; }
    public bool Lerp { get => _lerp; set => _lerp = value; }
    public float Progress => ((_timer / _patternDuration) * _pattern.Length - 1) / _pattern.Length;

    private string RestrictToLowercaseAlphabets(string input)
    {
        // Lower alphabets, i.e. 'a'-'z', have ASCII values ranged from 97 to 122 (In hex: from 61 to 7A)
        return Regex.Replace(input, @"[^\u0061-\u007A]+", string.Empty);
    }

    private void Update()
    {

#if UNITY_EDITOR
        if (!UnityEditor.EditorApplication.isPlaying && !_playingInEditMode)
        {
            Reset();
            return;
        }

        if (UnityEditor.EditorApplication.isPlaying)
        {
            _playingInEditMode = false;
        }
#endif

        _timer += Time.deltaTime;
        if (_timer > _patternDuration)
        {
            _timer = 0;
        }

        var time = (_timer / _patternDuration) * _pattern.Length - 1;
        Light.intensity = _intensityCurve.Evaluate(_lerp ? time : Mathf.Floor(time)) * _normalBrightness;
    }

    private void Awake()
    {
        _timer = Random.Range(0, _patternDuration);
    }

    private void OnValidate()
    {
        _pattern = RestrictToLowercaseAlphabets(_pattern);

        if (_normalBrightness < 0)
        {
            _normalBrightness = 0;
        }

        if (_patternDuration < 0.001f)
        {
            _patternDuration = 0.001f;
        }

        if (_cachedPreset != _preset)
        {
            _cachedPreset = _preset;
            _pattern = LightFlickerUtility.GetPatterFromPreset(_preset, _pattern);
            _cachedPattern = _pattern;
            RecalculateIntensityCurve();
        }

        if (!_cachedPattern.Equals(_pattern))
        {
            _cachedPattern = _pattern;
            _preset = LightFlickerUtility.Preset.Custom;
            _cachedPreset = _preset;
            RecalculateIntensityCurve();
        }

        Light.intensity = _normalBrightness;
    }

    private void RecalculateIntensityCurve()
    {
        var keyframes = new List<Keyframe>();
        for (int i = 0; i < _pattern.Length; i++)
        {
            keyframes.Add
            (
                new Keyframe
                {
                    time = i,
                    value = (_pattern[i] - 'a') / 12.5f,
                    inTangent = 0,
                    outTangent = 0,
                }
            );
        }
        
        // "Magic Keyframe" for array size = 1
        if (_pattern.Length <= 1)
        {
            keyframes.Add(new Keyframe { time = 1, value = keyframes[0].value });
        }
        _intensityCurve.keys = keyframes.ToArray();
        _intensityCurve.preWrapMode = WrapMode.Loop;
        _intensityCurve.postWrapMode = WrapMode.Loop;
    }

    private void Reset()
    {
        Light.intensity = _normalBrightness;
        _playingInEditMode = false;
    }

#if UNITY_EDITOR
    private void OnEnable()
    {
        UnityEditor.EditorApplication.update += Update;
        Reset();
    }

    private void OnDisable()
    {
        UnityEditor.EditorApplication.update -= Update;
        Reset();
    }
#endif

}
