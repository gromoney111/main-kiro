# ⚡ QUICK START — Do These Steps In Order

**Time needed: ~4 hours from zero to testable game**

---

## Phase 1: Setup (30 minutes)
- [ ] Install Unity Hub → unity.com/download
- [ ] Install Unity 2022.3 LTS + Android module
- [ ] Clone repo: `git clone https://github.com/gromoney111/main-kiro.git`
- [ ] Open `main-kiro/RushIndiaStreetRunner/` in Unity Hub

## Phase 2: Create Scenes (60 minutes)
- [ ] Create LoadingScene + add `GameBootstrapper` script
- [ ] Create MainMenu + add `MainMenuUI` script + buttons
- [ ] Create CitySelection + add `CitySelectionManager` script
- [ ] Create Gameplay + add `GameplayInitializer` + Player with `PlayerController`
- [ ] Create Shop, Rewards, Settings, GameOver scenes
- [ ] File > Build Settings → add all scenes in order

## Phase 3: Create Game Objects (45 minutes)
- [ ] Player: Capsule + CharacterController + PlayerController
- [ ] Obstacle prefabs: Cubes with "Obstacle" tag (at least 3)
- [ ] Coin prefab: Cylinder + "Coin" tag + Trigger collider + CoinRotator
- [ ] Road segment prefab: Plane scaled to 9×30 units
- [ ] Wire prefabs to ObstacleSpawner and EnvironmentManager

## Phase 4: Test (30 minutes)
- [ ] Press Play in LoadingScene → game flows through all scenes
- [ ] Arrow keys control lanes/jump/slide
- [ ] Coins collected, score increases, obstacles kill player
- [ ] Game Over → Retry works

## Phase 5: Polish (60 minutes)
- [ ] Import free 3D models from Unity Asset Store
- [ ] Add background music file
- [ ] Add coin/jump sound effects
- [ ] Adjust colors and camera angle

## Phase 6: Publish (45 minutes)
- [ ] Set Player Settings (package name, IL2CPP, ARM64)
- [ ] Create keystore
- [ ] Build AAB file
- [ ] Upload to Google Play Console
- [ ] Fill store listing + screenshots
- [ ] Submit for review

---

**Total: ~4-5 hours** to go from "I have no idea what I'm doing" to a live game on Play Store!

The code is 100% done. You're just connecting the dots in the Unity Editor.
