# HoverCar Association #

# Summary
* Developed in three weeks
* Unity 2018.2.10f
* C#
* 2 player local co-op with splitscreen
* Cars are hovering using raycasts


## Introduction ##
<p align="Justify">
HoverCar Association is a 3D sports game inspired by - my favourite car football game - Rocket league. It is a solo side project made in three weeks with Unity and C#. It was first used for experimentation of Unity's tools including scripting, physics, local multiplayer, importing 3D objects, UI, Text animation, Main and Pause menus and sound.
</p>

## Gameplay video ##

[![Raycast](http://img.youtube.com/vi/dJGiz-4q9ys/0.jpg)](http://www.youtube.com/watch?v=dJGiz-4q9ys&ab_channel=ChristomanosAnastasiou)

## Gameplay mechanics ##



### Car handling ###

<p align="Justify">
The most challenging part of the implementation was the car handling. I started by downloading Unity's Standard assets that included a car. The default car settings were set up to create a more realistic experience including a long list of variables that affected the car physics. Since Rocket league is more arcadey, it is very important for the player to maintain control of the car at all times, therefore a realistic car that would spin around at each turn would make the gameplay experience more frustrating. So in pursuit of making the car handling feel more arcadey, I made the practical choice of removing the default wheels altogether and just hover the cars above the ground. With this method I am able to control the car's velocity and torque. 
</p>

<p align="Justify">
To achieve this, I am performing a ground check through raycasting. Four rays that point towards the ground replace the wheels. To keep the cars above the ground, an upward force is applied separately at each corner of the car. Each force is applied when the ground check returns true.
</p>
  
  
![ScreenShot](https://github.com/hristomanos/HoverCarAssociation/blob/master/HoverCar2.png)

#### Acceleration and turning ####

<p align="Justify">
To accelerate the car, we can add a certain force to the car's rigidbody. To do this, we will need a vector to dictate direction and a float value to determine the speed. The product of those two returns the car's velocity. 
</p>

```C#
m_rigidBody.AddForce(transform.forward * m_speed);
```

<p align="Justify">
To turn the car, a similar method to AddForce() is applied. This time, the force adds torque to the car's rigidbody. AddTorque() works by rotating the car around its Y axis, thus changing its direction. 
</p>
  
```C#
m_rigidBody.AddTorque(Vector3.up * m_turnStrength);
```

#### Jumping ####

Players are able to jump with a push of a button. An upward force is applied to the car's rigidbody once, making it jump in the air.

```C#
m_rigidBody.AddForce(0, upForce, 0, ForceMode.Impulse);
```

#### Input ####

<p align="Justify">
Player input is processed by invoking Unity's function Input.GetAxis() which returns a value of the virtual axis. The returned value is in the range -1...+1 reqardless of frame frequency. This means that when no button has been pressed, the function returns 0.0f and when the "move forward/backward" button has been pressed, the function returns 1.0f/-1.0f respectively. Once we know which button was pressed, we can multiply it by the velocity to make the hoverring car move based on the player's input.
</p>
  
```c#
m_rigidBody.AddForce(transform.forward * m_currentThrust);
```

#### Boost ####
<p align="Justify">
Rocket league uses orbs that fill the cars' boost tank and are placed close to the edges and corners of the pitch. The extra boost adds a tool that can be utlilised by players to chase or shoot the ball with more power. HoverCar association also uses orbs that when touched, enables players to go faster for a short amount of time with the press of a button.
</p>

<p align="Justify">
To implement this, a BoostManager script has been created. The script is responsible for deactivating and reactivating the orbs when colliding with the car in question and handling the car's boost tank by decreasing it by one after each frame that is activated. The script also updates the UI text indicating the boost gauge.
</p>

<p align="Justify">
As a result, the car movement is manipulated by the player's input, the physics engine and the boost manager.
</p>

```c#
m_rigidBody.AddForce(transform.forward * m_currentThrust * m_boost);
```

![ScreenShot](https://github.com/hristomanos/HoverCarAssociation/blob/master/orb.png)

## Game modes ##
<p align="Justify">
The game consists of two game modes: 1 or 2 players. 

### 1 Player ###
The 1 player mode is similar to free trainning where the player can practice the game's controls in a safe environemnt.

### 2 Players ###
The 2 players mode is a local competitive multiplayer using a splitscreen. Both players handle their cars using the keyboard and are trying to score as many goals as they can.

#### Splitscreen ####

 Unity's virtual cameras contain a property that defines the size and position of their viewport rectangle. The viewport is in rendering-device-specific coordinates i.e. pixels in screen-space coordinates and is used to limit the area that is currently being rendered on screen. I was fascinated with how quickly I was able to make a two player game mode.

### Controllers ###
Managers and controllers are empty game objects that are responsible for handling aspects of the game that are not tied to a specific game object and are persistent throught the game. These cases may include playing audio, changing scenes, keeping the player's state and rendering the UI.
  
In HoverCar Association, managers deal with the following cases:
  
  * Changing scenes from the main menu to either of the two game modes
  * Counting down before the start of the game and updating the UI
  * Keeping score and updating the UI
  * Resetting the ball and player positions when a goal has been scored
  * Detecting if a goal was scored
  * Handling player boost
  
