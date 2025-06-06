# Changelog

### [1.2.1](https://github.com/ExtendRealityLtd/Tilia.CameraRigs.OpenXR.Unity/compare/v1.2.0...v1.2.1) (2025-06-05)

#### Bug Fixes

* **PassthroughProcessor:** ensure source manager logic is called ([268409e](https://github.com/ExtendRealityLtd/Tilia.CameraRigs.OpenXR.Unity/commit/268409ebd13ebfb410ac83a6ed2d4d728617e55f))
  > The SourceManager in the passthrough manager is supposed to allow an extended passthrough processor to halt the AR Foundation processing done by the Passthrough Manager. However, this logic was not being set so it was never being limited.
  > 
  > This has now been fixed so the passthrough processors do actually now control the state of the SourceManager.

## [1.2.0](https://github.com/ExtendRealityLtd/Tilia.CameraRigs.OpenXR.Unity/compare/v1.1.0...v1.2.0) (2025-06-05)

#### Features

* **Prefabs:** promote passthrough manager to top level gameobject ([22f38ca](https://github.com/ExtendRealityLtd/Tilia.CameraRigs.OpenXR.Unity/commit/22f38cafb3bb86d895d0cbfec68836fae56e1ca0))
  > The PassthroughManager component has been relocated to the top level GameObject on the prefab rather than being nested within the HeadCamera so it's more visible and easier to access.

## [1.1.0](https://github.com/ExtendRealityLtd/Tilia.CameraRigs.OpenXR.Unity/compare/v1.0.2...v1.1.0) (2025-06-05)

#### Features

* **package.json:** add Samples~ reference to files array ([a7298e0](https://github.com/ExtendRealityLtd/Tilia.CameraRigs.OpenXR.Unity/commit/a7298e0bda9975a266b35171861451d3d5a99729))
  > This is why the samples aren't working, they need to be referenced in the files array.

### [1.0.2](https://github.com/ExtendRealityLtd/Tilia.CameraRigs.OpenXR.Unity/compare/v1.0.1...v1.0.2) (2025-06-05)

#### Bug Fixes

* **Samples~:** remove spaces from samples path names ([da1caf7](https://github.com/ExtendRealityLtd/Tilia.CameraRigs.OpenXR.Unity/commit/da1caf7e1ceaa344d8d6012ac9b03bcb97f81de2))
  > The samples are showing as having 0kb contents in the Unity Package Manager and this is most likely due to the contents not being found because there are spaces in the path names.

### [1.0.1](https://github.com/ExtendRealityLtd/Tilia.CameraRigs.OpenXR.Unity/compare/v1.0.0...v1.0.1) (2025-06-05)

#### Bug Fixes

* **package.json:** add missing samples section ([df86bd7](https://github.com/ExtendRealityLtd/Tilia.CameraRigs.OpenXR.Unity/commit/df86bd7cdfabfdad9d95e21881f23815a3ff94df))
  > The samples need defining in the package.json otherwise they do not show up in the Unity Package Manager.

## 1.0.0 (2025-06-05)

#### Features

* **structure:** initial implementation of OpenXR camera rig ([f915e96](https://github.com/ExtendRealityLtd/Tilia.CameraRigs.OpenXR.Unity/commit/f915e965058ec492cb3ec793a97c48bc56c50026))
  > The OpenXR camera rig provides a prefab that should work with any supported OpenXR vendor plugin. It needs unity to be configured for each vendor plugin and there are samples with the package to provide access to OpenXR extensions. At the moment the only extension supported is Passthrough on a basic level.
  > 
  > The package also contains an editor helper to allow quick switching between OpenXR profile settings in Unity as it would seem Unity does not offer this functionality, and even in Unity 6 with Build Profiles it does not seem supported.
