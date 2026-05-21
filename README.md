# 🦈 Hungry Shark 3D - Unity Game

Повнофункціональна 3D гра в стилі Hungry Shark на Unity + C#

## 🎮 Геймплей
- Керуй акулою під водою
- Їж рибу (+10 очок), крабів (+50 очок)
- Уникай фугу (-50 HP) та мін (-50 HP)
- Набирай високий рекорд!

## 🎯 Керування
- **WASD** або **Стрілки** - рух
- **Shift** - прискорення

## 📁 Структура проєкту
```
Assets/
├── Scripts/
│   ├── Player/ (SharkController, SharkAnimator)
│   ├── GameManager/ (GameManager, ScoreManager, UIManager, SpawnerManager)
│   ├── Enemies/ (FishAI, CrabAI, PufferfishAI, MineAI, Food)
│   ├── Camera/ (CameraFollower)
│   ├── Audio/ (AudioManager)
│   └── Environment/ (WaterEffect)
├── Prefabs/ (Shark, Fish, Crab, Pufferfish, Mine)
└── Scenes/ (MainGame.unity)
```

## ⚙️ Встановлення
1. Клонуй репозиторій
2. Відкрий папку в Unity 2021+
3. Завантаж Scenes/MainGame.unity
4. Натисни Play! 🚀

## 📊 Особливості
✅ Повна 3D графіка
✅ AI для ворогів
✅ Система HP
✅ High Score система
✅ Звукові ефекти
✅ Анімації
✅ Меню Start/Restart
✅ Підводні ефекти

---
**Автор:** Copilot
**Версія:** 1.0
