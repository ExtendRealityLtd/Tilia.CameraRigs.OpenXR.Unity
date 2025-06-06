namespace Tilia.CameraRigs.OpenXR
{
    /// <summary>
    /// A base class to provide custom processors for vendor OpenXR extensions.
    /// </summary>
    public abstract class PassthroughProcessor : BasePassthroughManager
    {
        /// <inheritdoc/>
        public override void ActivatePassthrough()
        {
            if (!IsValid()) return;
            ActivatePassthroughLogic();
        }

        /// <inheritdoc/>
        public override void DeactivatePassthrough()
        {
            if (!IsValid()) return;
            DeactivatePassthroughLogic();
        }

        protected abstract bool IsValid();
        protected abstract void ActivatePassthroughLogic();
        protected abstract void DeactivatePassthroughLogic();

        protected virtual void SetSourceManagerState(bool state)
        {
            if (SourceManager == null) return;
            SourceManager.ProcessCameraManager = state;
        }
    }
}