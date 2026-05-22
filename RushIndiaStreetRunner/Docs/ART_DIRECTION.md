# Art Direction Guide

## Visual Style: Stylized Cartoon-Realistic Low-Poly 3D

### Reference Style
- Think "Subway Surfers meets Indian Aesthetics"
- Low-poly geometry with smooth shading
- Vibrant saturated colors
- Clean silhouettes readable at mobile resolution
- Hand-painted texture feel (not photorealistic)

---

## Color Palette (Per City)

### Jaipur (The Pink City)
- Primary: #E91E63 (Pink)
- Road: Sandy pink #D4A59A
- Sky: Warm blue #87CEEB
- Accent: Gold #FFD700
- Mood: Royal, dusty, warm sunset

### Mumbai (Maximum City)
- Primary: #1565C0 (Deep Blue)
- Road: Wet asphalt #424242
- Sky: Overcast grey #607D8B
- Accent: Yellow taxi #FDD835
- Mood: Rainy, crowded, neon lights

### Delhi (Capital City)
- Primary: #F57C00 (Orange)
- Road: Dark grey #37474F
- Sky: Hazy #CFD8DC
- Accent: Red #D32F2F
- Mood: Wide, smoggy, grand

### Bangalore (Tech City)
- Primary: #7C4DFF (Purple/Neon)
- Road: Dark tech #263238
- Sky: Night sky #1A237E
- Accent: Neon green #00E676
- Mood: Futuristic, rainy, LED-lit

### Goa (Beach Paradise)
- Primary: #00BFA5 (Teal)
- Road: Sandy beige #F5F5DC
- Sky: Tropical blue #00E5FF
- Accent: Palm green #4CAF50
- Mood: Relaxed, bright, coastal

---

## Character Design Guidelines

### Style Rules
- Height: ~20 Unity units (fit in camera frame)
- Polycount: 1000-2000 tris per character
- Texture: Single 512×512 atlas per character
- Proportions: Slightly stylized (bigger head, expressive)
- Colors: Bright, distinct silhouettes
- Rigging: Humanoid rig (Unity compatible)

### Character List

| Character | Visual Style | Defining Feature |
|-----------|-------------|-----------------|
| Chaiwala | White kurta, chai glass in hand | Tea kettle backpack |
| Businessman | Blue suit, briefcase | Newspaper under arm |
| Delivery Boy | Orange/red uniform, bag | Large delivery backpack |
| Cricket Fan | Blue jersey, face paint | Cricket bat accessory |
| Holi Special | White clothes + color splashes | Rainbow powder VFX |
| Diwali Special | Traditional clothes + sparklers | Sparkle trail VFX |

---

## Environment Design

### Road Segments
- Width: 9 units (3 lanes × 3m)
- Length: 30 units per segment
- Sidewalks: 1.5m each side
- Lane markings: White dashed lines
- City-specific textures and props

### Side Decorations (Per City)
| City | Left Side | Right Side |
|------|----------|-----------|
| Jaipur | Pink sandstone buildings, forts | Market stalls, camel silhouettes |
| Mumbai | High-rises, local train tracks | Sea wall, food stalls |
| Delhi | Metro pillars, flyovers | Government buildings |
| Bangalore | IT parks with neon signs | Coffee shops, trees |
| Goa | Palm trees, beach shacks | Ocean, fishing boats |

### Landmark Backgrounds (Distant, non-interactive)
- Jaipur: Hawa Mahal, Amber Fort silhouette
- Mumbai: Gateway of India, Marine Drive skyline
- Delhi: India Gate, Qutub Minar
- Bangalore: Vidhana Soudha
- Goa: Church of Bom Jesus

---

## Obstacle Design

### Design Rules
- Clear silhouette at 10m+ distance
- Bright contrasting color from road
- Size communicates danger level
- Jumping obstacles: max 0.5m tall
- Sliding obstacles: 1.5m-2m tall barriers
- Full-lane obstacles: must dodge left/right

### Obstacle Poly Budget
| Type | Max Tris | Texture |
|------|---------|---------|
| Car (common) | 500 | 256×256 |
| Bus (large) | 800 | 512×256 |
| Barricade | 100 | 128×128 |
| Animal | 400 | 256×256 |
| Cart/Stall | 300 | 256×256 |

---

## VFX (Particle Systems)

### Required Effects
| Effect | Style | Duration |
|--------|-------|---------|
| Coin Collect | Gold sparkles + pop | 0.3s |
| Gem Collect | Purple crystals burst | 0.5s |
| Shield Active | Blue sphere shimmer | Looping |
| Shield Break | Blue shatter particles | 0.5s |
| Magnet Active | Yellow attraction lines | Looping |
| Death | Red flash + ragdoll | 1s |
| Speed Lines | White streaks on screen edge | Looping |
| Dust Trail | Beige puffs at feet | Looping |

---

## UI Art Style

### Buttons
- Rounded rectangles (radius: 12px)
- Orange gradient (#FF6F00 → #FF8F00)
- White text with subtle drop shadow
- Press state: Scale down 95% + darken 10%

### Cards
- White background, rounded corners
- Subtle shadow (2dp elevation)
- City thumbnail fills 60% of card height

### Icons
- Flat design with 2px outline
- Consistent 64×64 or 128×128 size
- Coin: Gold circle with ₹ symbol
- Gem: Purple diamond shape

---

## Performance Targets

| Asset Type | Mobile Budget |
|-----------|--------------|
| Draw Calls | < 100 per frame |
| Triangles | < 100K on screen |
| Textures in VRAM | < 150MB |
| Audio in memory | < 30MB |
| Particle Systems | < 5 active |
| Materials | < 30 unique |

### Optimization Techniques
- GPU Instancing for repeated objects (coins, obstacles)
- LOD Groups for side decorations
- Texture Atlasing for UI (one atlas per screen)
- Sprite Atlasing for 2D elements
- Occlusion Culling for environment
- Baked lighting (no realtime shadows on low quality)

---

## Shader Recommendations (URP)

| Use Case | Shader |
|----------|--------|
| Characters | URP/Lit (simple) |
| Road | URP/Lit or Custom unlit |
| Obstacles | URP/Simple Lit |
| Coins/Gems | Custom toon + rim light |
| Background | URP/Unlit (distant objects) |
| VFX | URP/Particles/Unlit |
| Skybox | Custom gradient or Procedural |
