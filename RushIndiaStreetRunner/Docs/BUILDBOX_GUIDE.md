# Rush India: Street Runner - BUILDBOX 3 GUIDE

## Build Your Game with ZERO Coding!

This guide shows you EXACTLY how to recreate Rush India: Street Runner using Buildbox 3 - a true drag-and-drop game maker. No programming required!

---

## TABLE OF CONTENTS

1. What You'll Need
2. Install Buildbox 3
3. Open the Endless Runner Template
4. Customize Your Game (15 Phases)
5. Add Your 15 Indian Cities
6. Add Characters & Powerups
7. Setup Ads & In-App Purchases
8. Test on Your Phone
9. Export & Publish to Play Store
10. Troubleshooting

---

## 1. WHAT YOU'LL NEED

### Software
| Item | Cost | Where |
|------|------|-------|
| Buildbox 3 | Free trial then $19.99/month or $228/year | buildbox.com |
| Android phone (for testing) | You probably have one | - |
| Google Play Developer Account | $25 (one-time, lifetime) | play.google.com/console |

### Computer Requirements
- Windows 10/11 OR macOS 11+
- 8 GB RAM minimum (16 GB recommended)
- 10 GB free disk space
- Decent graphics card (any modern computer works)

### Total Investment
- Minimum to publish: $25 (Play Store fee only - use Buildbox free trial)
- Recommended: $25 + $19.99/month Buildbox = ~$45 first month

---

## 2. INSTALL BUILDBOX 3

### Step 2.1: Download Buildbox 3

1. Go to buildbox.com
2. Click "Get Started for Free" (top right)
3. Sign up with email or Google account
4. Choose "Buildbox 3" (we want this for 3D)
5. Download the installer for your OS (Windows or Mac)
6. Install it (just click Next on everything)

### Step 2.2: First Launch

1. Open Buildbox 3
2. Sign in with the account you created
3. You'll see the "Project Browser" - this is where all your games live
4. Click "+ New Project" at the top

---

## 3. OPEN THE ENDLESS RUNNER TEMPLATE

Buildbox 3 has built-in templates that match exactly what we want!

### Step 3.1: Choose Template

1. In the New Project window, look for templates:
   - "Martian Marathon" (RECOMMENDED - perfect endless runner template!)
   - "3D Runner" (alternative)
   - "Hyper Runner" (another option)

2. Click on "Martian Marathon" template
3. Click "Use Template" or "Create Project"
4. Name your project: RushIndiaStreetRunner
5. Buildbox will load the template - wait 1-2 minutes

### Step 3.2: What You Just Got (FREE!)

The template comes with:
- A 3D running character
- Endless procedural road generation
- Coin collectibles
- Obstacles (rocks, walls)
- Lane-switching swipe controls
- Jump and slide mechanics
- Score system
- Game over screen
- Main menu
- Pause menu
- Sound effects

You already have a working endless runner! Now we customize it into Rush India.

### Step 3.3: Press PLAY to Test

1. Click the green Play button at the top center of Buildbox
2. The game runs in a preview window
3. Use arrow keys (left/right/up/down) to test
4. Press Stop when done

You have a working game in 5 minutes!



---

## 4. CUSTOMIZE YOUR GAME - 15 PHASES

Now we transform the Mars template into Rush India: Street Runner.

---

### PHASE 1: Change the Character (15 minutes)

**Goal:** Replace the astronaut with a "Chaiwala" Indian character.

1. In Buildbox, look at the left panel - "Mind Map"
2. Find the node called "Character" or "Player"
3. Double-click to open it
4. In the Asset panel (right side), find the character model
5. Right-click the character -> "Replace"

**Where to get free Indian characters:**

| Source | Link | Cost |
|--------|------|------|
| Mixamo | mixamo.com | FREE |
| Sketchfab | sketchfab.com (filter: Free, Animated) | FREE |
| Unity Asset Store | "Casual Indian Character" | $0-20 |
| TurboSquid | turbosquid.com | $0-50 |

**Search keywords:** "Indian man character", "running character low poly", "casual character"

6. Download the character model (.fbx or .obj file)
7. Drag and drop the file into Buildbox's asset panel
8. Click "Replace" on the existing character
9. Press Play to test - your new character now runs!

