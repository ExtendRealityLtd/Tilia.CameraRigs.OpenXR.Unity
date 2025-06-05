# Class BasePassthroughManager

The base class for a Passthrough Manager

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Properties]
  * [SourceManager]
* [Methods]
  * [ActivatePassthrough()]
  * [DeactivatePassthrough()]

## Details

##### Inheritance

* System.Object
* BasePassthroughManager
* [PassthroughManager]
* [PassthroughProcessor]

##### Namespace

* [Tilia.CameraRigs.OpenXR]

##### Syntax

```
public abstract class BasePassthroughManager : MonoBehaviour
```

### Properties

#### SourceManager

The source [PassthroughManager] that is controlling this processor.

##### Declaration

```
public PassthroughManager SourceManager { get; set; }
```

### Methods

#### ActivatePassthrough()

Activates the passthrough mode if available.

##### Declaration

```
public abstract void ActivatePassthrough()
```

#### DeactivatePassthrough()

Deactivates the passthrough mode if available.

##### Declaration

```
public abstract void DeactivatePassthrough()
```

[PassthroughProcessor]: PassthroughProcessor.md
[Tilia.CameraRigs.OpenXR]: README.md
[PassthroughManager]: PassthroughManager.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Properties]: #Properties
[SourceManager]: #SourceManager
[Methods]: #Methods
[ActivatePassthrough()]: #ActivatePassthrough
[DeactivatePassthrough()]: #DeactivatePassthrough
