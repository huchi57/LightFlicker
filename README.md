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

**:warning: PHOTOSENSITIVE WARNING: The below section may contain animated GIFs with flashing images and are hidden by default. Click on the foldouts to reveal the original image.**

**None**
  <table>
  <tr>
    <td>Preview</td>
    <td>
      <details>
        <summary>Click to show</summary>
        <img src = "https://github.com/huchi57/LightFlicker/blob/main/Readme/Readme-None.gif" width = 400>
      </details>
    </td>
  </tr>
  <tr>    
    <td>Preset Enum</td>
    <td><code>LightFlickerUtility.Preset.None</code></td>
  </tr>
  <tr>    
    <td>Actual Sequence</td>
    <td><code>a</code></td>
  </tr>
  </table>
  
**Normal**
  <table>
  <tr>
    <td>Preview</td>
    <td>
      <details>
        <summary>Click to show</summary>
        <img src = "https://github.com/huchi57/LightFlicker/blob/main/Readme/Readme-Normal.gif" width = 400>
      </details>
    </td>
  </tr>
  <tr>    
    <td>Preset Enum</td>
    <td><code>LightFlickerUtility.Preset.Normal</code></td>
  </tr>
  <tr>    
    <td>Actual Sequence</td>
    <td><code>m</code></td>
  </tr>
  </table>

**Double Brightness**
  <table>
  <tr>
    <td>Preview</td>
    <td>
      <details>
        <summary>Click to show</summary>
        <img src = "https://github.com/huchi57/LightFlicker/blob/main/Readme/Readme-DoubleBrightness.gif" width = 400>
      </details>
    </td>
  </tr>
  <tr>    
    <td>Preset Enum</td>
    <td><code>LightFlickerUtility.Preset.DoubleBrightness</code></td>
  </tr>
  <tr>    
    <td>Actual Sequence</td>
    <td><code>z</code></td>
  </tr>
  </table>

**Fluorescent Flicker**
  <table>
  <tr>
    <td>Preview</td>
    <td>
      <details>
        <summary>Click to show</summary>
        <img src = "https://github.com/huchi57/LightFlicker/blob/main/Readme/Readme-FluorescentFlicker.gif" width = 400>
      </details>
    </td>
  </tr>
  <tr>    
    <td>Preset Enum</td>
    <td><code>LightFlickerUtility.Preset.FluorescentFlicker</code></td>
  </tr>
  <tr>    
    <td>Actual Sequence</td>
    <td><code>mmamammmmammamamaaamammma</code></td>
  </tr>
  </table>
  
**Slow Strobe**
  <table>
  <tr>
    <td>Preview</td>
    <td>
      <details>
        <summary>Click to show</summary>
        <img src = "https://github.com/huchi57/LightFlicker/blob/main/Readme/Readme-SlowStrobe.gif" width = 400>
      </details>
    </td>
  </tr>
  <tr>    
    <td>Preset Enum</td>
    <td><code>LightFlickerUtility.Preset.SlowStrobe</code></td>
  </tr>
  <tr>    
    <td>Actual Sequence</td>
    <td><code>aaaaaaaazzzzzzzz</code></td>
  </tr>
  </table>
  
**Gentle Pulse**
  <table>
  <tr>
    <td>Preview</td>
    <td>
      <details>
        <summary>Click to show</summary>
        <img src = "https://github.com/huchi57/LightFlicker/blob/main/Readme/Readme-GentlePulse.gif" width = 400>
      </details>
    </td>
  </tr>
  <tr>    
    <td>Preset Enum</td>
    <td><code>LightFlickerUtility.Preset.GentlePulse</code></td>
  </tr>
  <tr>    
    <td>Actual Sequence</td>
    <td><code>jklmnopqrstuvwxyzyxwvutsrqponmlkj</code></td>
  </tr>
  </table>
  
**Slow Strong Pulse**
  <table>
  <tr>
    <td>Preview</td>
    <td>
      <details>
        <summary>Click to show</summary>
        <img src = "https://github.com/huchi57/LightFlicker/blob/main/Readme/Readme-SlowStrongPulse.gif" width = 400>
      </details>
    </td>
  </tr>
  <tr>    
    <td>Preset Enum</td>
    <td><code>LightFlickerUtility.Preset.SlowStrongPulse</code></td>
  </tr>
  <tr>    
    <td>Actual Sequence</td>
    <td><code>abcdefghijklmnopqrstuvwxyzyxwvutsrqponmlkjihgfedcba</code></td>
  </tr>
  </table>
  
**Slow Pulse Not Fade To Black**
  <table>
  <tr>
    <td>Preview</td>
    <td>
      <details>
        <summary>Click to show</summary>
        <img src = "https://github.com/huchi57/LightFlicker/blob/main/Readme/Readme-SlowPulseNotFadeToBlack.gif" width = 400>
      </details>
    </td>
  </tr>
  <tr>    
    <td>Preset Enum</td>
    <td><code>LightFlickerUtility.Preset.SlowPulseNotFadeToBlack</code></td>
  </tr>
  <tr>    
    <td>Actual Sequence</td>
    <td><code>abcdefghijklmnopqrrqponmlkjihgfedcba</code></td>
  </tr>
  </table>
  