---

### PHASE 2: Change the Road/Environment (20 minutes)

**Goal:** Replace Mars terrain with a Mumbai/Delhi street.

1. In Mind Map, find "World" or "Environment" node
2. Double-click to open the World Editor
3. You'll see ground tiles, decorations, etc.

**Replace the road texture:**

1. Find the road/ground material in the asset list
2. Click on it -> properties appear in right panel
3. Click on "Texture" to change the image
4. Download a road texture from textures.com or poliigon.com (free with account)
5. Drag your road texture into Buildbox
6. Replace the existing texture

**Add Indian street decorations:**

1. In the World Editor, find empty side spaces
2. Drag in 3D models of buildings, signs, lamp posts
3. Free Indian-style assets from Sketchfab:
   - "Indian street vendor"
   - "Hindu temple low poly"
   - "Bollywood billboard"
   - "Indian shop"

---

### PHASE 3: Replace Obstacles with Indian Vehicles (30 minutes)

**Goal:** Replace rocks/aliens with auto-rickshaws, cars, buses.

**Free 3D models for obstacles:**

| Obstacle | Search on Sketchfab/TurboSquid | What to look for |
|----------|--------------------------------|------------------|
| Auto-rickshaw | "Indian auto rickshaw", "tuk-tuk" | Yellow/green 3-wheeler |
| Bus | "Indian bus", "BEST bus" | Red double-decker |
| Car | "Tata car", "low poly hatchback" | Compact car |
| Cycle Rickshaw | "cycle rickshaw" | Pedaled vehicle |
| Cow | "indian cow low poly" | Sacred cow obstacle! |
| Construction | "barricade construction" | Yellow barriers |

**Steps to replace:**

1. In Buildbox Mind Map -> find "Enemy" or "Obstacle" nodes
2. Double-click to open
3. Right-click the existing 3D model -> "Replace"
4. Drag your downloaded vehicle model
5. Adjust size if needed (Inspector panel on right)
6. Repeat for each obstacle type (use 5-8 different obstacles)

---

### PHASE 4: Customize Coins & Gems (10 minutes)

**Goal:** Make coins look like Indian rupee coins.

1. Find "Coin" node in Mind Map
2. Double-click to open
3. Replace the coin model with an Indian rupee coin (search "rupee coin 3D" on Sketchfab)
4. Or use the existing gold coin and just change color to:
   - Gold (Rs.1, Rs.2 coins): #FFD700
   - Silver (Rs.5, Rs.10): #C0C0C0
5. For gems, change to a colorful crystal (purple, blue, or red)

---

### PHASE 5: Add Indian Music & Sound Effects (15 minutes)

**Goal:** Replace generic music with Bollywood-inspired tracks.

**Free music sources:**

| Source | Link | License |
|--------|------|---------|
| Pixabay Music | pixabay.com/music | FREE for commercial use |
| Free Music Archive | freemusicarchive.org | FREE (check license) |
| Bensound | bensound.com | FREE (with credit) |
| YouTube Audio Library | studio.youtube.com -> Audio Library | FREE |

**Search keywords:**
- "Bollywood instrumental"
- "Indian fusion upbeat"
- "Bhangra electronic"
- "Tabla beat loop"
- "Indian background music"

**To add music in Buildbox:**

1. Drag the .mp3 or .wav file into the Sound asset panel
2. Find the Music Manager node in Mind Map
3. Drag your new music into the slot
4. Set "Loop" to YES
5. Volume: 0.5 (50%)

**Sound effects to add:**
- Coin collect: search "coin pickup sound"
- Jump: search "cartoon jump"
- Death: search "fail buzzer"
- Powerup: search "magic chime"



---

### PHASE 6: Customize the UI (Buttons, Menus, Colors) (45 minutes)

**Goal:** Apply the orange/yellow Indian theme.

#### Step 6.1: Change Color Scheme

In Buildbox, you can change colors of UI elements:

1. Find any UI button or panel in the Mind Map
2. Click on it -> Inspector shows color properties
3. Apply this color palette:

| UI Element | Color Code | Where to Use |
|-----------|-----------|--------------|
| Primary Orange | #FF6F00 | Play button, headers |
| Yellow Accent | #FFC107 | Coins, highlights |
| Pink/Magenta | #E91E63 | Gems, premium features |
| Dark Background | #1A1A2E | Menu backgrounds |
| White | #FFFFFF | Card surfaces |

