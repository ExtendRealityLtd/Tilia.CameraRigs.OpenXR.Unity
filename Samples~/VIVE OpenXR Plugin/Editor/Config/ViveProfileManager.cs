namespace Tilia.CameraRigs.OpenXR.ViveOpenXRPlugin.Config
{
    using Tilia.CameraRigs.OpenXR.Config;
    using UnityEditor;

    public class ViveProfileManager : OpenXRProfileManager<OpenXRProfileConfig>
    {
        private static readonly string _vendorName = "Vive";
        private static string _assetPath = "Assets/OpenXRProfiles/ViveProfile.asset";

        [MenuItem(menuRoot + menuConfigurePrefix + "Vive" + menuConfigureSuffix)]
        public static void ShowWindow()
        {
            OpenWindow<ViveProfileManager>();
        }

        [MenuItem(menuRoot + menuSwitchPrefix + "Vive" + menuSwitchSuffix)]
        public static void SwitchToMetaProfile()
        {
            SwitchProfile<OpenXRProfileConfig>(_assetPath);
        }

        protected override string GetVendorName() => _vendorName;
        protected override string GetAssetPath() => _assetPath;
    }
}