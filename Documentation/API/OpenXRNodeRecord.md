# Class OpenXRNodeRecord

Provides the description for an OpenXR CameraRig node element.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Properties]
  * [HasPassThroughCamera]
  * [NodeType]
  * [PassthroughManager]
  * [Priority]
  * [XRNodeType]
* [Methods]
  * [DisablePassThrough()]
  * [EnablePassThrough()]
  * [SetNodeType(Int32)]

## Details

##### Inheritance

* System.Object
* OpenXRNodeRecord

##### Namespace

* [Tilia.CameraRigs.OpenXR]

##### Syntax

```
public class OpenXRNodeRecord : BaseDeviceDetailsRecord
```

### Properties

#### HasPassThroughCamera

##### Declaration

```
public override bool HasPassThroughCamera { get; protected set; }
```

#### NodeType

The Node Type for the record.

##### Declaration

```
public XRNode NodeType { get; set; }
```

#### PassthroughManager

The [PassthroughManager] for handling the camera passthrough.

##### Declaration

```
public BasePassthroughManager PassthroughManager { get; set; }
```

#### Priority

##### Declaration

```
public override int Priority { get; protected set; }
```

#### XRNodeType

##### Declaration

```
public override XRNode XRNodeType { get; protected set; }
```

### Methods

#### DisablePassThrough()

##### Declaration

```
protected override void DisablePassThrough()
```

#### EnablePassThrough()

##### Declaration

```
protected override void EnablePassThrough()
```

#### SetNodeType(Int32)

Sets the [NodeType].

##### Declaration

```
public virtual void SetNodeType(int index)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Int32 | index | The index of the XRNode. |

[Tilia.CameraRigs.OpenXR]: README.md
[PassthroughManager]: OpenXRNodeRecord.md#PassthroughManager
[BasePassthroughManager]: BasePassthroughManager.md
[NodeType]: OpenXRNodeRecord.md#NodeType
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Properties]: #Properties
[HasPassThroughCamera]: #HasPassThroughCamera
[NodeType]: #NodeType
[PassthroughManager]: #PassthroughManager
[Priority]: #Priority
[XRNodeType]: #XRNodeType
[Methods]: #Methods
[DisablePassThrough()]: #DisablePassThrough
[EnablePassThrough()]: #EnablePassThrough
[SetNodeType(Int32)]: #SetNodeTypeInt32