#### Step 6.2: Update Game Title

1. Find the "Title Screen" or "Main Menu" node
2. Look for the title text
3. Change "Martian Marathon" to "RUSH INDIA: STREET RUNNER"
4. Use a bold, energetic font:
   - Download free fonts from Google Fonts (fonts.google.com)
   - Recommended: Bangers, Fredoka One, Russo One

#### Step 6.3: Add Indian Theme Imagery

1. Create or download a banner image for the title screen
2. Use Canva.com (free) to make:
   - Logo: "Rush India" with running character silhouette
   - Background: Indian city skyline
3. Drag images into Buildbox to use as menu backgrounds

---

### PHASE 7: Add Daily Rewards System (20 minutes)

Buildbox has built-in support for daily rewards.

1. In Mind Map, look for "Daily Reward" node (or add one from Asset Library)
2. If not present:
   - Click "+ Add Node" -> search "Daily Reward"
   - Drag onto Mind Map
3. Configure rewards (right panel):

| Day | Coins | Gems | Special |
|-----|-------|------|---------|
| 1 | 100 | 0 | - |
| 2 | 150 | 1 | - |
| 3 | 200 | 2 | - |
| 4 | 300 | 3 | - |
| 5 | 400 | 5 | - |
| 6 | 500 | 5 | - |
| 7 | 1000 | 10 | New character unlock |

4. Connect this node to your Main Menu node

---

### PHASE 8: Add Mission System (25 minutes)

1. Add "Mission" node from Asset Library
2. Create 3 daily missions:
   - "Collect 50 coins in one run" -> Reward: 100 coins
   - "Run 500 meters" -> Reward: 50 coins + 1 gem
   - "Score 5000 points" -> Reward: 75 coins + 2 gems
3. Set them to reset every 24 hours

---

### PHASE 9: Add Powerups (40 minutes)

The Martian Marathon template has Magnet and Shield powerups already. We add three more:

#### Coin Magnet (already in template)
- Configure: Duration = 8 seconds
- Visual: Yellow magnetic glow around player

#### Shield (already in template)
- Configure: Duration = 10 seconds
- Visual: Blue bubble around player

#### Add Jetpack (NEW)
1. Add "Powerup" node -> name it "Jetpack"
2. Effect: Lift player above obstacles
3. Duration: 5 seconds
4. Visual: Flame trail VFX

#### Add Double Coins (NEW)
1. Add "Powerup" node -> name it "DoubleCoins"
2. Effect: Multiply coin value by 2
3. Duration: 10 seconds

#### Add Speed Boost (NEW)
1. Add "Powerup" node -> name it "SpeedBoost"
2. Effect: Increase run speed by 50%
3. Duration: 5 seconds + invincibility

---

### PHASE 10: Add Score Multiplier & High Score Save (10 minutes)

Already built into Buildbox! Just configure:

1. Find "Score Manager" node
2. Set:
   - Base score per second: 10
   - Coin bonus: 10 per coin
   - Gem bonus: 50 per gem
3. Find "Save System" node -> enable "Save High Score"

---

### PHASE 11: Add Pause Menu (5 minutes)

Already in template! Just customize:

1. Find "Pause Menu" node
2. Style buttons with orange theme
3. Add buttons:
   - Resume
   - Restart
   - Sound Toggle
   - Music Toggle
   - Quit to Menu

---

### PHASE 12: Add Settings Screen (15 minutes)

1. Add "Settings" scene from Mind Map
2. Add toggles:
   - Sound Effects: ON/OFF
   - Music: ON/OFF
   - Vibration: ON/OFF
3. Add buttons:
   - Restore Purchases
   - Privacy Policy
   - Rate Us
   - Reset Progress

---

### PHASE 13: Add Game Over Screen (10 minutes)

Already in template! Customize to show:

1. Final Score (big, centered)
2. High Score (smaller, below)
3. Coins Earned (with animation)
4. NEW HIGH SCORE! label (animated, only if applicable)
5. Buttons:
   - Try Again
   - Watch Ad (+50 coins)
   - Main Menu
   - Share Score (super important for viral!)

