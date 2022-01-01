# Unity Light Flicker
A component to make Unity's Light component flicker by a sequence of alphabets. This way of flickering lights is inspired by Valve games, which is used in games like Quake and Half-Life.

## Installation
1. Download the full repository (including the `Editor` folder).
2. You can try out the test scene under the `Test` folder to see how it works.

## Usage
1. Add `LightFlicker` to an existing `Light` component.
2. Click on the `Preview Pattern` to see the flicker pattern in action in Edit Mode. A preview Animation Curve and a timeline cursor will help visualize the change of the light intensity in a graph.
3. Select the flicker pattern from a group for presets or type in a custom pattern.
4. The pattern defines how the light intensity will change in sequence using alphabets a to z, from lowest (`a` being 0% brightness) to highest (`z` being 200% brightness).
5. Define the `Normal Brightness`, the light intensity at 100% brightness, or when the flicker pattern reaches the `m` letter.
  - **Note that this will override the `Intensity` field on the original `Light` component.**
6. Define the `Pattern Duration` and toggle the `Lerp` option (linear interpolation, i.e. whether the light intensity will change smoothly or not).
7. Some public properties are exposed so settings can be changed by other scripts, see the section below.

## Public Properties

| Property Name      | Type    | Description                                            |
| :---               | :---    | :---                                                   |
| `Pattern`          | `string`| The pattern of the Light component's intensity using alphabets between `a` to `z`, with `a` being 0%, `m` being 100%, and `z` being 200% intensity of the `NormalBrightness`. |
| `PresetPattern`    | `LightFlickerUtility.Preset` <br/>(Custom type) | Set the `pattern` from a selected collection of presets referenced from Valve's games. |
| `NormalBrightness` | `float` | The light intensity at 100% brightness. <br/>*Note: This will override the Light component's intensensity value.* |

**Speed Settings**
| Property Name      | Type    | Description                                            |
| :---               | :---    | :---                                                   |
| `PatternDuration`  | `float` | The duration for the pattern to iterate once.          |
| `Lerp`             | `bool`  | Whether the light intensity should change smoothly.    |

## `LightFlickerUtility.Preset`

| Preset Name | Sequence | Preview |
| -----       | -----    | -----   |
|  None<br/>`Preset.None`  | `a`
|  Normal<br/>`Preset.Normal`| `m`
|  Double Brightness<br/>`Preset.DoubleBrightness` | `z`
|  Fluorescent Flicker<br/>`Preset.FluorescentFlicker` | `mmamammmmammamamaaamammma`
|  Slow Strobe<br/>`Preset.SlowStrobe` | `aaaaaaaazzzzzzzz`
|  Gentle Pulse<br/>`Preset.GentlePulse` | `jklmnopqrstuvwxyzyxwvutsrqponmlkj`
|  Slow Strong Pulse<br/>`Preset.SlowStrongPulse` | `abcdefghijklmnopqrstuvwxyzyxwvutsrqponmlkjihgfedcba`
|  Slow Pulse Not Fade To Black<br/>`Preset.SlowPulseNotFadeToBlack` | `abcdefghijklmnopqrrqponmlkjihgfedcba`
|  Fast Strobe<br/>`Preset.FastStrobe` | `mamamamamama`
|  Underwater Light Mutation<br/>`Preset.UnderwaterLightMutation` | `mmnnmmnnnmmnn`
|  Candle (First Variety)<br/>`Preset.Candle1` | `mmmmmaaaaammmmmaaaaaabcdefgabcdefg`
|  Candle (Second Variety)<br/>`Preset.Candle2` | `mmmaaaabcdefgmmmmaaaammmaamm`
|  Candle (Third Variety)<br/>`Preset.Candle3` | `mmmaaammmaaammmabcdefaaaammmmabcdefmmmaaaa`
|  Flicker (First Variety)<br/>`Preset.Flicker1` | `mmnmmommommnonmmonqnmmo`
|  Flicker (Second Variety)<br/>`Preset.Flicker2`| `nmonqnmomnmomomnon`

## How Does it Work
An internal timer evaluates the light intensity based on a target character from the flicker pattern.

## References
https://github.com/ValveSoftware/halflife/blob/c7240b965743a53a29491dd49320c88eecf6257b/dlls/world.cpp#L557-L605

