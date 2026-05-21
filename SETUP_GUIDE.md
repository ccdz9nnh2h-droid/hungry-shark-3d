# 🎮 Інструкція по налаштуванню Hungry Shark 3D

## 1️⃣ Клонування проєкту
```bash
git clone https://github.com/ccdz9nnh2h-droid/hungry-shark-3d.git
```

## 2️⃣ Відкриття в Unity
1. Відкрий Unity Hub
2. Натисни **Open Project**
3. Вибери папку `hungry-shark-3d`
4. Чекай завантаження (потрібна Unity 2021 LTS або новіше)

## 3️⃣ Створення сцени

### Крок A: Створи нову сцену
- Right Click у папці Scenes → Create → Scene
- Назви: `MainGame`

### Крок B: Налаштуй ієрархію
```
Hierarchy:
├── GameManager (Empty GameObject)
│   ├── Add Component: GameManager.cs
│   ├── Add Component: ScoreManager.cs
│   ├── Add Component: SpawnerManager.cs
│   ├── Add Component: AudioManager.cs
│   └── Посилання на UIManager
├── Main Camera
│   ├── Add Component: CameraFollower.cs
│   └── Посилання на Shark
├── Shark (3D Capsule)
│   ├── Add Rigidbody (Body Type: Dynamic, Freeze Rotation Y,Z)
│   ├── Add Capsule Collider
│   ├── Add Component: SharkController.cs
│   ├── Add Component: SharkAnimator.cs
│   └── Add Component: Animator
├── Canvas (UI)
│   ├── Start Menu Panel
│   ├── Game HUD Panel
│   │   ├── Score Text (TextMeshPro)
│   │   ├── HP Slider
│   │   └── HP Text
│   └── Game Over Panel
├── Seabed (Plane, Scale: 100, 1, 100)
│   ├── Add Component: WaterEffect.cs
│   └── Material: Blue (для води)
└── Directional Light (Color: Light Blue)
```

## 4️⃣ Створення префабів

### Fish Prefab
1. Drag & Drop: Scene → Assets/Prefabs/
2. Додай Sphere (масштаб 1x1x1)
3. Add Component: FishAI.cs
4. Tag: "Fish"
5. Add Sphere Collider (Is Trigger: true)
6. Add Rigidbody (Is Kinematic: true)

### Crab Prefab
1. Cube (масштаб 1x0.5x1)
2. Add Component: CrabAI.cs
3. Tag: "Crab"
4. Sphere Collider (Is Trigger: true)
5. Rigidbody (Is Kinematic: true)

### Pufferfish Prefab
1. Sphere (масштаб 1.2x1.2x1.2)
2. Add Component: PufferfishAI.cs
3. Tag: "Pufferfish"
4. Collider (Is Trigger: true)
5. Rigidbody (Body Type: Dynamic)

### Mine Prefab
1. Sphere (масштаб 0.8x0.8x0.8)
2. Add Component: MineAI.cs
3. Tag: "Mine"
4. Collider (Is Trigger: true)
5. Rigidbody (Body Type: Dynamic)
6. ParticleSystem (для вибуху)

## 5️⃣ Tags налаштування
Create Tags in Inspector:
- "Player"
- "Food"
- "Danger"
- "Fish"
- "Crab"
- "Pufferfish"
- "Mine"

## 6️⃣ UI налаштування

### Start Menu
```
Panel (Name: StartMenu)
├─�� Title Text: "Hungry Shark 3D"
├── Button: "START GAME"
└── OnClick → UIManager.StartGame()
```

### Game HUD
```
Panel (Name: GameHUD)
├── Score Text: "Score: 0"
├── HP Slider (min: 0, max: 200)
└── HP Text: "HP: 200"
```

### Game Over Menu
```
Panel (Name: GameOverMenu)
├── Title: "GAME OVER"
├── Score Text
├── High Score Text
├── Button: "RESTART"
└── OnClick → GameManager.RestartGame()
```

## 7️⃣ Audio налаштування

Добавити звуки в AudioManager:
- `eatSound` - звук їжі (короткий)
- `explosionSound` - звук вибуху
- `waterLoopSound` - фонова музика води

## 8️⃣ SpawnerManager посилання

В InspectorI GameManager назначь:
- Fish Prefab
- Crab Prefab
- Pufferfish Prefab
- Mine Prefab

## 🚀 Запуск
1. Натисни **Play**
2. Натисни **START GAME**
3. Керуй: **WASD** + **Shift** для прискорення
4. Збирай їжу, уникай небезпек!
5. High Score автоматично зберігається

---

## 📊 Налаштування сложності

В SharkController змінюй:
- `moveSpeed` - базова швидкість
- `sprintSpeed` - максимальна швидкість
- `maxHP` - здоров'я акули
- `eatRadius` - радіус підбору їжі

В SpawnerManager:
- `initialFishCount` - кількість риб
- `initialCrabCount` - кількість крабів
- `initialPufferfishCount` - кількість фугу
- `initialMineCount` - кількість мін

---

Готово! Гра готова до запуску! 🦈🎮