---

### PHASE 14: Add "Choose Your City" Screen (60 minutes)

This is the big one - the unique Rush India feature!

#### Step 14.1: Create City Selection Scene

1. In Mind Map, right-click empty space -> "Add Scene"
2. Name it "CitySelection"
3. Connect it: MainMenu -> CitySelection -> Gameplay

#### Step 14.2: Design the Layout

1. In CitySelection scene, add a scrollable grid:
   - Asset Library -> Search "Scrollable List"
   - Drag onto scene
2. Configure: 3 columns x 5 rows = 15 slots

#### Step 14.3: Create City Cards (Repeat 15 times)

For EACH of the 15 cities, create a card:

1. Drag "Button" asset onto the grid
2. Configure each card:

| City | Background Color | Image | Tagline |
|------|-----------------|-------|---------|
| Jaipur | Pink #E91E63 | Hawa Mahal photo | "The Pink City" |
| Mumbai | Blue #1565C0 | Gateway of India | "Maximum City" |
| Delhi | Orange #F57C00 | India Gate | "Capital of India" |
| Bangalore | Purple #7C4DFF | Tech parks | "Silicon Valley" |
| Hyderabad | Teal #00897B | Charminar | "City of Pearls" |
| Kolkata | Yellow #FDD835 | Howrah Bridge | "City of Joy" |
| Chennai | Orange #E65100 | Marina Beach | "Gateway to South" |
| Pune | Green #43A047 | Shaniwar Wada | "Oxford of East" |
| Ahmedabad | Orange #FF6F00 | Sabarmati | "Vibrant Gujarat" |
| Lucknow | Brown #6D4C41 | Bara Imambara | "City of Nawabs" |
| Chandigarh | Green #1B5E20 | Rock Garden | "City Beautiful" |
| Udaipur | Blue #0277BD | City Palace | "City of Lakes" |
| Jodhpur | Blue #1565C0 | Mehrangarh | "Blue City" |
| Surat | Pink #AD1457 | Surat Castle | "Diamond City" |
| Goa | Teal #00BFA5 | Beach scene | "Beach Paradise" |

#### Step 14.4: Hook Up Each City to Gameplay

For each city card:
1. Click the card
2. In Inspector -> "On Click" action
3. Set: Save city ID + Load Gameplay scene
4. Use Buildbox's "Variable Manager" to store selected city

#### Step 14.5: Apply City Theme to Gameplay

In the Gameplay scene:
1. Add "Variable Reader" node
2. Read the saved city variable
3. Use "Conditional" logic blocks (visual, no code!):
   - IF city = "jaipur" -> use pink road texture, Hawa Mahal background
   - IF city = "mumbai" -> use grey road, rain effect, Mumbai skyline
   - ... (repeat for each city)

**Tip**: Don't worry if you only do 3-5 cities at first - you can launch with those and add more in updates!

---

### PHASE 15: Add Difficulty Scaling (10 minutes)

1. Find "Game Manager" node
2. Set:
   - Starting speed: 8
   - Max speed: 25
   - Speed increase: +0.05 per second
   - Spawn rate decrease: -0.02 per second (obstacles come faster)



---

## 5. ADD YOUR 15 INDIAN CITIES (Detailed)

### Strategy: Start Small, Add More Later

**Launch v1.0 with 3 cities:** Jaipur, Mumbai, Delhi
- This is FASTER and lets you publish sooner
- Add 2-3 cities per monthly update
- Players love free content updates!

### How Each City Differs

For each city, customize 5 things:

| Customization | How to Change in Buildbox |
|---------------|---------------------------|
| 1. Road texture | Replace ground material image |
| 2. Side decorations | Different building/landmark prefabs |
| 3. Traffic obstacles | City-specific vehicles (e.g., Kolkata has trams) |
| 4. Sky/lighting | Change skybox color and sun direction |
| 5. Background music | Different Indian regional music |

### Example: Jaipur (Pink City) Setup

```
Road texture:    Pink/sandy color (#D4A59A)
Sky color:       Warm blue with golden tint
Lighting:        Bright warm sun
Buildings:       Pink sandstone style
Obstacles:       Camels, auto-rickshaws, royal carts
Music:           Rajasthani folk fusion (search "rajasthani upbeat")
Special effect:  Dust particles in air
```

