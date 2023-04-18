# space-co-op
This project represents a Unity game of 2 spaceships that co-opporate to destroy their ememies and survive..
![Alt text](Assets/Screenshots/ScreenShot%20Main.png)
# Play

# Features
## Diveresed Enemies
There are currently two types of confrontations, enemies' spaceships and meteors.

Meteros - come from unexpected directions and relatively slow.

Enemies' Spaceships - faster than the meteors, which makes them more dangerous but more rewarding.

code:
My approach for enabling this behavior to be generic as possible, the enemy's objects will contain the component [EnemyDestroyOnTrigger2D](Assets/Scripts/3-collisions/EnemyDestroyOnTrigger2D.cs) that will provide each enemy object unique score attached to him, used by [ScoreAdder](Assets/Scripts/3-collisions/ScoreAdder.cs).
To keep the speed - score ratio, the enemy's velocity will be calculated relatively to the enemy score in [TimedSpawnerRandom](Assets/Scripts/2-spawners/TimedSpawnerRandom.cs), also providing SerializeField for list of enemies, to make it easier to add different types of enemies with different score.

## Score
Both players contribute to the shared score.

## The Players
***In any good fight, partnership is the key to victory!!***

This game features two types of spaceship heros to choose from, as each one of them has their own unique ability.



### The Support
By hovering over his ally, he has the ability to cast shield on his ally for 5 seconds.

[ShieldThePlayer](Assets/Scripts/3-collisions/ShieldThePlayer.cs) is a component in the support object, which Triggered on collison with the other player, recieving two other components, [ShieldActivation](Assets/Scripts/3-collisions/shieldActivation.cs) for setting shield state, and the [CircleAnimation](Assets/IrregularCircleUI/Scripts/CircleAnimation.cs) for displaying the shield on the player.

The support player have indication time animation for the ability cooldown, switching on colors red/green based on the cooldown state [CircleAnim](https://github.com/barakdf/space-co-op/blob/cee9295eaaf48a1fc725319ca9c23af8ba3a458e/Assets/ProudLlama/Circle%20Generator/Demo/CircleAnim.cs) . 

Skill cooldown: 20 seconds.

### The Damage Dealer

By pressing Right Control, the damage dealer player will activate his special offence ability, each fire press he will shoot 3 lasers in a fan shape for 5 seconds.
![Alt text](Assets/Screenshots/Screenshot%20Laser.png)
[UltimateLaser](Assets/Scripts/3-collisions/UltimateLaser.cs) is a component that recieves duration, [IndicationTimer](Assets/ProudLlama/Circle%20Generator/Demo/CircleAnim.cs) and input button for casting the special ability.
Activating the special ability is handled in [LaserShooter](Assets/Scripts/2-spawners/LaserShooter.cs).

Skill cooldown: 20 seconds.

# Game Controls
The controls for the game are as follows:

**Support Player**

- W: Move the Player upwards
- A: Move the Player to the left
- S: Move the Player downwards
- D: Move the Player to the right

**Damage Player**

- Arrow UP: Move the Player upwards
- Arrow LEFT: Move the Player to the left
- Arrow DOWN: Move the Player downwards
- Arrow Right: Move the Player to the right
- L: Enable Ability

# Assets
[Meteors](https://assetstore.unity.com/packages/2d/gui/icons/hand-painted-icons-102396)

[Shield Animation](https://assetstore.unity.com/packages/tools/gui/irregular-circle-ui-animation-163132)

[Cooldown Indicator](https://assetstore.unity.com/packages/tools/gui/circle-generator-213175)

