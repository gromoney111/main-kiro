# Rush India: Street Runner 🇮🇳🏃

A 3D endless runner mobile game set across 15 iconic Indian cities. Built with Unity LTS + C#, optimized for Android.

## Quick Start

### Prerequisites
- **Unity 2022.3 LTS** (or newer LTS)
- **VS Code** with C# Dev Kit extension
- **Android SDK** (API 24+)
- **JDK 11** (bundled with Unity)

### Setup Instructions

1. **Clone the repository**
   ```bash
   git clone https://github.com/your-org/RushIndiaStreetRunner.git
   ```

2. **Open in Unity Hub**
   - Add project folder in Unity Hub
   - Open with Unity 2022.3 LTS
   - Wait for package imports to complete

3. **VS Code Setup**
   - Install recommended extensions (`.vscode/extensions.json`)
   - Unity will auto-generate `.csproj` and `.sln` files
   - Open folder in VS Code → C# Dev Kit auto-detects Unity project

4. **Scene Build Order** (File > Build Settings)
   ```
   0: Scenes/LoadingScene
   1: Scenes/MainMenu
   2: Scenes/CitySelection
   3: Scenes/Gameplay
   4: Scenes/Shop
   5: Scenes/Rewards
   6: Scenes/Settings
   7: Scenes/GameOver
   ```

5. **First Run**
   - Open `Scenes/LoadingScene`
   - Press Play
   - Loading → MainMenu → CitySelection → Gameplay

## Game Overview

| Feature | Details |
|---------|---------|
| Genre | 3D Endless Runner |
| Platform | Android (iOS ready) |
| Cities | 15 Indian cities |
| Characters | 4 base + festival skins |
| Monetization | AdMob + IAP |
| Target FPS | 60fps |

## Core Gameplay
- **Auto-run** forward continuously
- **Swipe Left/Right**: Change lanes (3 lanes)
- **Swipe Up**: Jump over obstacles
- **Swipe Down**: Slide under barriers
- **Collect**: Coins, Gems, Powerups
- **Avoid**: City-specific obstacles (cars, animals, barriers)

## Cities (15 Total)
Jaipur • Mumbai • Delhi • Bangalore • Hyderabad • Kolkata • Chennai • Pune • Ahmedabad • Lucknow • Chandigarh • Udaipur • Jodhpur • Surat • Goa

Each city features unique roads, obstacles, music, and atmosphere.

## Architecture

```
Namespace: RushIndia.*
├── RushIndia.Core       → GameManager, PlayerController, SwipeManager, etc.
├── RushIndia.Gameplay   → ObstacleSpawner, PowerupManager, Missions, etc.
├── RushIndia.Data       → ScriptableObjects (CityData, CharacterData)
├── RushIndia.UI         → All UI controllers
└── RushIndia.Utility    → ObjectPool, helpers
```

### Design Patterns Used
- **Singleton** - Managers (GameManager, AudioManager, etc.)
- **Object Pooling** - Obstacles, coins, effects
- **Observer/Events** - Decoupled communication via C# Actions
- **ScriptableObjects** - Data-driven city/character/powerup configs
- **State Machine** - GameState enum for clean flow control

## Monetization

### AdMob (Stub IDs - Replace Before Release!)
- **Banner**: Menu screens (bottom)
- **Interstitial**: Every 3 game overs
- **Rewarded**: Watch ad for bonus coins after death

### IAP Products
- Remove Ads (Non-consumable)
- Coin Packs: 500 / 2000 / 5000
- Gem Pack: 50 gems
- Premium Bundle: Coins + characters
- Festival Pack: Limited skins

## Build for Android

```
Player Settings:
├── Company: RushIndiaGames
├── Product: Rush India Street Runner
├── Bundle ID: com.rushindiastreetrunner.game
├── Min SDK: API 24 (Android 7.0)
├── Target SDK: API 34
├── Scripting Backend: IL2CPP
├── Architecture: ARM64
└── Graphics: OpenGLES3 + Vulkan
```

See `ANDROID_BUILD_SETTINGS.md` for full details.

## Viral/Social Hooks 📱

- **Share Score**: Native share after game over (Reels/Shorts friendly!)
- **City Challenge**: "Beat my score in Mumbai!" shareable format
- **Daily Streak**: Screenshot-worthy reward animations
- **Festival Events**: Time-limited skins drive FOMO sharing
- **Leaderboard Bragging**: Local leaderboard screenshots

## Contributing

1. Follow namespace conventions (`RushIndia.*`)
2. One script = one responsibility
3. Use object pooling for spawned objects
4. Avoid `Instantiate`/`Destroy` during gameplay
5. All new features need a ScriptableObject config

## License

Proprietary - All rights reserved.
