namespace Tilia.CameraRigs.OpenXR
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.XR.ARFoundation;

    /// <summary>
    /// The base class for a Passthrough Manager
    /// </summary>
    public abstract class BasePassthroughManager : MonoBehaviour
    {
        /// <summary>
        /// Activates the passthrough mode if available.
        /// </summary>
        public abstract void ActivatePassthrough();
        /// <summary>
        /// Deactivates the passthrough mode if available.
        /// </summary>
        public abstract void DeactivatePassthrough();
    }

    /// <summary>
    /// Manages the state of camera passthrough on the device.
    /// </summary>
    public class PassthroughManager : BasePassthroughManager
    {
        [Tooltip("The target camera to apply passthrough logic to.")]
        [SerializeField]
        private Camera targetCamera;
        /// <summary>
        /// The target camera to apply passthrough logic to.
        /// </summary>
        public Camera TargetCamera
        {
            get { return targetCamera; }
            set { targetCamera = value; }
        }

        [Tooltip("The ARCameraManager that controls passthrough via AR Foundation.")]
        [SerializeField]
        private ARCameraManager cameraManager;
        /// <summary>
        /// The <see cref="ARCameraManager"/> that controls passthrough via AR Foundation.
        /// </summary>
        public ARCameraManager CameraManager
        {
            get { return cameraManager; }
            set { cameraManager = value; }
        }

        [Tooltip("Whether to apply the CameraManager passthrough process.")]
        [SerializeField]
        private bool processCameraManager = true;
        /// <summary>
        /// Whether to apply the <see cref="CameraManager"/> passthrough process.
        /// </summary>
        public bool ProcessCameraManager
        {
            get { return processCameraManager; }
            set { processCameraManager = value; }
        }

        [Tooltip("A PassthroughManager collection to process the passthrough logic on.")]
        [SerializeField]
        private BasePassthroughManager[] passthroughManagers = new BasePassthroughManager[0];
        /// <summary>
        /// A <see cref="PassthroughManager"/> collection to process the passthrough logic on.
        /// </summary>
        public BasePassthroughManager[] PassthroughManagers
        {
            get { return passthroughManagers; }
            set { passthroughManagers = value; }
        }

        private CameraClearFlags cachedClearFlags;
        private Color cachedCameraBackground;
        private bool cachedProcessPassthroughState;
        Coroutine restoreCacheRoutine;

        /// <inheritdoc/>
        public override void ActivatePassthrough()
        {
            StopRestoreCacheRoutine();
            cachedProcessPassthroughState = ProcessCameraManager;
            ApplyCameraSettings();
            foreach (BasePassthroughManager processor in passthroughManagers)
            {
                processor.ActivatePassthrough();
            }
            ToggleARFoundationPassthrough(true);
            ProcessCameraManager = cachedProcessPassthroughState;
        }

        /// <inheritdoc/>
        public override void DeactivatePassthrough()
        {
            if (restoreCacheRoutine != null) return;
            cachedProcessPassthroughState = ProcessCameraManager;
            foreach (BasePassthroughManager processor in passthroughManagers)
            {
                processor.DeactivatePassthrough();
            }
            ToggleARFoundationPassthrough(false);
            restoreCacheRoutine = StartCoroutine(RestoreCachedCameraSettings());
            ProcessCameraManager = cachedProcessPassthroughState;
        }

        /// <summary>
        /// Caches the existing <see cref="TargetCamera"/> settings.
        /// </summary>
        public virtual void CacheCameraSettings()
        {
            cachedClearFlags = TargetCamera.clearFlags;
            cachedCameraBackground = TargetCamera.backgroundColor;
        }

        protected virtual void Awake()
        {
            CacheCameraSettings();
        }

        protected virtual void OnDisable()
        {
            StopRestoreCacheRoutine();
        }

        protected virtual void StopRestoreCacheRoutine()
        {
            if (restoreCacheRoutine == null) return;
            StopCoroutine(restoreCacheRoutine);
            restoreCacheRoutine = null;
        }

        protected virtual void ToggleARFoundationPassthrough(bool state)
        {
            if (!ProcessCameraManager) return;
            CameraManager.enabled = state;
        }

        protected virtual void ApplyCameraSettings()
        {
            TargetCamera.clearFlags = CameraClearFlags.SolidColor;
            TargetCamera.backgroundColor = new Color(0f, 0f, 0f, 0f);
        }

        protected virtual IEnumerator RestoreCachedCameraSettings()
        {
            yield return new WaitForEndOfFrame();
            TargetCamera.clearFlags = cachedClearFlags;
            TargetCamera.backgroundColor = cachedCameraBackground;
        }
    }
}