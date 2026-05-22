# Google Play Store Submission Checklist

## Pre-Submission Requirements

### App Assets
- [ ] App Icon: 512×512px PNG (no alpha)
- [ ] Feature Graphic: 1024×500px PNG
- [ ] Screenshots: 2-8 per device type
  - Phone: 1080×1920px (portrait)
  - Tablet: 1920×1200px (landscape)
- [ ] Promo Video: YouTube link (30-120 seconds)
- [ ] Short Description: Max 80 characters
- [ ] Full Description: Max 4000 characters

### Store Listing Content
```
Short: "Run through 15 Indian cities! Dodge traffic, collect coins, beat high scores!"

Full Description Template:
🏃 Rush India: Street Runner - India's Most Exciting Endless Runner!

Run through 15 iconic Indian cities - from Jaipur's pink roads to Mumbai's 
monsoon streets! Dodge auto-rickshaws, sacred cows, and buses while 
collecting coins and activating powerups!

🌆 15 UNIQUE CITIES
Jaipur • Mumbai • Delhi • Bangalore • Hyderabad • Kolkata • Chennai 
and 8 more amazing cities!

🎮 EASY CONTROLS
• Swipe Left/Right: Change lanes
• Swipe Up: Jump
• Swipe Down: Slide

⚡ POWERUPS
Coin Magnet • Shield • Jetpack • Double Coins • Speed Boost

🧑‍🍳 UNIQUE CHARACTERS
Chaiwala • Businessman • Delivery Boy • Cricket Fan + Festival Skins!

🏆 FEATURES
• Daily Rewards
• Missions & Challenges
• Local Leaderboard
• Beautiful low-poly 3D graphics
• Smooth 60fps gameplay

Download FREE now and start running!
```

---

## Content Rating (IARC)

| Category | Rating |
|----------|--------|
| Violence | None |
| Sexual Content | None |
| Language | None |
| Controlled Substances | None |
| In-App Purchases | Yes |
| Ads | Yes (non-targeted for children) |

**Expected Rating**: Everyone (PEGI 3 / ESRB E)

---

## App Content Declaration

### Privacy Policy
- [ ] Create privacy policy page (required for apps with ads/IAP)
- [ ] Host at: https://yourwebsite.com/privacy
- [ ] Must mention: data collection, ad SDKs, analytics

### Data Safety Form
| Data Type | Collected | Shared | Purpose |
|-----------|----------|--------|---------|
| Device ID | Yes | Yes (AdMob) | Advertising |
| Purchase History | Yes | No | IAP functionality |
| Game Progress | Yes | No | App functionality |
| Crash Logs | Yes | Yes (Crashlytics) | App stability |

### Ads Declaration
- [ ] App contains ads: YES
- [ ] Ads are compliant with Families Policy: YES (if targeting kids)
- [ ] Using Google AdMob: YES

### Target Audience
- [ ] Primary: 13-17, 18-24, 25-34
- [ ] NOT targeting children under 13 (unless COPPA compliant)

---

## Technical Requirements

### AAB Build
- [ ] Build as Android App Bundle (.aab)
- [ ] Signed with upload key
- [ ] Min SDK: 24
- [ ] Target SDK: 34
- [ ] 64-bit support: ARM64 ✓

### Play App Signing
- [ ] Enrolled in Google Play App Signing
- [ ] Upload key stored securely (separate from signing key)

### Pre-Launch Report
- [ ] Upload AAB to internal/alpha track first
- [ ] Review automated test results
- [ ] Fix any crashes or ANRs
- [ ] Check accessibility warnings

---

## Monetization Setup

### AdMob
- [ ] Create AdMob account
- [ ] Link to Play Console
- [ ] Create ad units (banner, interstitial, rewarded)
- [ ] Replace test IDs with production IDs
- [ ] Set up ad mediation (optional)
- [ ] Configure frequency capping

### In-App Products (Google Play Console)
- [ ] Create managed products:
  - `com.rushindiastreetrunner.removeads` (Non-consumable)
  - `com.rushindiastreetrunner.coins_500` (Consumable)
  - `com.rushindiastreetrunner.coins_2000` (Consumable)
  - `com.rushindiastreetrunner.coins_5000` (Consumable)
  - `com.rushindiastreetrunner.gems_50` (Consumable)
  - `com.rushindiastreetrunner.premium_bundle` (Non-consumable)
  - `com.rushindiastreetrunner.festival_pack` (Non-consumable)
- [ ] Set pricing for all products
- [ ] Activate products

---

## Release Tracks

| Track | Purpose | Testers |
|-------|---------|---------|
| Internal | Dev testing | Team (max 100) |
| Closed Alpha | Bug finding | Invited users |
| Open Beta | Soft launch | Public opt-in |
| Production | Full release | Everyone |

### Recommended Rollout
1. Internal testing: 1 week
2. Closed alpha: 1 week (50 testers)
3. Open beta: 2 weeks (measure retention)
4. Production: 20% → 50% → 100% staged rollout

---

## Post-Launch

- [ ] Monitor crash-free rate (target: >99.5%)
- [ ] Monitor ANR rate (target: <0.5%)
- [ ] Respond to user reviews within 24hrs
- [ ] Track Day 1 / Day 7 retention
- [ ] Monitor ARPU/ARPPU
- [ ] Set up Firebase Analytics events
- [ ] Schedule first content update (new city/character)