### Example: Mumbai (Maximum City) Setup

```
Road texture:    Wet asphalt grey
Sky color:       Overcast grey-blue
Lighting:        Diffused (cloudy day)
Buildings:       High-rises, local train tracks
Obstacles:       Yellow taxis, BEST buses, vada pav carts
Music:           Mumbai dance fusion (search "bollywood beats")
Special effect:  Rain particles falling
```

### Example: Goa (Beach Paradise) Setup

```
Road texture:    Sandy beige
Sky color:       Tropical bright blue
Lighting:        Bright sunshine
Buildings:       Palm trees, beach shacks
Obstacles:       Tourist scooters, beach carts, coconut sellers
Music:           Tropical chill (search "goa trance chill")
Special effect:  Floating sand/spray particles
```

---

## 6. ADD CHARACTERS & POWERUPS

### Character List

Create these 4 base characters + 2 festival skins:

| Character | Style | Where to Get | Cost (in-game) |
|-----------|-------|--------------|----------------|
| Chaiwala | White kurta + chai glass | Mixamo + custom outfit | FREE (default) |
| Businessman | Blue suit + briefcase | Sketchfab "office worker" | 500 coins |
| Delivery Boy | Orange uniform + bag | Mixamo + custom | 300 coins |
| Cricket Fan | Blue jersey + bat | Sketchfab "cricket player" | 10 gems |
| Holi Special | White + color splashes | Custom | IAP (Rs.49) |
| Diwali Special | Traditional + sparkles | Custom | IAP (Rs.49) |

### How to Add a New Character

1. In Mind Map, find "Character Selection" scene
2. Right-click -> "Duplicate Character"
3. Replace the model with new character
4. Set cost (coins or gems)
5. In "Save System", add unlock variable: char_businessman = false

### How to Switch Characters

1. In Character Selection scene, each character button:
   - On Click: Save chosen character ID
2. In Gameplay scene:
   - On Start: Load saved character ID
   - Spawn the matching character model

---

## 7. SETUP ADS & IN-APP PURCHASES

This is HOW you make money. Buildbox makes it easy!

### Step 7.1: Sign Up for AdMob

1. Go to admob.google.com
2. Sign in with Google account
3. Create app -> Android, name "Rush India Street Runner"
4. Create ad units:
   - Banner Ad -> copy the Ad Unit ID
   - Interstitial Ad -> copy the Ad Unit ID
   - Rewarded Ad -> copy the Ad Unit ID

### Step 7.2: Add AdMob to Buildbox

1. In Buildbox: Project Settings -> Ads
2. Select AdMob
3. Paste your three Ad Unit IDs:
   - Banner ID
   - Interstitial ID
   - Rewarded ID

### Step 7.3: Configure Ad Triggers

In Mind Map, you can add ad nodes:

| Ad Type | Trigger | How Often |
|---------|---------|-----------|
| Banner | Always on Main Menu | Continuous |
| Interstitial | After Game Over | Every 3 games |
| Rewarded | "Watch Ad for +50 coins" button | Player choice |

**To add Interstitial after game over:**
1. Find "Game Over" scene
2. Drag "Show Interstitial Ad" node from Asset Library
3. Connect it: Game Over -> Show Ad -> Game Over screen

**To add Rewarded "Watch Ad for Coins":**
1. In Game Over scene, add a button: "Watch Ad +50 coins"
2. On Click: Drag "Show Rewarded Ad" node
3. On Reward Earned: Add "Add Coins (50)" node

### Step 7.4: Setup IAP (In-App Purchases)

1. In Project Settings -> In-App Purchases
2. Add products:

| Product ID | Type | Price | What it gives |
|-----------|------|-------|---------------|
| removeads | Non-Consumable | $1.99 | No more ads |
| coins_500 | Consumable | $0.99 | 500 coins |
| coins_2000 | Consumable | $2.99 | 2000 coins |
| coins_5000 | Consumable | $5.99 | 5000 coins |
| gems_50 | Consumable | $4.99 | 50 gems |
| premium_bundle | Non-Consumable | $9.99 | All characters + 5000 coins |
| festival_pack | Non-Consumable | $2.99 | Holi + Diwali skins |

