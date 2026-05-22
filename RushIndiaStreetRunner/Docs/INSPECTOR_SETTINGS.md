# Inspector Settings Guide

Recommended Inspector values for each script component.

---

## GameManager.cs

| Field | Value | Notes |
|-------|-------|-------|
| Base Speed | 8 | Starting run speed |
| Max Speed | 25 | Cap for difficulty |
| Speed Increase Rate | 0.05 | Per second |
| Score Multiplier | 1 | Default (2x with powerup) |
| Distance Score Rate | 10 | Points per second |
| Interstitial Ad Interval | 3 | Show ad every N games |

---

## PlayerController.cs

| Field | Value | Notes |
|-------|-------|-------|
| Lane Width | 3 | Matches road segment |
| Lane Switch Speed | 12 | Smooth but responsive |
| Jump Force | 10 | Adjust for feel |
| Gravity | -30 | Snappy mobile feel |
| Slide Duration | 0.8 | Seconds |
| Slide Collider Height | 0.5 | Low enough to pass barriers |
| Normal Collider Height | 2 | Standing height |

---

## SwipeManager.cs

| Field | Value | Notes |
|-------|-------|-------|
| Min Swipe Distance | 50 | Pixels (DPI-aware) |
| Max Swipe Time | 0.5 | Seconds |

---

## ObstacleSpawner.cs

| Field | Value | Notes |
|-------|-------|-------|
| Base Spawn Interval | 2.0 | Seconds between spawns |
| Min Spawn Interval | 0.5 | Maximum difficulty |
| Spawn Distance | 60 | Units ahead of player |
| Lane Width | 3 | Must match PlayerController |
| Coin Spawn Chance | 0.6 | 60% chance per row |
| Gem Spawn Chance | 0.05 | 5% - gems are rare |

---

## EnvironmentManager.cs

| Field | Value | Notes |
|-------|-------|-------|
| Pool Size | 8 | Road segments in pool |
| Segment Length | 30 | Must match prefab length |
| Road Segment Prefab | (assign) | Default road prefab |

---

## PowerupManager.cs

| Field | Value | Notes |
|-------|-------|-------|
| Magnet Duration | 8 | Seconds |
| Shield Duration | 10 | Seconds |
| Jetpack Duration | 5 | Seconds |
| Double Coins Duration | 10 | Seconds |
| Speed Boost Duration | 5 | Seconds |
| Powerup Spawn Chance | 0.1 | 10% per spawn cycle |

---

## AudioManager.cs

| Field | Value | Notes |
|-------|-------|-------|
| Music Volume | 0.5 | 50% default |
| SFX Volume | 0.8 | 80% default |
| Music Source | (auto-created) | Loop = true |
| SFX Source | (auto-created) | Loop = false |

Assign AudioClips in Inspector:
- Menu Music → `music_menu_main.ogg`
- Gameplay Music → `music_gameplay_01.ogg`
- Coin SFX → `sfx_coin_collect.wav`
- Jump SFX → `sfx_jump.wav`
- Death SFX → `sfx_death.wav`
- Powerup SFX → `sfx_powerup_activate.wav`

---

## ObjectPool.cs

Example Pool Configurations:

| Tag | Prefab | Initial Size | Expandable |
|-----|--------|-------------|-----------|
| Obstacle | Obs_Car_Red | 15 | true |
| Coin | Collectible_Coin | 30 | true |
| Gem | Collectible_Gem | 10 | true |
| Powerup | Powerup_Magnet | 5 | true |

---

## DailyRewardManager.cs

Default reward schedule (editable in Inspector):

| Day | Coins | Gems | Special |
|-----|-------|------|---------|
| 1 | 100 | 0 | - |
| 2 | 150 | 1 | - |
| 3 | 200 | 2 | - |
| 4 | 300 | 3 | - |
| 5 | 400 | 5 | - |
| 6 | 500 | 5 | - |
| 7 | 1000 | 10 | Festival Skin |

---

## Camera Setup (Cinemachine)

| Setting | Value |
|---------|-------|
| Follow | Player transform |
| Body | Transposer |
| Follow Offset | (0, 5, -10) |
| Damping | (0.5, 0.5, 0.5) |
| Aim | Composer |
| Look At | Player + forward offset |
| FOV | 60 |

---

## Quality Settings (Mobile)

### Mobile_Low
- Pixel Light Count: 1
- Texture Quality: Half Res
- Shadows: Hard Only
- Shadow Distance: 20
- Anti-Aliasing: Disabled

### Mobile_Medium (Default)
- Pixel Light Count: 2
- Texture Quality: Full Res
- Shadows: Hard + Soft
- Shadow Distance: 40
- Anti-Aliasing: 2x

### Mobile_High
- Pixel Light Count: 3
- Texture Quality: Full Res
- Shadows: All
- Shadow Distance: 60
- Anti-Aliasing: 4x
