# Class PassthroughProcessor

A base class to provide custom processors for vendor OpenXR extensions.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Methods]
  * [ActivatePassthrough()]
  * [ActivatePassthroughLogic()]
  * [DeactivatePassthrough()]
  * [DeactivatePassthroughLogic()]
  * [IsValid()]
  * [SetSourceManagerState(Boolean)]

## Details

##### Inheritance

* System.Object
* [BasePassthroughManager]
* PassthroughProcessor

##### Inherited Members

[BasePassthroughManager.SourceManager]

##### Namespace

* [Tilia.CameraRigs.OpenXR]

##### Syntax

```
public abstract class PassthroughProcessor : BasePassthroughManager
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

#### ActivatePassthroughLogic()

##### Declaration

```
protected abstract void ActivatePassthroughLogic()
```

#### DeactivatePassthrough()

Deactivates the passthrough mode if available.

##### Declaration

```
public override void DeactivatePassthrough()
```

##### Overrides

[BasePassthroughManager.DeactivatePassthrough()]

#### DeactivatePassthroughLogic()

##### Declaration

```
protected abstract void DeactivatePassthroughLogic()
```

#### IsValid()

##### Declaration

```
protected abstract bool IsValid()
```

##### Returns

| Type | Description |
| --- | --- |
| System.Boolean | n/a |

#### SetSourceManagerState(Boolean)

##### Declaration

```
protected virtual void SetSourceManagerState(bool state)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Boolean | state | n/a |

[BasePassthroughManager]: BasePassthroughManager.md
[BasePassthroughManager.SourceManager]: BasePassthroughManager.md#Tilia_CameraRigs_OpenXR_BasePassthroughManager_SourceManager
[Tilia.CameraRigs.OpenXR]: README.md
[BasePassthroughManager.ActivatePassthrough()]: BasePassthroughManager.md#Tilia_CameraRigs_OpenXR_BasePassthroughManager_ActivatePassthrough
[BasePassthroughManager.DeactivatePassthrough()]: BasePassthroughManager.md#Tilia_CameraRigs_OpenXR_BasePassthroughManager_DeactivatePassthrough
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Methods]: #Methods
[ActivatePassthrough()]: #ActivatePassthrough
[ActivatePassthroughLogic()]: #ActivatePassthroughLogic
[DeactivatePassthrough()]: #DeactivatePassthrough
[DeactivatePassthroughLogic()]: #DeactivatePassthroughLogic
[IsValid()]: #IsValid
[SetSourceManagerState(Boolean)]: #SetSourceManagerStateBoolean
