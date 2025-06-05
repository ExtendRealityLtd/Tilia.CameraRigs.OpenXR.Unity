# Class PassthroughManager

Manages the state of camera passthrough on the device.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Properties]
  * [CameraManager]
  * [PassthroughManagers]
  * [ProcessCameraManager]
  * [TargetCamera]
* [Methods]
  * [ActivatePassthrough()]
  * [ApplyCameraSettings()]
  * [Awake()]
  * [CacheCameraSettings()]
  * [DeactivatePassthrough()]
  * [OnDisable()]
  * [RestoreCachedCameraSettings()]
  * [StopRestoreCacheRoutine()]
  * [ToggleARFoundationPassthrough(Boolean)]

## Details

##### Inheritance

* System.Object
* [BasePassthroughManager]
* PassthroughManager

##### Namespace

* [Tilia.CameraRigs.OpenXR]

##### Syntax

```
public class PassthroughManager : BasePassthroughManager
```

### Properties

#### CameraManager

The ARCameraManager that controls passthrough via AR Foundation.

##### Declaration

```
public ARCameraManager CameraManager { get; set; }
```

#### PassthroughManagers

A [PassthroughManager] collection to process the passthrough logic on.

##### Declaration

```
public BasePassthroughManager[] PassthroughManagers { get; set; }
```

#### ProcessCameraManager

Whether to apply the [CameraManager] passthrough process.

##### Declaration

```
public bool ProcessCameraManager { get; set; }
```

#### TargetCamera

The target camera to apply passthrough logic to.

##### Declaration

```
public Camera TargetCamera { get; set; }
```

### Methods

#### ActivatePassthrough()

Activates the passthrough mode if available.

##### Declaration

```
public override void ActivatePassthrough()
```

##### Overrides

[BasePassthroughManager.ActivatePassthrough()]

#### ApplyCameraSettings()

##### Declaration

```
protected virtual void ApplyCameraSettings()
```

#### Awake()

##### Declaration

```
protected virtual void Awake()
```

#### CacheCameraSettings()

Caches the existing [TargetCamera] settings.

##### Declaration

```
public virtual void CacheCameraSettings()
```

#### DeactivatePassthrough()

Deactivates the passthrough mode if available.

##### Declaration

```
public override void DeactivatePassthrough()
```

##### Overrides

[BasePassthroughManager.DeactivatePassthrough()]

#### OnDisable()

##### Declaration

```
protected virtual void OnDisable()
```

#### RestoreCachedCameraSettings()

##### Declaration

```
protected virtual IEnumerator RestoreCachedCameraSettings()
```

##### Returns

| Type | Description |
| --- | --- |
| System.Collections.IEnumerator | n/a |

#### StopRestoreCacheRoutine()

##### Declaration

```
protected virtual void StopRestoreCacheRoutine()
```

#### ToggleARFoundationPassthrough(Boolean)

##### Declaration

```
protected virtual void ToggleARFoundationPassthrough(bool state)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Boolean | state | n/a |

[Tilia.CameraRigs.OpenXR]: README.md
[PassthroughManager]: PassthroughManager.md
[BasePassthroughManager]: BasePassthroughManager.md
[CameraManager]: PassthroughManager.md#CameraManager
[BasePassthroughManager.ActivatePassthrough()]: BasePassthroughManager.md#Tilia_CameraRigs_OpenXR_BasePassthroughManager_ActivatePassthrough
[TargetCamera]: PassthroughManager.md#TargetCamera
[BasePassthroughManager.DeactivatePassthrough()]: BasePassthroughManager.md#Tilia_CameraRigs_OpenXR_BasePassthroughManager_DeactivatePassthrough
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Properties]: #Properties
[CameraManager]: #CameraManager
[PassthroughManagers]: #PassthroughManagers
[ProcessCameraManager]: #ProcessCameraManager
[TargetCamera]: #TargetCamera
[Methods]: #Methods
[ActivatePassthrough()]: #ActivatePassthrough
[ApplyCameraSettings()]: #ApplyCameraSettings
[Awake()]: #Awake
[CacheCameraSettings()]: #CacheCameraSettings
[DeactivatePassthrough()]: #DeactivatePassthrough
[OnDisable()]: #OnDisable
[RestoreCachedCameraSettings()]: #RestoreCachedCameraSettings
[StopRestoreCacheRoutine()]: #StopRestoreCacheRoutine
[ToggleARFoundationPassthrough(Boolean)]: #ToggleARFoundationPassthroughBoolean
