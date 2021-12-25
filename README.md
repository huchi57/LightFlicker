# LightFlicker

## Installation

## Usage

## Public Properties

| Property Name      | Type    | Description                                            |
| :---               | :---    | :---                                                   |
| `NormalBrightness` | `float` | The Light component's intensity at 100% brightness. *This will override Light's intensensity value.* |
| `PatternDuration`  | `float` | The duration for the pattern to iterate once.          |
| `Lerp`             | `bool`  | Whether the light intensity should change smoothly.    |
| `Pattern`          | `string`| The pattern of the Light component's intensity using alphabets between `a` to `z`, with `a` being 0%, `m` being 100%, and `z` being 200% intensity of the `NormalBrightness`. |
| `PresetPattern`    | `LightFlickerUtility.Preset` <br/>(Custom type) | Set the `pattern` from a selected collection of presets referenced from Valve's games. |

## How Does it Work
