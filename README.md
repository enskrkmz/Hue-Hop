# Hue Hop

A color-matching vertical arcade game made with Unity 6. Tap to bounce your ball upward and pass only through the parts of each obstacle that match your current color.

**▶ Play in your browser:** [enskrkmz.itch.io/hue-hop](https://enskrkmz.itch.io/hue-hop)

![Hue Hop gameplay](screenshot.png)

## How to Play

| Action | Control |
|---|---|
| Jump | Click / Tap |

- Pass through obstacle segments that match your ball's color.
- Touch a color changer to get a new color.
- Collect stars for points.
- Reach the finish flag to move on to the next level.

## Features

- 5 handcrafted levels with a level select menu
- Rotating rings, counter-rotating mirrored double rings and spinning squares
- Animated menu transitions
- In-game menu button to return to the main menu at any time
- Volume setting saved between sessions
- Works with both mouse and touch (new Input System)

## Built With

- Unity 6 (6000.3 LTS)
- C#
- Unity Input System

## What I Learned

- Structuring a game around a **GameManager**: the ball only detects events (star, wrong color, finish line) and the GameManager decides what happens.
- Building levels from **prefabs**, so a change to the ball, camera or UI applies to every level at once.
- **Scene management** with build indexes: loading the next level, detecting the last level, retrying.
- A smooth **camera follow** with `Lerp` in `LateUpdate` that only moves upward.
- Using **mirror symmetry** to keep two counter-rotating rings aligned on the ball's path.
- **Animator** states and coroutines for UI transitions.
- Saving settings with **PlayerPrefs**.
- Migrating from the old Input Manager to the **new Input System**.
- Storing data on objects with small **components**: each ring segment keeps its own color in a tiny script that the ball reads on contact.

## Credits

- Inspired by *Color Switch*. This is a learning project and is not affiliated with the original game.
- All code and UI buttons: made by me.
- Logo, in-game sprites and music: created with AI assistance.
