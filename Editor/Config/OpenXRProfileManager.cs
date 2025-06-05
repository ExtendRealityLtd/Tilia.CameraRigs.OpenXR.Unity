namespace Tilia.CameraRigs.OpenXR.Config
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using UnityEditor;
    using UnityEditorInternal;
    using UnityEngine;
    using UnityEngine.XR.OpenXR;
    using UnityEngine.XR.OpenXR.Features;

    public abstract class OpenXRProfileManager<ConfigType> : EditorWindow where ConfigType : OpenXRProfileConfig
    {
        protected const string menuRoot = "Window/Tilia/OpenXR Profiles/";
        protected const string menuConfigurePrefix = "Configure/Configure ";
        protected const string menuConfigureSuffix = " OpenXR Profile";
        protected const string menuSwitchPrefix = "Switch/Switch To ";
        protected const string menuSwitchSuffix = " OpenXR Profile";

        protected ConfigType config;
        protected Vector2 scroll;
        protected ReorderableList reorderableList;

        public static void OpenWindow<TWindow>() where TWindow : OpenXRProfileManager<ConfigType>
        {
            TWindow window = GetWindow<TWindow>();
            window.titleContent = new GUIContent(typeof(TWindow).Name.Replace("EditorWindow", ""));
            window.Show();
        }

        public static void SwitchProfile<ProfileType>(string assetPath) where ProfileType : OpenXRProfileConfig
        {
            ProfileType profile = AssetDatabase.LoadAssetAtPath<ProfileType>(assetPath);
            if (profile == null)
            {
                Debug.LogError($"Profile asset not found at: {assetPath}");
                return;
            }

            OpenXRSettings openXRSettings = OpenXRSettings.ActiveBuildTargetInstance;
            if (openXRSettings == null)
            {
                Debug.LogError("OpenXR Settings not found");
                return;
            }

            foreach (OpenXRFeature feature in openXRSettings.GetFeatures<OpenXRFeature>())
            {
                if (feature.enabled)
                {
                    feature.enabled = false;
                }
            }

            foreach (string interProfileName in profile.interactionProfiles)
            {
                foreach (OpenXRFeature feature in openXRSettings.GetFeatures<OpenXRFeature>())
                {
                    if (feature.GetType().Name == interProfileName)
                    {
                        feature.enabled = true;
                        break;
                    }
                }
            }

            foreach (string featureName in profile.enabledFeatures)
            {
                SetOpenXRFeature(featureName, true);
            }

            Debug.Log($"Switched to OpenXR Profile {assetPath}");
        }

        public static void SetOpenXRFeature(string featureName, bool enabled)
        {
            OpenXRSettings openXRSettings = OpenXRSettings.ActiveBuildTargetInstance;
            if (openXRSettings == null)
            {
                Debug.LogError("OpenXR settings not found");
                return;
            }

            OpenXRFeature[] allFeatures = openXRSettings.GetFeatures<OpenXRFeature>();
            OpenXRFeature feature = allFeatures.FirstOrDefault(f => f.GetType().Name == featureName);
            if (feature != null)
            {
                feature.enabled = enabled;

                if (Application.isPlaying)
                {
                    Debug.LogWarning("Runtime feature changes may not take effect until XR subsystem restart or app restart");
                }
            }
            else
            {
                Debug.LogError($"OpenXR feature '{featureName}' not found");
                Debug.Log("Available features:");
                foreach (OpenXRFeature f in allFeatures)
                {
                    Debug.Log($"  - {f.GetType().Name}");
                }
            }
        }

        protected virtual void OnEnable()
        {
            LoadOrCreateConfig();
            SetupReorderableList();
        }

        protected abstract string GetVendorName();
        protected abstract string GetAssetPath();

        protected virtual void LoadOrCreateConfig()
        {
            string path = GetAssetPath();
            CreatePathIfNotExists(System.IO.Path.GetDirectoryName(path));
            config = AssetDatabase.LoadAssetAtPath<ConfigType>(path);
            if (config == null)
            {
                config = CreateInstance<ConfigType>();
                config.vendorGroup = GetVendorName();
                AssetDatabase.CreateAsset(config, path);
                AssetDatabase.SaveAssets();
            }
        }

        protected virtual void CreatePathIfNotExists(string folderPath)
        {
            folderPath = folderPath.Replace("\\", "/").TrimEnd('/');
            if (folderPath == "Assets" || string.IsNullOrEmpty(folderPath)) return;
            if (AssetDatabase.IsValidFolder(folderPath)) return;

            string parentFolder = System.IO.Path.GetDirectoryName(folderPath).Replace("\\", "/");
            CreatePathIfNotExists(parentFolder);
            string newFolderName = System.IO.Path.GetFileName(folderPath);
            AssetDatabase.CreateFolder(parentFolder, newFolderName);
            AssetDatabase.Refresh();
        }

        protected virtual void SetupReorderableList()
        {
            if (config == null) return;

            reorderableList = new ReorderableList(config.interactionProfiles, typeof(string), true, true, true, true);

            reorderableList.drawHeaderCallback = rect =>
            {
                EditorGUI.LabelField(rect, $"Interaction Profiles ({config.vendorGroup})", EditorStyles.boldLabel);
            };

            reorderableList.drawElementCallback = (rect, index, isActive, isFocused) =>
            {
                if (index < config.interactionProfiles.Count)
                {
                    config.interactionProfiles[index] = EditorGUI.TextField(rect, config.interactionProfiles[index]);
                }
            };

            reorderableList.onAddDropdownCallback = (Rect buttonRect, ReorderableList list) =>
            {
                GenericMenu menu = new GenericMenu();
                string[] availableProfiles = GetAvailableInteractionProfileNames();

                string[] notYetAdded = availableProfiles
                    .Where(name => !config.interactionProfiles.Contains(name))
                    .ToArray();

                if (notYetAdded.Length > 0)
                {
                    foreach (string profileName in notYetAdded)
                    {
                        menu.AddItem(new GUIContent(profileName), false, () =>
                        {
                            config.interactionProfiles.Add(profileName);
                            SaveAssets();

                        });
                    }
                }
                else
                {
                    menu.AddDisabledItem(new GUIContent("All profiles added"));
                }
                menu.DropDown(buttonRect);
            };

            reorderableList.onRemoveCallback = list =>
            {
                if (list.index >= 0 && list.index < config.interactionProfiles.Count)
                {
                    config.interactionProfiles.RemoveAt(list.index);
                    SaveAssets();
                }
            };
        }

        protected virtual void SaveAssets()
        {
            EditorUtility.SetDirty(config);
            AssetDatabase.SaveAssets();
        }

        protected virtual void OnGUI()
        {
            if (config == null)
            {
                EditorGUILayout.HelpBox("Configuration not loaded.", MessageType.Error);
                return;
            }
            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Apply Profile"))
            {
                SaveAssets();
                SwitchProfile<ConfigType>(GetAssetPath());
            }
            EditorGUILayout.EndVertical();

            EditorGUILayout.Space();

            scroll = EditorGUILayout.BeginScrollView(scroll);

            if (reorderableList != null)
            {
                reorderableList.DoLayoutList();
            }

            EditorGUILayout.Space();
            EditorGUILayout.LabelField($"OpenXR Features ({config.vendorGroup})", EditorStyles.boldLabel);

            OpenXRSettings openXRSettings = OpenXRSettings.ActiveBuildTargetInstance;
            if (openXRSettings != null)
            {
                IEnumerable<OpenXRFeature> allFeatures = openXRSettings.GetFeatures<OpenXRFeature>();
                HashSet<System.Type> interactionFeatureTypes = new HashSet<System.Type>();
                foreach (OpenXRFeature feature in openXRSettings.GetFeatures<OpenXRInteractionFeature>())
                {
                    interactionFeatureTypes.Add(feature.GetType());
                }

                IEnumerable<OpenXRFeature> nonInteractionFeatures = allFeatures
                    .Where(feature => !interactionFeatureTypes.Contains(feature.GetType()))
                    .OrderBy(feature => GetFeatureDisplayName(feature));

                if (config.enabledFeatures == null) config.enabledFeatures = new List<string>();

                foreach (OpenXRFeature feature in nonInteractionFeatures)
                {
                    string featureName = feature.GetType().Name;
                    bool currentlyEnabled = config.enabledFeatures.Contains(featureName);

                    EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                    EditorGUILayout.BeginHorizontal();
                    bool newValue = GUILayout.Toggle(currentlyEnabled, GUIContent.none, GUILayout.Width(20));
                    GUILayout.Space(4);
                    GUIStyle labelStyle = new GUIStyle(EditorStyles.label);
                    labelStyle.wordWrap = true;
                    EditorGUILayout.LabelField(new GUIContent(GetFeatureDisplayName(feature), featureName), labelStyle, GUILayout.ExpandWidth(true));
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.EndVertical();

                    if (newValue != currentlyEnabled)
                    {
                        if (newValue)
                        {
                            if (!config.enabledFeatures.Contains(featureName)) config.enabledFeatures.Add(featureName);
                        }
                        else
                        {
                            config.enabledFeatures.Remove(featureName);
                        }
                        SaveAssets();
                    }
                }
            }
            else
            {
                EditorGUILayout.HelpBox("OpenXR Settings not available.", MessageType.Warning);
            }

            EditorGUILayout.EndScrollView();
        }

        protected virtual string GetFeatureDisplayName(OpenXRFeature feature)
        {
            const BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
            System.Type currentType = feature.GetType();

            while (currentType != null)
            {
                FieldInfo field = currentType.GetField("nameUi", flags);
                if (field != null && field.FieldType == typeof(string))
                {
                    string value = field.GetValue(feature) as string;
                    if (!string.IsNullOrEmpty(value))
                        return value;
                }

                currentType = currentType.BaseType;
            }

            return ObjectNames.NicifyVariableName(feature.GetType().Name);
        }

        protected virtual string[] GetAvailableInteractionProfileNames()
        {
            OpenXRSettings openXRSettings = OpenXRSettings.ActiveBuildTargetInstance;
            if (openXRSettings == null) return new string[0];

            List<string> profileNames = new List<string>();
            foreach (OpenXRFeature feature in openXRSettings.GetFeatures<OpenXRInteractionFeature>())
            {
                string profileName = feature.GetType().Name;
                if (!string.IsNullOrEmpty(profileName) && !profileNames.Contains(profileName))
                {
                    profileNames.Add(profileName);
                }
            }
            return profileNames.OrderBy(name => name).ToArray();
        }
    }
}