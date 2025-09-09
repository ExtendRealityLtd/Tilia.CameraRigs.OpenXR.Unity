namespace Tilia.CameraRigs.OpenXR.PicoOpenXRPlugin.Config
{
    using Tilia.CameraRigs.OpenXR.Config;
    using UnityEditor;

    public class PicoProfileManager : OpenXRProfileManager<OpenXRProfileConfig>
    {
        private static readonly string _vendorName = "Pico";
        private static string _assetPath = "Assets/OpenXRProfiles/PicoProfile.asset";

        [MenuItem(menuRoot + menuConfigurePrefix + "Pico" + menuConfigureSuffix)]
        public static void ShowWindow()
        {
            OpenWindow<PicoProfileManager>();
        }

        [MenuItem(menuRoot + menuSwitchPrefix + "Pico" + menuSwitchSuffix)]
        public static void SwitchToProfile()
        {
            SwitchProfile<OpenXRProfileConfig>(_assetPath);
        }

        protected override string GetVendorName() => _vendorName;
        protected override string GetAssetPath() => _assetPath;
    }
}