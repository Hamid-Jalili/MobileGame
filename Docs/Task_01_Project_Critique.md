# Task 01 – Holistic Project Critique

# Unity Version
- Unity 6.0.0 (6000.0.50f1)

# Platform Clarification
- The delivered project was originally saved with the "Mac" build target active.
- Since Mac Build Support is not installed on my system, Unity prompted to switch platforms on launch.
- I installed "Android Build Support" and switched the platform to "Android", which aligns with the intended mobile target of the test project.
- All subsequent Player Settings and build configurations are based on the Android platform.

# Project Setup Observations
- Folder structure is generally flat but functional.
- Modules are grouped under `/Assets/0_Project/Modules`, which is serviceable but lacks strong scalability for larger teams.
- No `Editor/`, `Plugins/`, `Localization/`, or `ScriptableObjects/` folders.
- Lacks standardized subfolder conventions for features, core systems, or third-party integrations.

# Player Settings Review (Android)
- "Color Space": Linear ✅
- "Scripting Backend": Mono (⚠️ IL2CPP is preferred for mobile release builds)
- "API Compatibility Level": .NET Standard 2.1 ✅
- "Graphics Jobs": Enabled ✅
- "GPU Skinning": CPU (⚠️ Consider switching to GPU if using high-poly characters)
- "Lightmap Encoding": Low Quality (⚠️ may be insufficient for HDR support)
- "Texture Compression": Not explicitly targeted — ETC/ASTC/Custom support should be configured
- "Virtual Texturing": Disabled ✅
- "HDR Output / Vulkan Extensions / Debug Flags": Disabled ✅

# Opportunities for Improvement
- Enable and test "IL2CPP" with Release configuration
- Introduce structured folder conventions (`/Core/`, `/Features/`, `/Shared/`)
- Add "EditorSettings.asset" to ensure consistent behavior across team members
- Configure "Texture Compression Targets" for Android (ETC + ASTC fallback)
- Define "build profiles per platform" (Android, iOS) using Unity's Build Profiles system
- Add Addressables, platform-dependent assets, and `Scripting Define Symbols`

# Screenshot Reference
See: `/Screenshots/PlayerSettings_01_Android.png`
