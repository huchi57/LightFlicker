using UnityEngine;

public class LightFlickerUtility
{
    // Refereced from Valve style (Quake / Half-Life)
    // a: 0% / m: 100% / z: 200% Normal Brightness
    // Source: https://github.com/ValveSoftware/halflife/blob/c7240b965743a53a29491dd49320c88eecf6257b/dlls/world.cpp#L557-L605

    private const string _none = "a";
    private const string _normal = "m";
    private const string _doubleBrightness = "z";
    private const string _fluorescentFlicker = "mmamammmmammamamaaamammma";
    private const string _slowStrobe = "aaaaaaaazzzzzzzz";
    private const string _gentlePulse = "jklmnopqrstuvwxyzyxwvutsrqponmlkj";
    private const string _slowStrongPulse = "abcdefghijklmnopqrstuvwxyzyxwvutsrqponmlkjihgfedcba";
    private const string _slowPulseNotFadeToBlack = "abcdefghijklmnopqrrqponmlkjihgfedcba";
    private const string _fastStrobe = "mamamamamama";
    private const string _underwaterLightMutation = "mmnnmmnnnmmnn";
    private const string _candle1 = "mmmmmaaaaammmmmaaaaaabcdefgabcdefg";
    private const string _candle2 = "mmmaaaabcdefgmmmmaaaammmaamm";
    private const string _candle3 = "mmmaaammmaaammmabcdefaaaammmmabcdefmmmaaaa";
    private const string _flicker1 = "mmnmmommommnonmmonqnmmo";
    private const string _flicker2 = "nmonqnmomnmomomnon";

    [System.Serializable]
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
        [InspectorName("Candle (First Variety)")] Candle1,
        [InspectorName("Candle (Second Variety)")] Candle2,
        [InspectorName("Candle (Third Variety)")] Candle3,
        [InspectorName("Flicker (First Variety)")] Flicker1,
        [InspectorName("Flicker (Second Variety)")] Flicker2,
        Custom
    }

    public static string GetPatternFromPreset(Preset preset, string defaultValue)
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
            case Preset.Custom: return defaultValue;
            default: break;
        }
        return defaultValue;
    }
}
