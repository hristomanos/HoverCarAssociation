# HoverCar Association #

## Introduction ##
HoverCar Association is a 3D sports game inspired by - my favourite car football game - Rocket league. It is a solo side project made in three weeks with Unity and C#. It was first used for experimentation of Unity's tools including scripting, physics, local multiplayer, importing 3D objects, UI, Text animation, Main and Pause menus and sound.


## Demo clip ##

https://youtu.be/dJGiz-4q9ys

## Contents ##

* Gameplay mechanics
* Game Modes
* What I learned

## Gameplay mechanics ##

### Car handling ###
The most challenging part of the implementation was the car handling. I started by downloading Unity's Standard assets that included a car. The default car settings were set up to create a more realistic experience including a long list of variables that affected the car physics. Since Rocket league is more arcadey, it is very important for the player to maintain control of the car at all times, therefore a realistic car that would spin around at each turn would make the gameplay experience more frustrating. So in pursuit of making the car handling feel more arcadey, I made the practical choice of removing the default wheels altogether and just hover the cars above the ground. With this method I am able to control the car's velocity and torque. 

To achieve this, I am performing a ground check through raycasting. Four rays that point towards the ground replace the wheels. To keep the cars above the ground, an upward force is applied separately at each corner of the car. Each force is applied when the ground check returns true.

Torque and velocity




## Game modes ##
The game consists of two game modes: 1 or 2 players.
The 2 players mode is a local competitive multiplayer using a splitscreen. Both players handle their cars using the keyboard and are trying to score as many goals as they can to the opposing team before the time runs out.

### What Did I learn? ###