3. Setup these same products later in Google Play Console (see Phase 9)



---

## 8. TEST ON YOUR PHONE

### Step 8.1: Test in Buildbox Preview

1. Click Play in Buildbox
2. Test EVERYTHING:
   - All cities load correctly
   - Characters can be unlocked
   - Powerups work
   - Sound plays
   - Score saves
   - Daily rewards trigger

### Step 8.2: Test on Real Android Phone

#### Method 1: Buildbox Preview App (Easiest!)

1. Install "Buildbox Preview" from Play Store on your phone
2. In Buildbox on PC: File -> Preview on Device
3. Scan the QR code on your phone
4. Game streams to your phone INSTANTLY!

#### Method 2: Build APK and Install

1. File -> Export -> Android (APK)
2. Save the APK file
3. Email it to yourself OR transfer via USB
4. On phone: enable "Install from Unknown Sources"
5. Tap APK to install
6. Open and play!

### Common Test Issues

| Problem | Fix |
|---------|-----|
| Game crashes on phone | Check Console in Buildbox for errors |
| Ads don't show | Wait - AdMob takes 24h to start serving real ads |
| Save doesn't work | Make sure "Save System" node is connected |
| Music doesn't play | Check device volume + Buildbox sound settings |
| Lag/frame drops | Reduce particle effects, lower graphics quality |

---

## 9. EXPORT & PUBLISH TO PLAY STORE

### Step 9.1: Configure Project Settings

In Buildbox: File -> Project Settings

| Setting | Value |
|---------|-------|
| Game Name | Rush India: Street Runner |
| Bundle ID (Android) | com.yourname.rushindiastreetrunner |
| Version | 1.0.0 |
| Build Number | 1 |
| Min Android Version | API 24 (Android 7.0) |
| Target Android Version | API 34 (Android 14) |
| Orientation | Portrait |
| Icon | Upload 512x512 PNG |
| Splash Screen | Upload 1080x1920 PNG |

### Step 9.2: Create App Icon (512x512 PNG)

Use Canva.com (FREE):
1. Create design -> Custom size -> 512x512 px
2. Add Indian street runner imagery
3. Add bold text "RUSH INDIA"
4. Use orange/yellow gradient
5. Download as PNG

### Step 9.3: Export AAB File

**IMPORTANT:** Google Play requires AAB format (not APK) for new apps in 2026!

1. File -> Export -> Android App Bundle (AAB)
2. Choose location to save
3. Buildbox compiles your game (5-15 minutes)
4. Output: RushIndiaStreetRunner.aab

### Step 9.4: Sign Your AAB (Critical!)

Buildbox can do this automatically:

1. In Project Settings -> Signing
2. Click "Create New Keystore"
3. Set password (WRITE IT DOWN - you can never recover it!)
4. Fill in your details
5. Save keystore file in a SAFE location (NOT in project folder)
6. Buildbox auto-signs the AAB when exporting

**WARNING:** BACK UP THE KEYSTORE! Without it, you can NEVER update your app on Play Store.

### Step 9.5: Create Google Play Developer Account

1. Go to play.google.com/console
2. Sign in with Google account
3. Click "Create account" -> choose "Personal"
4. Pay $25 registration fee (one-time, lifetime!)
5. Verify identity (can take 24-48 hours)

### Step 9.6: Create Your App on Play Console

1. In Play Console, click "Create app"
2. Fill in:
   - App name: Rush India: Street Runner
   - Default language: English (United States) OR Hindi
   - App or game: Game
   - Free or paid: Free
3. Check all declarations
4. Click "Create app"

### Step 9.7: Fill Out Store Listing

You need these (create in Canva.com for FREE):

| Asset | Size | Notes |
|-------|------|-------|
| App Icon | 512x512 PNG (no transparency) | Your logo |
| Feature Graphic | 1024x500 PNG | Banner shown on store |
| Phone Screenshots | 1080x1920 (portrait) | 4-8 screenshots |
| Tablet Screenshots | 1920x1200 (landscape) | Optional |
| Promo Video | YouTube link | 30-120 seconds (optional) |

**Store Listing Text:**

**Short description (80 characters max):**
```
Run through 15 Indian cities! Dodge traffic, collect coins, beat high scores!
```

