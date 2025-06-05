namespace Tilia.CameraRigs.OpenXR.PicoOpenXRPlugin
{
    using Unity.XR.OpenXR.Features.PICOSupport;
    using UnityEngine.XR.OpenXR;

    public class PicoPassthroughProcessor : PassthroughProcessor
    {
        protected override void ActivatePassthroughLogic()
        {
            SetSourceManagerState(false);
            PassthroughFeature.EnableSeeThroughManual(true);
        }

        protected override void DeactivatePassthroughLogic()
        {
            SetSourceManagerState(false);
            PassthroughFeature.EnableSeeThroughManual(false);
        }

        protected override bool IsValid()
        {
            return OpenXRRuntime.name.ToLower().Contains("pico");
        }
    }
}