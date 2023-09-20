# Turn-Based Combat System
> A general overview of how the turn-based combat system will work. Player Info given to give a better idea.


### Combat Algorithm:

** if player_speed > enemy_speed: **  
	Player is given options/controls first.  
	Enemy decided what to do after (attack, items/heal, escape, etc.).  

** if enemy_speed > player_speed: **  
	Enemy determines what to do in turn first(attack, heal, etc.).  
	Player is given option/controls after the enemy performs their action.  


### Player Options:  
- Attack  
- Use Item/Heal  
- Run away from battle  
- Equip Weapon (mid combat, or when not in combat?)  

*Not an exhaustive list, may add more as development progresses.*  


### Player Stats:
- HP: Health points
- Skill: Used for chance to hit enemy, and potential critical hit
- Luck: Used for Chance to hit, dogdge, run away (Suggested by Whitney Pulliam)
- Strength: raw attack power (influenced by weapon held)
- Speed: used to determine who attacks first in a battle
- Defense: used to reduce attack damage from enemy
- Mana: similar to stamina, used so player cannot abuse powerful attacks (suggested by Denny Dao)

All base 10, can choose boon and bane to start with a higher stat (boon), but lower the other (bane). 

Player Stats influenced by weapons and armor equipped:  
	- Sword: balanced  
	- Warhammer: high atk, mod def, low speed  
	- Helmet: low atk, high def, mod speed  
	- Staff: mod atk, low def, high speed, restore HP  

Player Stats influenced by either High Card / Lowcard System:

	** Blessings: **
	- FL 1:  (+) DEF
	- FL 2:  (+) SPD
	- FL 3:  (+) ATK
	- FL 4:  (+) CRIT RATE
	- FL 5:  (+) HEALTH

	** Curses: **
	- FL 1: (-) DEF
	- FL 2: (-) SPD
	- FL 3:  (-) ATK
	- FL 4: (-) CRIT RATE
	- FL 5: (-) HEALTH


### Enemy Stats & Options:
*covered in Enemy A.I.*