**Full description (paste this and edit):**
```
RUSH INDIA: STREET RUNNER

The most exciting endless runner game set in India!

RUN THROUGH 15 ICONIC INDIAN CITIES
- Jaipur - The Pink City with royal forts
- Mumbai - Maximum city with rain and chaos
- Delhi - Capital with metro and flyovers
- Bangalore - Tech city with neon roads
- Goa - Beach paradise with palm trees
And 10 more amazing cities!

SIMPLE CONTROLS
- Swipe Left/Right - Change lanes
- Swipe Up - Jump
- Swipe Down - Slide

AWESOME POWERUPS
- Coin Magnet
- Shield
- Jetpack
- Double Coins
- Speed Boost

UNIQUE INDIAN CHARACTERS
- Chaiwala
- Businessman
- Delivery Boy
- Cricket Fan
- Holi Special skin
- Diwali Special skin

ENDLESS FUN
- Daily rewards
- Missions & challenges
- Local leaderboard
- Beautiful 3D graphics
- Smooth gameplay

OPTIMIZED FOR ALL ANDROID PHONES

Download FREE now and see how far YOU can run!
```

### Step 9.8: Complete All Required Sections

In Play Console, complete EACH section (green checkmarks):

- [ ] App access (free, no special access needed)
- [ ] Ads (Yes, contains ads)
- [ ] Content rating (complete questionnaire -> expect Everyone/PEGI 3)
- [ ] Target audience (13+, NOT primarily for children)
- [ ] News app declaration (No)
- [ ] COVID-19 contact tracing (No)
- [ ] Data safety (declare data collection)
- [ ] Government apps (No)
- [ ] Financial features (No)
- [ ] Health (No)

### Step 9.9: Privacy Policy (REQUIRED!)

You MUST have a privacy policy:

1. Go to privacypolicygenerator.info (FREE)
2. Generate one for "mobile app with ads"
3. Host it for free on:
   - GitHub Pages (recommended)
   - Google Sites (sites.google.com)
   - Notion public page
4. Copy the public URL
5. Paste in Play Console -> Store presence > Store listing > Privacy Policy

### Step 9.10: Upload Your AAB

1. Play Console -> Production > Releases
2. Click "Create new release"
3. App bundles: Click "Upload"
4. Select your .aab file from Step 9.3
5. Wait for upload + processing (5-15 minutes)
6. Add release notes:
   ```
   Welcome to Rush India: Street Runner v1.0!
   - Run through 15 Indian cities
   - 4 unique characters
   - 5 powerups
   - Daily rewards & missions
   ```

### Step 9.11: Submit for Review

1. Click "Review release"
2. Click "Start rollout to Production"
3. Confirm
4. Status: "Pending Publication"
5. Google reviews your app:
   - First app: 7 days (manual review)
   - Future updates: 1-2 days

### Step 9.12: YOUR GAME IS LIVE!

Once approved, your game appears at:
```
https://play.google.com/store/apps/details?id=com.yourname.rushindiastreetrunner
```

Share it everywhere!

---

## 10. TROUBLESHOOTING

### Buildbox Issues

| Problem | Solution |
|---------|----------|
| Buildbox crashes on launch | Update graphics drivers, restart PC |
| Can't import 3D model | Convert to .fbx using Blender (free) |
| Project takes forever to load | Reduce 3D model polygons, optimize textures |
| Preview is laggy | Lower graphics quality in preview settings |
| Sound doesn't play | Check format - use .mp3 or .wav, max 44.1kHz |

### Export Issues

| Problem | Solution |
|---------|----------|
| AAB export fails | Update Buildbox to latest version |
| Keystore error | Re-create keystore, ensure password matches |
| File too large (>150MB) | Compress textures, reduce music quality |
| App fails to install on phone | Increment version number for each new build |

### Play Store Rejections

| Reason | Fix |
|--------|-----|
| "Misleading description" | Don't promise features your game doesn't have |
| "Crashes on launch" | Test on multiple Android versions before uploading |
| "Privacy policy missing" | Add the URL in Store Listing section |
| "Ads policy violation" | Don't show ads on every action - give breaks |
| "Content rating wrong" | Re-do the questionnaire honestly |

### Common Buildbox Quirks

