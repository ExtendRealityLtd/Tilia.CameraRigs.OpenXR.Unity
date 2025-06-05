namespace Tilia.CameraRigs.OpenXR.MetaOpenXRPlugin.Config
{
    using Tilia.CameraRigs.OpenXR.Config;
    using UnityEditor;

    public class MetaProfileManager : OpenXRProfileManager<OpenXRProfileConfig>
    {
        private static readonly string _vendorName = "Meta";
        private static string _assetPath = "Assets/OpenXRProfiles/MetaProfile.asset";

        [MenuItem(menuRoot + menuConfigurePrefix + "Meta" + menuConfigureSuffix)]
        public static void ShowWindow()
        {
            OpenWindow<MetaProfileManager>();
        }

        [MenuItem(menuRoot + menuSwitchPrefix + "Meta" + menuSwitchSuffix)]
        public static void SwitchToMetaProfile()
        {
            SwitchProfile<OpenXRProfileConfig>(_assetPath);
        }

        protected override string GetVendorName() => _vendorName;
        protected override string GetAssetPath() => _assetPath;
    }
}