**Fast Strobe**
  <table>
  <tr>
    <td>Preview</td>
    <td>
      <details>
        <summary>Click to show</summary>
        <img src = "https://github.com/huchi57/LightFlicker/blob/main/Readme/Readme-FastStrobe.gif" width = 400>
      </details>
    </td>
  </tr>
  <tr>    
    <td>Preset Enum</td>
    <td><code>LightFlickerUtility.Preset.FastStrobe</code></td>
  </tr>
  <tr>    
    <td>Actual Sequence</td>
    <td><code>mamamamamama</code></td>
  </tr>
  </table>
  
**Underwater Light Mutation**
  <table>
  <tr>
    <td>Preview</td>
    <td>
      <details>
        <summary>Click to show</summary>
        <img src = "https://github.com/huchi57/LightFlicker/blob/main/Readme/Readme-UnderwaterLightMutation.gif" width = 400>
      </details>
    </td>
  </tr>
  <tr>    
    <td>Preset Enum</td>
    <td><code>LightFlickerUtility.Preset.UnderwaterLightMutation</code></td>
  </tr>
  <tr>    
    <td>Actual Sequence</td>
    <td><code>mmnnmmnnnmmnn</code></td>
  </tr>
  </table>
  
**Candle (First Variety)**
  <table>
  <tr>
    <td>Preview</td>
    <td>
      <details>
        <summary>Click to show</summary>
        <img src = "https://github.com/huchi57/LightFlicker/blob/main/Readme/Readme-Candle1.gif" width = 400>
      </details>
    </td>
  </tr>
  <tr>    
    <td>Preset Enum</td>
    <td><code>LightFlickerUtility.Preset.Candle1</code></td>
  </tr>
  <tr>    
    <td>Actual Sequence</td>
    <td><code>mmmmmaaaaammmmmaaaaaabcdefgabcdefg</code></td>
  </tr>
  </table>
  
**Candle (Second Variety)**
  <table>
  <tr>
    <td>Preview</td>
    <td>
      <details>
        <summary>Click to show</summary>
        <img src = "https://github.com/huchi57/LightFlicker/blob/main/Readme/Readme-Candle2.gif" width = 400>
      </details>
    </td>
  </tr>
  <tr>    
    <td>Preset Enum</td>
    <td><code>LightFlickerUtility.Preset.Candle2</code></td>
  </tr>
  <tr>    
    <td>Actual Sequence</td>
    <td><code>mmmaaaabcdefgmmmmaaaammmaamm</code></td>
  </tr>
  </table>
  
**Candle (Third Variety)**
  <table>
  <tr>
    <td>Preview</td>
    <td>
      <details>
        <summary>Click to show</summary>
        <img src = "https://github.com/huchi57/LightFlicker/blob/main/Readme/Readme-Candle3.gif" width = 400>
      </details>
    </td>
  </tr>
  <tr>    
    <td>Preset Enum</td>
    <td><code>LightFlickerUtility.Preset.Candle3</code></td>
  </tr>
  <tr>    
    <td>Actual Sequence</td>
    <td><code>mmmaaammmaaammmabcdefaaaammmmabcdefmmmaaaa</code></td>
  </tr>
  </table>
  
**Flicker (First Variety)**
  <table>
  <tr>
    <td>Preview</td>
    <td>
      <details>
        <summary>Click to show</summary>
        <img src = "https://github.com/huchi57/LightFlicker/blob/main/Readme/Readme-Flicker1.gif" width = 400>
      </details>
    </td>
  </tr>
  <tr>    
    <td>Preset Enum</td>
    <td><code>LightFlickerUtility.Preset.Flicker1</code></td>
  </tr>
  <tr>    
    <td>Actual Sequence</td>
    <td><code>mmnmmommommnonmmonqnmmo</code></td>
  </tr>
  </table>
  
**Flicker (Second Variety)**
  <table>
  <tr>
    <td>Preview</td>
    <td>
      <details>
        <summary>Click to show</summary>
        <img src = "https://github.com/huchi57/LightFlicker/blob/main/Readme/Readme-Flicker2.gif" width = 400>
      </details>
    </td>
  </tr>
  <tr>    
    <td>Preset Enum</td>
    <td><code>LightFlickerUtility.Preset.Flicker2</code></td>
  </tr>
  <tr>    
    <td>Actual Sequence</td>
    <td><code>nmonqnmomnmomomnon</code></td>
  </tr>
  </table>

## How Does it Work
An internal timer evaluates the light intensity based on a target character from the flicker pattern.

## References
https://github.com/ValveSoftware/halflife/blob/c7240b965743a53a29491dd49320c88eecf6257b/dlls/world.cpp#L557-L605

