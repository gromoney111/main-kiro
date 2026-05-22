# 🇮🇳 Rush India: Street Runner — COMPLETE BEGINNER GUIDE

## From Zero to Play Store (No Coding Required!)

This guide assumes you have **NEVER** used Unity, have **NO programming experience**, and want to turn this project into a real game on Google Play Store. Follow every step exactly.

---

## TABLE OF CONTENTS

1. [What You Need (Computer Requirements)](#1-what-you-need)
2. [Install Everything](#2-install-everything)
3. [Open This Project in Unity](#3-open-project)
4. [Create Your Game Scenes (Step by Step)](#4-create-scenes)
5. [Create Your 3D Objects (Player, Coins, Obstacles)](#5-create-objects)
6. [Wire Everything Together](#6-wire-everything)
7. [Test Your Game](#7-test-game)
8. [Add Real 3D Art (Free Assets)](#8-add-art)
9. [Setup Ads (Make Money)](#9-setup-ads)
10. [Build the APK/AAB File](#10-build)
11. [Create Google Play Developer Account](#11-play-account)
12. [Upload to Play Store](#12-upload)
13. [Common Problems & Fixes](#13-troubleshooting)

---

## 1. WHAT YOU NEED {#1-what-you-need}

### Computer Requirements
| Item | Minimum | Recommended |
|------|---------|-------------|
| OS | Windows 10 / macOS 12 | Windows 11 / macOS 14 |
| RAM | 8 GB | 16 GB |
| Storage | 30 GB free | 50 GB free |
| Internet | Required for downloads | Fast broadband |

### Money Needed
| Item | Cost | Why |
|------|------|-----|
| Unity | FREE (Personal license) | Game engine |
| Google Play Developer Account | $25 ONE TIME | To publish on Play Store |
| AdMob Account | FREE | To earn money from ads |
| Android Phone (for testing) | You probably have one | Test before publishing |

**Total cost to publish: $25** (just the Google Play fee)

---

## 2. INSTALL EVERYTHING {#2-install-everything}

### Step 2.1: Install Unity Hub

1. Go to: https://unity.com/download
2. Click **"Download Unity Hub"**
3. Run the installer file
4. Open Unity Hub after installation
5. Create a free Unity account (use your email)
6. Choose **"Personal"** license (it's FREE for revenue under $100K)

### Step 2.2: Install Unity Editor

1. In Unity Hub, click **"Installs"** tab on the left
2. Click **"Install Editor"** button (top right)
3. Choose **"Unity 2022.3 LTS"** (the one that says "LTS" = Long Term Support)
4. On the next screen, CHECK these boxes:
   - ✅ **Android Build Support**
   - ✅ **Android SDK & NDK Tools**
   - ✅ **OpenJDK**
5. Click **"Install"** — this will download ~5GB, wait 15-30 minutes

### Step 2.3: Install VS Code (Optional but Recommended)

1. Go to: https://code.visualstudio.com/
2. Download and install
3. This lets you VIEW the code (you don't need to write any)

### Step 2.4: Install Git (to download this project)

1. Go to: https://git-scm.com/downloads
2. Download for your OS and install (click Next on everything)

---

## 3. OPEN THIS PROJECT IN UNITY {#3-open-project}

### Step 3.1: Download the Project

1. Open a terminal/command prompt:
   - **Windows**: Press `Win + R`, type `cmd`, press Enter
   - **Mac**: Open "Terminal" from Applications > Utilities
2. Type this command and press Enter:
   ```
   git clone https://github.com/gromoney111/main-kiro.git
   ```
3. Wait for download to finish
4. The project is now in a folder called `main-kiro/RushIndiaStreetRunner/`

### Step 3.2: Open in Unity

1. Open **Unity Hub**
2. Click **"Projects"** tab on the left
3. Click **"Open"** button (top right)
4. Navigate to the folder: `main-kiro/RushIndiaStreetRunner/`
5. Select that folder and click "Open"
6. Unity will take 3-10 minutes to import the first time (you'll see a progress bar)
7. When done, you'll see the Unity Editor!

### What You Should See
- **Bottom panel**: "Project" window showing your folders
- **Left panel**: "Hierarchy" (objects in current scene)
- **Center**: "Scene" view (your 3D world)
- **Right panel**: "Inspector" (properties of selected object)

---

## 4. CREATE YOUR GAME SCENES {#4-create-scenes}

Scenes are like "pages" of your game. You need 8 scenes.

### Step 4.1: Create LoadingScene

1. Go to menu: **File > New Scene**
2. Choose **"Basic (Built-in)"** and click Create
3. **Save it**: File > Save As → navigate to `Assets/Scenes/` → name it `LoadingScene`

**Now set it up:**

4. In the Hierarchy panel (left side), right-click → **Create Empty**
5. Name it `_GameBootstrapper` (click the object, then type the name in Inspector on the right)
6. With `_GameBootstrapper` selected, in the Inspector panel (right side):
   - Click **"Add Component"** button at the bottom
   - Type `GameBootstrapper` in the search
   - Click it to add it
7. Right-click in Hierarchy → **Create Empty** → name it `_LoadingUI`
8. Add Component → search `LoadingUI` → add it

**Create the Canvas (for UI):**

9. Right-click in Hierarchy → **UI > Canvas**
10. A Canvas appears. In its Inspector, set:
    - Canvas Scaler > UI Scale Mode: **"Scale With Screen Size"**
    - Reference Resolution: **1080 x 1920**
    - Match: **0.5**
11. Right-click on Canvas → **UI > Panel** → name it `Background`
12. Right-click on Canvas → **UI > Slider** → name it `ProgressBar`
13. On the `_LoadingUI` object, drag the `ProgressBar` into the "Progress Bar" slot in Inspector

### Step 4.2: Create MainMenu Scene

1. **File > New Scene** → Save as `Assets/Scenes/MainMenu`
2. Right-click Hierarchy → Create Empty → name `_MainMenuUI`
3. Add Component → `MainMenuUI`
4. Create a **Canvas** (right-click → UI > Canvas):
   - Canvas Scaler: Scale With Screen Size, 1080×1920, Match 0.5
5. Inside Canvas, create:
   - **UI > Text - TextMeshPro** → name `TitleText` → type "RUSH INDIA" in text field
   - **UI > Text - TextMeshPro** → name `CoinText` → shows coin count
   - **UI > Text - TextMeshPro** → name `GemText` → shows gem count
   - **UI > Button - TextMeshPro** → name `PlayButton` → change text to "PLAY"
   - **UI > Button - TextMeshPro** → name `ShopButton` → text: "SHOP"
   - **UI > Button - TextMeshPro** → name `RewardsButton` → text: "REWARDS"
   - **UI > Button - TextMeshPro** → name `SettingsButton` → text: "SETTINGS"
6. Drag each button/text to the matching slots on `MainMenuUI` component in Inspector

### Step 4.3: Create CitySelection Scene

1. **File > New Scene** → Save as `Assets/Scenes/CitySelection`
2. Create Empty → name `_CitySelection` → Add Component → `CitySelectionManager`
3. Create Canvas (same settings as above)
4. Inside Canvas:
   - **UI > Scroll View** → name `CityGrid` (this scrolls through cities)
   - **UI > Button** → name `PlayButton` → text: "RUN!"
   - **UI > Button** → name `BackButton` → text: "← BACK"
   - **UI > Text - TMP** → name `CityName`
   - **UI > Text - TMP** → name `CityDescription`

### Step 4.4: Create Gameplay Scene

1. **File > New Scene** → Save as `Assets/Scenes/Gameplay`
2. Create Empty → name `_GameplayInit` → Add Component → `GameplayInitializer`
3. Create Empty → name `Player`:
   - Add Component → **Character Controller** (built-in Unity component)
   - Add Component → `PlayerController`
   - Set Character Controller: Height=2, Radius=0.3, Center=(0, 1, 0)
4. Create Empty → name `SwipeManager` → Add Component → `SwipeManager`
5. Create a **Canvas** for the HUD:
   - **UI > Text - TMP** → name `ScoreText` (top center)
   - **UI > Text - TMP** → name `CoinText` (top left)
   - **UI > Button** → name `PauseButton` (top right)
6. Create Empty → name `_UIManager` → Add Component → `UIManager`
7. Create a **Directional Light** (right-click → Light > Directional Light)
8. Create a simple ground:
   - Right-click → **3D Object > Plane**
   - Scale it: X=3, Y=1, Z=100 (makes a long road)
   - Position: (0, 0, 50)

### Step 4.5: Create Remaining Scenes

Repeat the pattern for:
- `Assets/Scenes/Shop` - Add `CharacterShop` component
- `Assets/Scenes/Rewards` - Add `DailyRewardManager` reference
- `Assets/Scenes/Settings` - Add `SettingsUI` component
- `Assets/Scenes/GameOver` - Add `GameOverUI` component

### Step 4.6: Set Build Order

1. Go to **File > Build Settings**
2. Click **"Add Open Scenes"** for each scene, OR drag scenes from Project panel
3. Order them (drag to reorder):
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
4. Set Platform to **Android** (click Android in the list, then "Switch Platform")

---

## 5. CREATE YOUR 3D OBJECTS {#5-create-objects}

### Step 5.1: Create the Player (Simple Version)

1. Open the Gameplay scene
2. Select the `Player` object in Hierarchy
3. Right-click on Player → **3D Object > Capsule** (this is your temporary player model)
4. The capsule appears as a child of Player
5. In Inspector, set capsule position to (0, 1, 0)
6. Create a material for color:
   - In Project panel, right-click `Assets/Art/Materials/` → **Create > Material**
   - Name it `PlayerMaterial`
   - Click on it, change **Albedo** color to bright orange
   - Drag this material onto the capsule in the Scene view

### Step 5.2: Create Obstacles

1. In Project panel, go to `Assets/Prefabs/Obstacles/`
2. In Hierarchy, right-click → **3D Object > Cube**
3. Name it `Obs_Car_Red`
4. Scale it: X=1.5, Y=1.5, Z=3 (car-sized)
5. Add a red material (create one like Step 5.1)
6. **IMPORTANT**: In Inspector, set Tag to **"Obstacle"**
   - Click "Tag" dropdown at top → "Add Tag" → create "Obstacle" tag
   - Select the cube again, set its tag to "Obstacle"
7. Add Component → **Box Collider** (should already be there for a cube)
8. **Drag the cube from Hierarchy INTO the `Assets/Prefabs/Obstacles/` folder** in Project panel
   - This creates a "Prefab" (reusable template)
9. Delete the cube from Hierarchy (the prefab is saved)

**Repeat for more obstacles:**
- `Obs_Bus_Blue` — Scale (2, 2.5, 5), blue material
- `Obs_Barricade_01` — Scale (3, 1.5, 0.3), yellow material
- `Obs_Auto_Green` — Scale (1.2, 1.5, 2), green material

### Step 5.3: Create Coins

1. Right-click Hierarchy → **3D Object > Cylinder**
2. Name it `Collectible_Coin`
3. Scale: (0.5, 0.05, 0.5) — flat disc shape
4. Rotation: X=90 (so it faces the player)
5. Add yellow/gold material
6. **Set Tag to "Coin"** (create the tag first if needed)
7. Add Component → **Sphere Collider**
   - Check ✅ **"Is Trigger"** — VERY IMPORTANT
   - Radius: 0.5
8. Add Component → `CoinRotator` (makes it spin!)
9. Drag to `Assets/Prefabs/Collectibles/` folder to save as prefab

### Step 5.4: Create Road Segment

1. Right-click → **3D Object > Plane**
2. Name it `RoadSegment`
3. Scale: X=0.9, Y=1, Z=3 (makes a 9×30 unit road)
4. Add a dark grey material
5. Drag to `Assets/Prefabs/Environment/`

---

## 6. WIRE EVERYTHING TOGETHER {#6-wire-everything}

### Step 6.1: Connect Prefabs to ObstacleSpawner

1. Open Gameplay scene
2. Create Empty → name `_ObstacleSpawner` → Add Component → `ObstacleSpawner`
3. In Inspector, you'll see empty slots:
   - **Common Obstacles**: Click the little lock icon, set Size to 4
   - Drag your obstacle prefabs from `Assets/Prefabs/Obstacles/` into each slot
   - **Coin Prefab**: Drag `Collectible_Coin` prefab here
   - **Gem Prefab**: (create a gem like the coin but purple, tag "Gem")

### Step 6.2: Connect EnvironmentManager

1. Create Empty → name `_EnvironmentManager` → Add Component → `EnvironmentManager`
2. Drag `RoadSegment` prefab into the "Road Segment Prefab" slot
3. Drag the Directional Light into the "Directional Light" slot

### Step 6.3: Connect UIManager

1. Select `_UIManager`
2. Drag your HUD text elements into matching slots:
   - ScoreText → "Score Text" slot
   - CoinText → "Coin Text" slot
   - PauseButton → "Pause Button" slot

### Step 6.4: Set Up Camera

1. Select **Main Camera** in Hierarchy
2. Position it: (0, 5, -10)
3. Rotation: (30, 0, 0) — looking down at the road
4. This gives a "behind the player" runner view

---

## 7. TEST YOUR GAME {#7-test-game}

### Step 7.1: Quick Test in Editor

1. Make sure you have `LoadingScene` open
2. Press the **▶ Play** button at the top center of Unity
3. The game should:
   - Show loading screen → transition to Main Menu
   - Click PLAY → City Selection → Click a city → Gameplay starts
   - Player runs forward, you can swipe (use Arrow Keys in editor)
   - Obstacles appear and coins can be collected

### Step 7.2: Fix Common Issues

| Problem | Solution |
|---------|----------|
| "Script not found" error | Make sure the file is named exactly right |
| Null reference error | Check Inspector - is a slot empty that needs a prefab? |
| Player falls through ground | Make sure road has a Collider component |
| Can't collect coins | Make sure coin's Sphere Collider has "Is Trigger" ✅ |
| Obstacles don't kill player | Make sure obstacle Tag is "Obstacle" exactly |

### Step 7.3: Test on Your Phone

1. Enable **Developer Mode** on your Android phone:
   - Settings > About Phone > tap "Build Number" 7 times
   - Go back to Settings > Developer Options > enable "USB Debugging"
2. Connect phone via USB cable
3. In Unity: File > Build Settings > select your phone from the device list
4. Click **"Build and Run"**
5. Game installs and opens on your phone!

---

## 8. ADD REAL 3D ART (FREE ASSETS) {#8-add-art}

Your game will look basic with cubes and capsules. Here's how to get FREE 3D models:

### Free Asset Sources

| Source | What to Get | Link |
|--------|-------------|------|
| Unity Asset Store | Search "Low Poly Cars Free" | assetstore.unity.com |
| Unity Asset Store | Search "Low Poly Character Free" | assetstore.unity.com |
| Kenney.nl | Free game assets (no login) | kenney.nl/assets |
| Mixamo.com | Free character models + animations | mixamo.com |
| Poly.pizza | Free low-poly 3D models | poly.pizza |

### How to Import from Asset Store

1. In Unity: **Window > Asset Store** (or open assetstore.unity.com in browser)
2. Search for "low poly car" or "endless runner"
3. Click a FREE asset → "Add to My Assets" → "Open in Unity"
4. Import window appears → click "Import"
5. Models appear in your Project panel
6. Replace your cube obstacles with the real 3D car models!

### Recommended FREE Asset Packs
- "Low Poly Cars" — for obstacles
- "City Builder" — for road decorations
- "Low Poly Animated People" — for player character
- "Simple UI" — for buttons and icons
- "Casual Game Sounds" — for SFX and music

---

## 9. SETUP ADS (MAKE MONEY) {#9-setup-ads}

### Step 9.1: Create AdMob Account

1. Go to: https://admob.google.com
2. Sign in with your Google account
3. Click "Get Started"
4. Accept terms of service
5. Add your app:
   - Platform: Android
   - App name: Rush India Street Runner
   - "App is NOT listed on a supported app store" (select this for now)

### Step 9.2: Create Ad Units

1. In AdMob dashboard, go to **Apps > Your App > Ad Units**
2. Create THREE ad units:
   - **Banner** → get the ID (looks like: ca-app-pub-XXXXXXX/XXXXXXX)
   - **Interstitial** → get the ID
   - **Rewarded** → get the ID
3. Write down all three IDs!

### Step 9.3: Put Your Ad IDs in the Game

1. In Unity, find `Assets/Scripts/Core/AdManager.cs`
2. Double-click to open in VS Code
3. Find these lines (near the top):
   ```
   [SerializeField] private string bannerAdId = "ca-app-pub-3940256099942544/6300978111";
   [SerializeField] private string interstitialAdId = "ca-app-pub-3940256099942544/1033173712";
   [SerializeField] private string rewardedAdId = "ca-app-pub-3940256099942544/5224354917";
   ```
4. Replace the IDs with YOUR real AdMob IDs
5. Save the file

### Step 9.4: Install Google Mobile Ads SDK

1. Download from: https://github.com/googleads/googleads-mobile-unity/releases
2. Get the `.unitypackage` file
3. In Unity: **Assets > Import Package > Custom Package**
4. Select the downloaded file → Import everything
5. Follow the setup wizard that appears

---

## 10. BUILD THE APK/AAB FILE {#10-build}

### Step 10.1: Configure Player Settings

1. In Unity: **Edit > Project Settings > Player**
2. Click the Android tab (robot icon)
3. Set these EXACTLY:

**Company Name:** `YourName` (use your name or company)
**Product Name:** `Rush India Street Runner`
**Version:** `1.0.0`

**Other Settings:**
- Package Name: `com.yourname.rushindiastreetrunner` (use your own domain-style name)
- Minimum API Level: **Android 7.0 (API 24)**
- Target API Level: **Highest installed**
- Scripting Backend: **IL2CPP** (MUST be this for Play Store)
- Target Architectures: Check **ARM64** only

### Step 10.2: Create a Keystore (Your App's Identity)

1. In Build Settings (File > Build Settings)
2. Click **"Player Settings"** → Publishing Settings
3. Under **Keystore Manager**, click "Create New"
4. Choose a safe location (NOT inside the project folder!)
5. Set a password (WRITE IT DOWN — you can NEVER recover this!)
6. Fill in: Your name, organization, city, country
7. Click Create

⚠️ **CRITICAL**: Back up your keystore file! If you lose it, you can NEVER update your app on Play Store!

### Step 10.3: Build the AAB

1. **File > Build Settings**
2. Platform: Android (should already be selected)
3. Check ✅ **"Build App Bundle (Google Play)"** — IMPORTANT!
4. UNcheck "Development Build"
5. Click **"Build"**
6. Choose where to save (Desktop is fine)
7. Name it `RushIndiaStreetRunner.aab`
8. Wait 5-15 minutes for build to complete
9. You now have your game file ready to upload!

---

## 11. CREATE GOOGLE PLAY DEVELOPER ACCOUNT {#11-play-account}

### Step 11.1: Sign Up

1. Go to: https://play.google.com/console
2. Click "Create account" (or sign in with Google)
3. Choose **"Personal"** account type
4. Pay the **$25 registration fee** (one-time, lifetime)
5. Fill in your details, accept all agreements
6. Wait for verification (can take 24-48 hours)

### Step 11.2: Create Your App

1. In Play Console, click **"Create app"**
2. Fill in:
   - App name: `Rush India: Street Runner`
   - Default language: English (United States)
   - App or game: **Game**
   - Free or paid: **Free**
3. Check all the declarations boxes
4. Click "Create app"

---

## 12. UPLOAD TO PLAY STORE {#12-upload}

### Step 12.1: Prepare Store Listing

You need these graphics (create in Canva.com for free):

| Asset | Size | What It Is |
|-------|------|-----------|
| App Icon | 512×512 px | Your game logo (PNG, no transparency) |
| Feature Graphic | 1024×500 px | Banner shown on store page |
| Screenshots | 1080×1920 px | At least 2 screenshots of gameplay |
| Short Description | 80 characters max | One-line pitch |
| Full Description | 4000 characters max | Full game description |

### Step 12.2: Fill Out Store Listing

1. In Play Console → Your app → **Store listing**
2. Upload app icon
3. Upload feature graphic
4. Upload 4-8 screenshots
5. Write short description:
   ```
   Run through 15 Indian cities! Dodge traffic, collect coins, beat high scores!
   ```
6. Write full description (copy from README.md in the project)
7. Click Save

### Step 12.3: Content Rating

1. Go to **App content > Content rating**
2. Click "Start questionnaire"
3. Category: **Casual Game**
4. Answer honestly (no violence, no sexual content, has ads)
5. Submit → You'll get **PEGI 3 / Everyone** rating

### Step 12.4: Set Up Pricing

1. Go to **Monetization > App pricing**
2. Select **"Free"**
3. Save

### Step 12.5: Upload Your AAB

1. Go to **Release > Production**
2. Click **"Create new release"**
3. Under "App bundles", click **"Upload"**
4. Select your `.aab` file from Step 10.3
5. Wait for upload and processing
6. Add release notes: "Initial release - Rush India: Street Runner v1.0.0"
7. Click **"Review release"**
8. Click **"Start rollout to Production"**
9. Confirm

### Step 12.6: Wait for Review

- Google reviews your app (usually 1-7 days for new developers)
- You'll get an email when approved
- Your game is now LIVE on Play Store! 🎉

---

## 13. COMMON PROBLEMS & FIXES {#13-troubleshooting}

### Build Errors

| Error | Fix |
|-------|-----|
| "Android SDK not found" | Unity Hub > Installs > your version > gear icon > Add Modules > Android SDK |
| "IL2CPP not installed" | Same as above, add IL2CPP module |
| "Gradle build failed" | File > Build Settings > uncheck "Custom Gradle Template" |
| "Minimum API level" | Player Settings > Android > set Min API to 24 |
| "Target architecture" | Player Settings > check ONLY ARM64 |
| "Script has errors" | Look at Console window (Window > Console) for red text |

### Play Store Rejections

| Rejection Reason | Fix |
|-----------------|-----|
| "Incomplete functionality" | Make sure game is playable (not just menus) |
| "Privacy policy needed" | Create a free one at privacypolicygenerator.info |
| "Ads declaration wrong" | In App content > Ads, declare "Yes, contains ads" |
| "Needs content rating" | Complete the content rating questionnaire |
| "Metadata policy" | Don't use fake screenshots or misleading description |

### Making It Look Professional

1. **Replace cube obstacles with real 3D models** (free from Asset Store)
2. **Add background music** (free from freesound.org or pixabay.com)
3. **Add sound effects** (free SFX packs from Asset Store)
4. **Create a nice app icon** (use Canva.com, free)
5. **Take good screenshots** (play the game with nice art, then screenshot)

---

## 💡 TIPS FOR SUCCESS

### Make Money
- Rewarded ads (watch ad for coins) make the MOST money
- Don't show too many ads (players will uninstall)
- Add IAP (coin packs) for players who hate ads

### Get Downloads
- Use keywords in your description: "Indian endless runner", "subway surfer alternative India"
- Ask friends/family to download and leave 5-star reviews in the first week
- Share on social media (Instagram Reels, YouTube Shorts of gameplay)
- The "Share Score" feature helps spread the game virally

### After Launch
- Watch your crash reports in Play Console
- Fix bugs quickly (bad reviews kill downloads)
- Add new cities/characters every month to keep players coming back
- Respond to user reviews professionally

---

## 🎓 WANT TO LEARN MORE?

Free tutorials to improve your game:

| Topic | Resource |
|-------|----------|
| Unity Basics | youtube.com/unity (official channel) |
| Endless Runner Tutorial | Search "Brackeys endless runner" on YouTube |
| Mobile Game Design | Search "Thomas Brush mobile game" on YouTube |
| AdMob Setup | Search "Unity AdMob 2024 tutorial" on YouTube |
| Play Store ASO | Search "App Store Optimization 2024" |

---

## ✅ FINAL CHECKLIST BEFORE PUBLISHING

- [ ] Game loads without crashing
- [ ] Player can run, jump, slide, change lanes
- [ ] Obstacles appear and kill the player
- [ ] Coins can be collected and show in HUD
- [ ] Score increases while running
- [ ] Game Over screen appears on death
- [ ] Retry button works
- [ ] Main Menu buttons all navigate correctly
- [ ] Sound/Music can be toggled in Settings
- [ ] App icon looks good (512×512 PNG)
- [ ] Store screenshots show actual gameplay
- [ ] Privacy policy URL is set
- [ ] Content rating completed
- [ ] AAB builds without errors
- [ ] Tested on at least one real Android phone

**Once all boxes are checked → YOU'RE READY TO PUBLISH! 🚀**
