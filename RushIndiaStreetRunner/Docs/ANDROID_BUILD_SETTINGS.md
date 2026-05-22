# Android Build Settings

## Player Settings (Edit > Project Settings > Player)

### Company & Product
| Setting | Value |
|---------|-------|
| Company Name | RushIndiaGames |
| Product Name | Rush India Street Runner |
| Version | 1.0.0 |
| Bundle Version Code | 1 (increment each release) |

### Identification
| Setting | Value |
|---------|-------|
| Package Name | com.rushindiastreetrunner.game |
| Min API Level | 24 (Android 7.0 Nougat) |
| Target API Level | 34 (Android 14) |

### Configuration
| Setting | Value | Reason |
|---------|-------|--------|
| Scripting Backend | IL2CPP | Required for ARM64, better performance |
| API Compatibility | .NET Standard 2.1 | Modern C# features |
| Target Architectures | ARM64 only | Google Play requirement 2024+ |
| Internet Access | Require | For ads & IAP |
| Write Permission | External (SDCard) | For saves (optional) |

### Optimization
| Setting | Value | Reason |
|---------|-------|--------|
| Strip Engine Code | Yes | Reduces APK size |
| Managed Stripping Level | Medium | Balance: size vs reflection |
| C++ Compiler | Release (Master for Store) | Max performance |
| Incremental GC | Enabled | Smoother frames |

### Graphics
| Setting | Value |
|---------|-------|
| Color Space | Linear |
| Auto Graphics API | No (manual order below) |
| Graphics APIs | 1. Vulkan, 2. OpenGLES3 |
| Multithreaded Rendering | Yes |
| Static Batching | Yes |
| Dynamic Batching | Yes |
| GPU Skinning | Yes |

### Resolution
| Setting | Value |
|---------|-------|
| Default Orientation | Portrait |
| Use 32-bit Display Buffer | No (saves memory) |
| Resolution Scaling Mode | Fixed DPI |
| Target DPI | 300 (balance quality/perf) |

---

## Build Settings

### Build Type
- **Development Build**: ON during testing (enables Profiler)
- **Build Type for Release**: Release
- **App Bundle (AAB)**: Required for Play Store

### Keystore (NEVER commit to repo!)
```
# Create a keystore:
keytool -genkey -v -keystore rush-india.keystore \
  -alias rushindia -keyalg RSA -keysize 2048 -validity 10000

# Store securely! Losing this = can't update app on Play Store!
```

| Setting | Value |
|---------|-------|
| Keystore | (path to .keystore file) |
| Alias | rushindia |
| Passwords | (use environment variables!) |

---

## APK Size Optimization Checklist

- [ ] Enable "Strip Engine Code"
- [ ] Set texture compression to ASTC (best for modern Android)
- [ ] Compress audio: Vorbis for music, ADPCM for SFX
- [ ] Use Addressables for on-demand asset loading
- [ ] Remove unused packages from manifest.json
- [ ] Sprite Atlas for UI sprites
- [ ] Mesh compression: Medium for environment, High for characters
- [ ] Disable "Development Build" for release
- [ ] Set managed stripping level to "High" (test thoroughly!)
- [ ] Use AAB format (Google Play generates optimized APKs)

Target APK size: **Under 100MB** (ideal: 50-80MB)

---

## Gradle Configuration

### Custom Gradle Templates (if needed)
```
// Assets/Plugins/Android/mainTemplate.gradle
// Only create if you need custom dependencies

dependencies {
    // AdMob
    implementation 'com.google.android.gms:play-services-ads:23.0.0'
    
    // Play Core (IAP)
    implementation 'com.google.android.play:core:1.10.3'
}
```

### Proguard Rules
```
# Assets/Plugins/Android/proguard-user.txt
-keep class com.google.android.gms.** { *; }
-keep class com.unity3d.** { *; }
```

---

## Testing Checklist

- [ ] Test on low-end device (2GB RAM, SD665)
- [ ] Test on high-end device (8GB RAM, SD8 Gen 2)
- [ ] Test multiple aspect ratios (16:9, 19.5:9, 20:9)
- [ ] Test with ads enabled/disabled
- [ ] Test IAP flow (sandbox mode)
- [ ] Profile with Unity Profiler (no GC spikes in gameplay)
- [ ] Check battery usage (1hr session < 15% drain)
- [ ] Test interruptions (phone call, notification)
- [ ] Test app backgrounding/foregrounding
- [ ] Verify 60fps target across devices
