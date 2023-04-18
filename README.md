# space-co-op
This project represents a Unity game of 2 spaceships that co-opporate to destroy their ememies and survive.

# Play

# Features
## Diveresed Enemies
There are currently two types of confrontations, enemies' spaceships and meteors.

Meteros - come from unexpected directions and relatively slow.

Enemies' Spaceships - faster than the meteors, which makes them more dangerous but more rewarding.

code:
My approach for enabling this behavior to be generic as possible, the enemy's objects will contain the component &&, heir from && that will provide each enemy object unique score attached to him, used by &(score adder).
To keep the speed - score ratio, the enemy's velocity will be calculated relatively to the enemy score in &(TimedSpawnerRandom), also providing SerializeField for list of enemies, to make it easier to add different types of enemies with different score.

## Score
Both players contribute to the shared score.

## The Players
In every good battle, partership is the key to victory!

This game features two types of spaceship heros to choose from, as each one of them has their own unique ability.



### The Support
By hovering over his ally, he has the ability to cast shield on his ally for 5 seconds.

code:
&(ShieldThePlayer) is a component in the support object, which Triggered on collison with the other player, recieving two other components, &(ShieldActivation) for setting shield state, and the &(CircleAnimation) for displaying the shield on the player.

The support player have indication time animation for the ability cooldown, switching on colors red/green based on the cooldown state &(CircleAnim). 

Skill cooldown: 20 seconds.

### The Damage Dealer



