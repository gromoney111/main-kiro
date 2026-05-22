# Folder Structure

```
RushIndiaStreetRunner/
├── .gitignore
├── .vscode/
│   ├── settings.json          # VS Code workspace settings
│   ├── launch.json            # Debug configuration
│   └── extensions.json        # Recommended extensions
│
├── Packages/
│   └── manifest.json          # Unity package dependencies
│
├── ProjectSettings/
│   └── ProjectSettings.asset  # Unity project configuration
│
├── Assets/
│   ├── Scenes/                # Unity scene files
│   │   ├── LoadingScene.unity
│   │   ├── MainMenu.unity
│   │   ├── CitySelection.unity
│   │   ├── Gameplay.unity
│   │   ├── Shop.unity
│   │   ├── Rewards.unity
│   │   ├── Settings.unity
│   │   └── GameOver.unity
│   │
│   ├── Scripts/
│   │   ├── Core/              # Essential game systems
│   │   │   ├── GameManager.cs
│   │   │   ├── PlayerController.cs
│   │   │   ├── SwipeManager.cs
│   │   │   ├── CoinManager.cs
│   │   │   ├── AdManager.cs
│   │   │   ├── SaveManager.cs
│   │   │   ├── AudioManager.cs
│   │   │   ├── UIManager.cs
│   │   │   ├── EnvironmentManager.cs
│   │   │   └── CitySelectionManager.cs
│   │   │
│   │   ├── Gameplay/          # Gameplay mechanics
│   │   │   ├── ObstacleSpawner.cs
│   │   │   ├── PowerupManager.cs
│   │   │   ├── MissionManager.cs
│   │   │   ├── DailyRewardManager.cs
│   │   │   ├── LeaderboardManager.cs
│   │   │   ├── IAPManager.cs
│   │   │   └── CharacterShop.cs
│   │   │
│   │   ├── UI/               # UI controllers per screen
│   │   │   ├── MainMenuUI.cs
│   │   │   ├── GameOverUI.cs
│   │   │   ├── SettingsUI.cs
│   │   │   └── LoadingUI.cs
│   │   │
│   │   ├── Data/             # ScriptableObject definitions
│   │   │   ├── CityData.cs
│   │   │   ├── CharacterData.cs
│   │   │   ├── PowerupData.cs
│   │   │   └── CityConfigLoader.cs
│   │   │
│   │   └── Utility/          # Helpers & tools
│   │       └── ObjectPool.cs
│   │
│   ├── ScriptableObjects/     # SO asset instances
│   │   ├── Cities/            # One CityData SO per city (15 total)
│   │   ├── Characters/        # One CharacterData SO per character
│   │   └── Powerups/          # One PowerupData SO per powerup
│   │
│   ├── Prefabs/
│   │   ├── Player/            # Player character prefabs
│   │   ├── Obstacles/         # Obstacle prefabs (cars, barriers, etc.)
│   │   ├── Collectibles/      # Coins, gems
│   │   ├── Powerups/          # Powerup pickup prefabs
│   │   ├── Environment/       # Road segments, decorations
│   │   └── UI/                # UI panel prefabs
│   │
│   ├── Art/
│   │   ├── Models/            # 3D models (.fbx)
│   │   ├── Materials/         # Materials for models
│   │   ├── Textures/          # Texture maps
│   │   ├── Shaders/           # Custom shaders (URP)
│   │   └── Animations/        # Animation clips & controllers
│   │
│   ├── Audio/
│   │   ├── Music/             # Background music per city
│   │   └── SFX/               # Sound effects
│   │
│   ├── UI/
│   │   ├── Sprites/           # UI sprites, icons, buttons
│   │   └── Fonts/             # TextMeshPro fonts
│   │
│   └── Resources/
│       └── CityConfigs/       # JSON city data (runtime loadable)
│           └── AllCities.json
│
└── Docs/
    ├── FOLDER_STRUCTURE.md
    ├── PREFAB_SETUP_GUIDE.md
    ├── UNITY_HIERARCHY.md
    ├── INSPECTOR_SETTINGS.md
    ├── UI_WIREFRAME.md
    ├── ANDROID_BUILD_SETTINGS.md
    ├── PLAY_STORE_CHECKLIST.md
    └── ART_DIRECTION.md
```

## Naming Conventions

| Type | Convention | Example |
|------|-----------|---------|
| Scripts | PascalCase | `PlayerController.cs` |
| Prefabs | PascalCase | `Player_Chaiwala.prefab` |
| Scenes | PascalCase | `MainMenu.unity` |
| ScriptableObjects | PascalCase | `City_Jaipur.asset` |
| Materials | lowercase_snake | `road_jaipur_pink.mat` |
| Textures | lowercase_snake | `tex_road_diffuse.png` |
| Audio | lowercase_snake | `sfx_coin_collect.wav` |
| Animations | PascalCase | `Player_Run.anim` |
