using UnityEngine;
using System.Text.RegularExpressions;

[RequireComponent(typeof(Light))]
public class LightFlicker : MonoBehaviour
{
    //[Header("Flicker Pattern (a: 0% / m: 100% / z: 200% Normal Brightness)")]
    [SerializeField] private string _pattern = "m";
    [SerializeField] private LightFlickerUtility.Preset _preset = LightFlickerUtility.Preset.Normal;
    [SerializeField] private float _normalBrightness = 1;

    //[Header("Speed Settings")]
    [SerializeField] private float _patternDuration = 1;
    [SerializeField] private bool _lerp = true;
    [SerializeField] private float _lerpSpeed = 10;

    private Light _light = default;
    private string _cachedPattern = default;
    private LightFlickerUtility.Preset _cachedPreset = default;
    private int _index = 0;
    private float _timer = 0;
    private float _targetIntensity = 0;

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

    public float NormalBrightness { get => _normalBrightness; set => _normalBrightness = value; }
    public float PatternDuration { get => _patternDuration; set => _patternDuration = value; }
    public bool Lerp { get => _lerp; set => _lerp = value; }
    public float LerpSpeed { get => _lerpSpeed; set => _lerpSpeed = value < 0 ? 0 : value; }

    private string RestrictToLowercaseAlphabets(string input)
    {
        // Lower alphabets, i.e. 'a'-'z', have ASCII values ranged from 97 to 122 (In hex: from 61 to 7A)
        return Regex.Replace(input, @"[^\u0061-\u007A]+", string.Empty);
    }
    
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _patternDuration)
        {
            _timer = 0;
        }

        _index = (int)((_timer / _patternDuration) * _pattern.Length - 1);
        _index = Mathf.Clamp(_index, 0, _pattern.Length - 1);
        _targetIntensity = (_pattern[_index] - 'a') / 12.5f * _normalBrightness;
        _light.intensity = _lerp ? Mathf.Lerp(_light.intensity, _targetIntensity, _lerpSpeed * Time.deltaTime) : _targetIntensity;
    }

    private void Awake()
    {
        _light = GetComponent<Light>();
        _index = Random.Range(0, _pattern.Length);
    }

    private void OnValidate()
    {
        _pattern = RestrictToLowercaseAlphabets(_pattern);

        if (_cachedPreset != _preset)
        {
            _cachedPreset = _preset;
            _pattern = LightFlickerUtility.GetPatterFromPreset(_preset, _pattern);
            _cachedPattern = _pattern;
        }

        if (_cachedPattern != _pattern)
        {
            _cachedPattern = _pattern;
            _preset = LightFlickerUtility.Preset.Custom;
            _cachedPreset = _preset;
        }

        if (_lerpSpeed < 0)
        {
            _lerpSpeed = 0;
        }
    }

    private void Reset()
    {
        _light = GetComponent<Light>();
        _normalBrightness = _light.intensity;
    }
}
