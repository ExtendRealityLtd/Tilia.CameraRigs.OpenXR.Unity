namespace Tilia.CameraRigs.OpenXR.Config
{
    using System.Collections.Generic;
    using UnityEngine;

    public class OpenXRProfileConfig : ScriptableObject
    {
        public string vendorGroup;
        public List<string> interactionProfiles = new List<string>();
        public List<string> enabledFeatures = new List<string>();
    }
}