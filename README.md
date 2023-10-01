# EasingCore [![license](https://img.shields.io/badge/license-MIT-green.svg?style=flat)](https://github.com/rust-lucas/EasingCoreGodot/blob/master/LICENSE)
Core Easing Implementation for Godot.

## API
```csharp
public static EasingFunction Get(Ease type)
```

## Usage
```csharp
var easeOutCubic = Easing.Get(Ease.OutCubic);
var t = easeOutCubic(0.5f);
var lerpedValue = Godot.Mathf.Lerp(init,end,t);
```

## Original Author
[setchi](https://github.com/setchi)

## Godot Port
[Lucas Miller](https://github.com/rust-lucas/)

## License
[MIT](https://github.com/rust-lucas/EasingCoreGodot/blob/master/LICENSE)
[Original License (MIT)](https://github.com/setchi/EasingCore/blob/master/LICENSE)
