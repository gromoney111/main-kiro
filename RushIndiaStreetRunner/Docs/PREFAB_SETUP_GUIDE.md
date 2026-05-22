# Prefab Setup Guide

## Player Prefab: `Player_Chaiwala`

```
Player_Chaiwala (GameObject)
├── Components:
│   ├── CharacterController
│   │   ├── Height: 2.0
│   │   ├── Radius: 0.3
│   │   ├── Center: (0, 1, 0)
│   │   └── Slope Limit: 45
│   ├── PlayerController.cs (RushIndia.Core)
│   │   ├── Lane Width: 3
│   │   ├── Lane Switch Speed: 12
│   │   ├── Jump Force: 10
│   │   ├── Gravity: -30
│   │   ├── Slide Duration: 0.8
│   │   ├── Slide Collider Height: 0.5
│   │   └── Normal Collider Height: 2
│   └── Animator
│       └── Controller: Player_AnimController
├── Model (child)
│   └── 3D character mesh + SkinnedMeshRenderer
└── VFX (child)
    ├── ShieldEffect (ParticleSystem, disabled)
    └── MagnetField (SphereCollider trigger, disabled)
```

### Player Animations Required
- `Player_Run` (looping, default state)
- `Player_Jump` (one-shot, trigger: "Jump")
- `Player_Slide` (one-shot, trigger: "Slide")
- `Player_LaneLeft` / `Player_LaneRight` (lean animations)
- `Player_Death` (one-shot, trigger: "Die")
- `Player_Idle` (menu preview)

---

## Obstacle Prefabs

### Naming: `Obs_{Type}_{Variant}`
Examples: `Obs_Car_Red`, `Obs_Bus_DTC`, `Obs_Barricade_01`

```
Obs_Car_Red (GameObject)
├── Components:
│   ├── BoxCollider (trigger = false, for physical collision)
│   │   └── Size: Match model bounds
│   ├── Tag: "Obstacle"
│   └── Layer: "Obstacle"
├── Model (child)
│   └── 3D mesh + MeshRenderer
└── (Optional) Wheels (animated child objects)
```

### Obstacle Types by Category
| Category | Prefab Names |
|----------|-------------|
| Vehicles | Obs_Car_*, Obs_Bus_*, Obs_Auto_*, Obs_Truck_* |
| Animals | Obs_Cow, Obs_Dog, Obs_Camel |
| Static | Obs_Barricade_*, Obs_Pothole, Obs_Construction |
| Sliding | Obs_Barrier_Low (player must slide under) |
| Jumping | Obs_Pothole, Obs_SpeedBreaker (player must jump) |

---

## Collectible Prefabs

### Coin: `Collectible_Coin`
```
Collectible_Coin (GameObject)
├── Components:
│   ├── SphereCollider (isTrigger = true)
│   │   └── Radius: 0.5
│   ├── Tag: "Coin"
│   └── Layer: "Collectible"
├── Model (child)
│   ├── Gold coin 3D mesh
│   └── Rotate animation (simple script or Animator)
└── VFX_Sparkle (ParticleSystem, subtle glow)
```

### Gem: `Collectible_Gem`
```
Collectible_Gem (GameObject)
├── Components:
│   ├── SphereCollider (isTrigger = true)
│   │   └── Radius: 0.5
│   ├── Tag: "Gem"
│   └── Layer: "Collectible"
├── Model (child)
│   └── Diamond/gem 3D mesh (low-poly crystal)
└── VFX_Sparkle (ParticleSystem, purple/blue glow)
```

---

## Powerup Prefabs

### Naming: `Powerup_{Type}`
Examples: `Powerup_Magnet`, `Powerup_Shield`

```
Powerup_Magnet (GameObject)
├── Components:
│   ├── SphereCollider (isTrigger = true)
│   │   └── Radius: 0.8
│   ├── Tag: "Powerup"
│   ├── Layer: "Collectible"
│   └── PowerupIdentifier.cs (stores powerup type string)
├── Model (child)
│   └── Magnet icon 3D mesh (floating, rotating)
└── VFX_Glow (ParticleSystem, type-specific color)
```

### PowerupIdentifier Script (Add to each powerup prefab)
```csharp
public class PowerupIdentifier : MonoBehaviour
{
    public string powerupType; // "Magnet", "Shield", "Jetpack", etc.
}
```

---

## Environment Prefabs

### Road Segment: `Env_RoadSegment_Default`
```
Env_RoadSegment_Default (GameObject)
├── Components:
│   ├── MeshRenderer (road material)
│   └── BoxCollider (ground for CharacterController)
│       └── Size: (9, 0.1, 30)  // 3 lanes × 3m = 9m wide, 30m long
├── Road (child mesh)
│   ├── 3 lane markings
│   └── Sidewalk edges
├── LeftDecor (child, spawn point for side decorations)
└── RightDecor (child, spawn point for side decorations)
```

Segment Length: **30 units** (must match EnvironmentManager.segmentLength)

### City-Specific Segments
Create variants: `Env_RoadSegment_Jaipur`, `Env_RoadSegment_Mumbai`, etc.
with city-themed textures and side props.

---

## UI Prefabs

### City Card: `UI_CityCard`
```
UI_CityCard (GameObject)
├── Components:
│   ├── Button
│   ├── Image (card background)
│   └── LayoutElement (preferred width: 200, height: 250)
├── Thumbnail (Image child)
│   └── City preview image
├── CityName (TextMeshProUGUI child)
│   └── Font: Bold, size 24
└── LockOverlay (Image child, shown if locked)
```

---

## Tags & Layers Setup

### Required Tags
- `Obstacle`
- `Coin`
- `Gem`
- `Powerup`
- `Player`
- `RoadSegment`

### Recommended Layers
- Default (0)
- Player (8)
- Obstacle (9)
- Collectible (10)
- Environment (11)
- UI (12)