1. Save before every Play test - Buildbox sometimes crashes
2. Don't use special characters in file names - stick to letters/numbers
3. 3D models too large? - use meshconvert.com to optimize
4. Music too loud? - reduce in Buildbox AND in source file
5. Buttons not clickable? - make sure they're on the top UI layer

---

## RECOMMENDED TIMELINE

### Week 1: Setup & Customize
- Day 1-2: Install Buildbox, open template, test it
- Day 3-4: Replace character, road, basic obstacles
- Day 5-7: Add 3 cities (Jaipur, Mumbai, Delhi)

### Week 2: Polish
- Day 8-10: Add powerups, characters, missions
- Day 11-12: Setup AdMob and IAP
- Day 13-14: Test thoroughly on phone

### Week 3: Publish
- Day 15: Create assets (icon, screenshots, banner)
- Day 16: Sign up for Google Play account ($25)
- Day 17: Setup store listing
- Day 18: Upload AAB
- Day 19-25: Wait for Google review (~7 days)
- Day 26: GAME LIVE ON PLAY STORE!

### Total: ~3-4 weeks for first version

---

## EXPECTED COSTS

| Item | Cost |
|------|------|
| Buildbox 3 (free trial OK for first version) | $0-228 |
| Google Play Developer | $25 (lifetime) |
| Premium 3D characters (optional) | $0-50 |
| Sound/music (optional, free options exist) | $0-30 |
| App icon design (Canva.com is free) | $0 |
| **TOTAL MINIMUM** | **$25** |
| **TOTAL TYPICAL** | **$45-100** |

---

## PRO TIPS

### Save Time
1. Start with 3 cities, not 15 - launch faster, add more in updates
2. Use Mixamo for ALL character animations - free and high quality
3. Reuse models across cities - same auto-rickshaw works in all cities
4. Don't perfect everything - ship version 1.0, improve later

### Make Money
1. Reward ads earn the most - encourage players to watch them
2. Time interstitials right - never during gameplay, only after death
3. First-time IAP discount - show "REMOVE ADS - 50% OFF!" for 24h
4. Festival packs work in India - release Holi/Diwali skins on those dates

### Get Downloads
1. Make great screenshots - first impression on Play Store
2. Use keywords: "Indian endless runner", "running game India"
3. Localize: Add Hindi/Tamil descriptions for India market
4. Share gameplay videos on Instagram Reels & YouTube Shorts
5. Ask friends to leave 5-star reviews in first week (very important!)

### After Launch
1. Monitor crashes in Play Console > Quality
2. Reply to all reviews professionally
3. Update monthly - add new city, character, or features
4. Run sales on IAP packs for festivals (Diwali, New Year)

---

## LEARN MORE (Free Buildbox Tutorials)

| Resource | Link |
|----------|------|
| Buildbox Official Tutorials | youtube.com/buildboxofficial |
| Buildbox Manual | buildbox.com/manual |
| Buildbox Community | community.buildbox.com |
| 3D Asset Resources | sketchfab.com/3d-models?features=downloadable&licenses=323a1 |
| Free Music | pixabay.com/music |

---

## FINAL CHECKLIST

Before publishing, verify:

- [ ] Game runs without crashes on at least 2 different phones
- [ ] All 15 cities load (or your launch city count)
- [ ] All powerups work correctly
- [ ] Coins save between sessions
- [ ] Ads show after game over
- [ ] IAP products are configured
- [ ] Privacy policy URL is set
- [ ] App icon is 512x512 PNG with no transparency
- [ ] At least 4 screenshots uploaded
- [ ] Store listing description is complete
- [ ] Content rating is approved
- [ ] AAB is signed with keystore
- [ ] Keystore is BACKED UP somewhere safe
- [ ] Tested with real device (not just emulator)

**Once all boxes are ticked -> YOU'RE READY TO PUBLISH!**

---

## SUCCESS STORY MINDSET

Many games on Play Store earn $1000-50,000/month from ads + IAP. Buildbox-made games like:
- Color Switch - 100M+ downloads, made $1M+
- The Line Zen - 5M+ downloads
- Sky - Featured on Apple App Store

You're using the SAME tool they used. With the right marketing, your game can succeed too!

---

**You've got this! Time to bring Rush India to the world!**
