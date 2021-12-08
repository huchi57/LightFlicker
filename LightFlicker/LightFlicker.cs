using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

[RequireComponent(typeof(Light))]
public class LightFlicker : MonoBehaviour
{
    private static readonly string _none = "a";
    private static readonly string _normal = "m";
    private static readonly string _doubleBrightness = "z";
    private static readonly string _fluorescentFlicker = "mmamammmmammamamaaamammma";
    private static readonly string _slowStrobe = "aaaaaaaazzzzzzzz";
    private static readonly string _gentlePulse = "jklmnopqrstuvwxyzyxwvutsrqponmlkj";
    private static readonly string _slowStrongPulse = "abcdefghijklmnopqrstuvwxyzyxwvutsrqponmlkjihgfedcba";
    private static readonly string _slowPulseNotFadeToBlack = "abcdefghijklmnopqrrqponmlkjihgfedcba";
    private static readonly string _fastStrobe = "mamamamamama";
    private static readonly string _underwaterLightMutation = "mmnnmmnnnmmnn";
    private static readonly string _candle1 = "mmmmmaaaaammmmmaaaaaabcdefgabcdefg";
    private static readonly string _candle2 = "mmmaaaabcdefgmmmmaaaammmaamm";
    private static readonly string _candle3 = "mmmaaammmaaammmabcdefaaaammmmabcdefmmmaaaa";
    private static readonly string _flicker1 = "mmnmmommommnonmmonqnmmo";
    private static readonly string _flicker2 = "nmonqnmomnmomomno";

    public enum Preset
    { 
        None,
        Normal,
        DoubleBrightness,
        FluorescentFlicker,
        SlowStrobe,
        GentlePulse,
        SlowStrongPulse,
        SlowPulseNotFadeToBlack,
        FastStrobe,
        UnderwaterLightMutation,
        [InspectorName("Candle (First Variety)")]   Candle1,
        [InspectorName("Candle (Second Variety)")]  Candle2,
        [InspectorName("Candle (Third Variety)")]   Candle3,
        [InspectorName("Flicker (First Variety)")]  Flicker1,
        [InspectorName("Flicker (Second Variety)")] Flicker2,
        Custom
    }

    [SerializeField] private string _pattern = default;
    [SerializeField] private Preset _preset = Preset.Normal;
    [SerializeField] private float _normalBrightness = 1;

    private Light _light = default;
    private string _cachedPattern = default;
    private Preset _cachedPreset = default;

    public string Pattern 
    { 
        get => _pattern; 
        set 
        { 
            _pattern = RestrictToLowercaseAlphabets(value); 
        } 
    }

    public Preset PresetPattern 
    { 
        get => _preset; 
        set 
        { 
            _preset = value; 
            _pattern = GetPatterFromPreset(_preset); 
        } 
    }

    public float NormalBrightness { get => _normalBrightness; set => _normalBrightness = value; }

    private string GetPatterFromPreset(Preset preset)
    {
        switch (preset)
        {
            case Preset.None: return _none;
            case Preset.Normal: return _normal;
            case Preset.DoubleBrightness: return _doubleBrightness;
            case Preset.FluorescentFlicker: return _fluorescentFlicker;
            case Preset.SlowStrobe: return _slowStrobe;
            case Preset.GentlePulse: return _gentlePulse;
            case Preset.SlowStrongPulse: return _slowStrongPulse;
            case Preset.SlowPulseNotFadeToBlack: return _slowPulseNotFadeToBlack;
            case Preset.FastStrobe: return _fastStrobe;
            case Preset.UnderwaterLightMutation: return _underwaterLightMutation;
            case Preset.Candle1: return _candle1;
            case Preset.Candle2: return _candle2;
            case Preset.Candle3: return _candle3;
            case Preset.Flicker1: return _flicker1;
            case Preset.Flicker2: return _flicker2;
            case Preset.Custom: return _pattern;
            default: break;
        }
        return _pattern;
    }

    private string RestrictToLowercaseAlphabets(string input)
    {
        // Lower alphabets ASCII ranged from 97 too 122
        return Regex.Replace(input, @"[^\u0061-\u007A]+", string.Empty);
    }

    private void Awake()
    {
        _light = GetComponent<Light>();
    }

    private void Update()
    {
        
    }

    private void OnValidate()
    {
        _pattern = RestrictToLowercaseAlphabets(_pattern);
        if (_cachedPreset != _preset)
        {
            _cachedPreset = _preset;
            _pattern = GetPatterFromPreset(_preset);
            _cachedPattern = _pattern;
        }
        if (_cachedPattern != _pattern)
        {
            _cachedPattern = _pattern;
            _preset = Preset.Custom;
            _cachedPreset = _preset;
        }
    }

    private void Reset()
    {
        _light = GetComponent<Light>();
        _normalBrightness = _light.intensity;
    }
}