# Unity Scene Hierarchy Guide

## Scene 1: LoadingScene

```
LoadingScene
├── Main Camera
├── Canvas (Screen Space - Overlay)
│   ├── Background (Image, full screen, game art)
│   ├── Logo (Image, centered, game title)
│   ├── ProgressBar (Slider)
│   │   ├── Background
│   │   └── Fill Area
│   ├── LoadingText (TextMeshPro, "Loading...")
│   └── VersionText (TextMeshPro, bottom-right)
├── LoadingManager (GameObject)
│   └── LoadingUI.cs
└── EventSystem
```

---

## Scene 2: MainMenu

```
MainMenu
├── Main Camera
├── [Persistent] GameManager (DontDestroyOnLoad)
├── [Persistent] AudioManager
├── [Persistent] SaveManager
├── [Persistent] CoinManager
├── [Persistent] AdManager
├── Canvas (Screen Space - Overlay)
│   ├── Header
│   │   ├── CoinDisplay (Icon + Text)
│   │   ├── GemDisplay (Icon + Text)
│   │   └── HighScoreDisplay
│   ├── CenterContent
│   │   ├── GameTitle (TextMeshPro)
│   │   ├── CharacterPreview (RawImage or 3D render)
│   │   └── CharacterName (TextMeshPro)
│   ├── PlayButton (Button, large, centered)
│   ├── BottomNav
│   │   ├── ShopButton
│   │   ├── RewardsButton (+ notification badge)
│   │   ├── LeaderboardButton
│   │   └── SettingsButton
│   └── DailyRewardPopup (Panel, hidden by default)
├── MainMenuUI.cs (attached to Canvas or manager object)
├── 3D Background (optional decorative scene)
└── EventSystem
```

---

## Scene 3: CitySelection

```
CitySelection
├── Main Camera
├── Canvas (Screen Space - Overlay)
│   ├── Header
│   │   ├── TitleText ("Choose Your City")
│   │   └── BackButton
│   ├── CityGrid (ScrollView)
│   │   └── Content (GridLayoutGroup)
│   │       ├── CityCard_Jaipur (UI_CityCard prefab)
│   │       ├── CityCard_Mumbai
│   │       ├── CityCard_Delhi
│   │       ├── ... (15 total)
│   │       └── CityCard_Goa
│   ├── PreviewPanel
│   │   ├── CityPreviewImage (Image)
│   │   ├── CityNameText (TextMeshPro)
│   │   ├── CityDescText (TextMeshPro)
│   │   └── PlayButton (Button, "RUN!")
│   └── BottomInfo
│       └── DifficultyIndicator
├── CitySelectionManager.cs
└── EventSystem
```

---

## Scene 4: Gameplay

```
Gameplay
├── Main Camera (Cinemachine follow)
├── Directional Light (adjustable per city)
├── --- PLAYER ---
│   └── Player (Player prefab instance)
│       ├── CharacterController
│       ├── PlayerController.cs
│       └── Model + Animator
├── --- MANAGERS ---
│   ├── SwipeManager
│   ├── UIManager
│   ├── EnvironmentManager
│   │   └── RoadPool (parent for pooled segments)
│   ├── ObstacleSpawner
│   ├── PowerupManager
│   └── ObjectPool
│       ├── ObstaclePool
│       ├── CoinPool
│       └── GemPool
├── --- ENVIRONMENT ---
│   ├── RoadSegment_01 (pooled, active)
│   ├── RoadSegment_02
│   ├── ...
│   └── CityDecorations (landmarks, buildings)
├── --- UI ---
│   └── Canvas (Screen Space - Overlay)
│       ├── HUDPanel
│       │   ├── ScoreText (top center)
│       │   ├── CoinCounter (top left)
│       │   ├── PauseButton (top right)
│       │   └── PowerupIndicators (below score)
│       ├── PausePanel (hidden)
│       │   ├── ResumeButton
│       │   ├── QuitButton
│       │   └── SoundToggles
│       └── GameOverPanel (hidden)
│           └── GameOverUI.cs
└── EventSystem
```

---

## Scene 5: Shop

```
Shop
├── Main Camera
├── Canvas
│   ├── Header
│   │   ├── BackButton
│   │   ├── CoinDisplay
│   │   └── GemDisplay
│   ├── TabBar
│   │   ├── CharactersTab
│   │   ├── CoinsTab
│   │   └── SpecialTab
│   ├── CharacterList (ScrollView)
│   │   └── Content (GridLayoutGroup)
│   │       ├── CharacterCard_Chaiwala
│   │       ├── CharacterCard_Businessman
│   │       └── ...
│   ├── CharacterPreview (3D or Image)
│   ├── BuyButton / EquipButton
│   └── CoinPacksList
│       ├── Pack_500 (Button)
│       ├── Pack_2000
│       └── Pack_5000
├── CharacterShop.cs
└── EventSystem
```

---

## Scene 6: Rewards

```
Rewards
├── Main Camera
├── Canvas
│   ├── Header + BackButton
│   ├── DailyRewardGrid (7 day boxes)
│   │   ├── Day1Box (highlighted if claimable)
│   │   ├── Day2Box
│   │   └── ... Day7Box
│   ├── ClaimButton
│   ├── MissionsList
│   │   ├── Mission_01 (progress bar)
│   │   ├── Mission_02
│   │   └── Mission_03
│   └── TimerText (time until next reward)
├── DailyRewardManager.cs
├── MissionManager.cs
└── EventSystem
```

---

## Scene 7: Settings

```
Settings
├── Main Camera
├── Canvas
│   ├── Header + BackButton
│   ├── SettingsPanel
│   │   ├── SoundToggle (Toggle with label)
│   │   ├── MusicToggle
│   │   ├── Divider
│   │   ├── RestorePurchasesButton
│   │   ├── PrivacyPolicyButton
│   │   ├── RateUsButton
│   │   ├── Divider
│   │   └── ResetDataButton (red, dangerous)
│   └── VersionText (bottom)
├── SettingsUI.cs
└── EventSystem
```

---

## Persistent Objects (DontDestroyOnLoad)

These spawn in the FIRST scene and persist across all scene loads:
```
[DontDestroyOnLoad]
├── GameManager
├── AudioManager (+ AudioSources)
├── SaveManager
├── CoinManager
├── AdManager
├── DailyRewardManager
├── MissionManager
├── LeaderboardManager
└── IAPManager
```

**Tip:** Create a `_Persistent` prefab containing all these managers for easy scene setup.
