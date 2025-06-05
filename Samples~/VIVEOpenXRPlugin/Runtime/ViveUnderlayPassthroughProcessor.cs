namespace Tilia.CameraRigs.OpenXR.ViveOpenXRPlugin
{
    using UnityEngine.XR.OpenXR;
    public class ViveUnderlayPassthroughProcessor : PassthroughProcessor
    {
        private VIVE.OpenXR.Passthrough.XrPassthroughHTC id = 0;

        protected override void ActivatePassthroughLogic()
        {
            SetSourceManagerState(false);
            VIVE.OpenXR.Passthrough.PassthroughAPI.CreatePlanarPassthrough(out id, VIVE.OpenXR.CompositionLayer.LayerType.Underlay);
        }

        protected override void DeactivatePassthroughLogic()
        {
            SetSourceManagerState(false);
            VIVE.OpenXR.Passthrough.PassthroughAPI.DestroyPassthrough(id);
            id = 0;
        }

        protected override bool IsValid()
        {
            return OpenXRRuntime.name.ToLower().Contains("vive");
        }
    }
}