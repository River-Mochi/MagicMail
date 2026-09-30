# Magic Mail [MM]

Magic Mail helps Cities: Skylines II's postal system recover from common mail problems and gives you simple controls for postal capacity.

## Features

- **Vanilla Assist** for persistent low Local Mail at post offices.
- **Vanilla Assist** for persistent low Unsorted Mail at dedicated sorting facilities.
- Optional overflow cleanup using **Local + Unsorted + Outgoing Mail**.
- Adjustable post-van payload and fleet size.
- Adjustable post-truck fleet size.
- Adjustable sorting speed and storage for **dedicated sorting facilities**.
- Read-only postal stats in **Options > Magic Mail > Status**.
- One-click **Recommended** preset or **Game defaults** reset.

Everything is optional. You can use only the capacity controls and leave all rescue features off.

## Vanilla Assist

Magic Mail now lets the game's normal mail transfers try first.

A rescue only happens when a shortage stays low across several Magic Mail checks. This avoids immediately replacing normal postal logistics.

### Post offices

**Rescue low local mail** can add a small amount of Local Mail when a regular post office stays very low.

This also applies to a post office with a sorting upgrade, such as **Westmont Tower** with its sorting upgrade.

### Dedicated sorting facilities

**Rescue low unsorted mail** can add a small amount of Unsorted Mail when a dedicated sorting facility stays very low.

### Mail overflow

**Rescue mail overflow** checks the total stored:

- Local Mail
- Unsorted Mail
- Outgoing Mail

If total storage goes above your selected threshold, Magic Mail trims it back down proportionally.

## Capacity controls

With **Change capacities** enabled you can adjust:

- Post van mail load
- Post van fleet size
- Post truck fleet size

Dedicated sorting facilities also have controls for:

- Sorting speed
- Sorting storage capacity

`100%` is the game's normal value.

Sorting speed and storage sliders do **not** change a post office's sorting upgrade.

## Status

The **Status** tab is read-only and is scanned only when you open it in Options. The city is paused while Options is open, so there is no background Status scan during normal gameplay.

It shows:

- Regular post offices, sorting-upgraded post offices, and dedicated sorting facilities
- Post-van and post-truck capacity
- Recent city-wide mail accumulated vs processed
- Rescue activity from the last Magic Mail rescue pass

**Write Report** performs one deeper diagnostic scan on demand and writes it to:

`Logs/MagicMail.log`

There is no continuous Release diagnostic logging.

## Performance

If all rescue features are off, Magic Mail's recurring rescue system is disabled. Players who use only the capacity controls do not get the recurring rescue scan.

When rescue features are enabled, Magic Mail checks postal facilities at a low frequency and intervenes only after a persistent shortage or real overflow.

## Recommended preset

**Recommended** enables Vanilla Assist with conservative rescue thresholds, sets dedicated sorting speed to **150%**, and sets post-van mail load to **200%**.

You can switch back to **Game defaults** at any time.

## Languages

16 languages are supported:

English, Français, Deutsch, Español, Italiano, Polski, Português (Brasil), Português (Portugal), 日本語, 한국어, 简体中文, 繁體中文, ไทย, Tiếng Việt, Türkçe, Українська.

## Compatibility and safety

- No Harmony patches.
- Does not patch game DLLs.
- Does not add a custom save-file structure.
- Capacity changes return to game defaults when the mod is not loaded.
- Safe to disable or unsubscribe.

## Credits

- **River-Mochi** - author
- **BugsyG** - testing
- Inspired by **Infixo's Postal Helper**

## Links

- [Paradox Mods](https://mods.paradoxplaza.com/authors/River-mochi/cities_skylines_2?games=cities_skylines_2&orderBy=desc&sortBy=best&time=alltime)
