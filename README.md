# HW4
## Devlog

### EQ:
Write about how the model-view-control pattern is utilized in this project to keep the Player code decoupled from the other systems in this game. The model aspect of this game is less relevant, so you can skip describing it; however, the view and control aspects are very relevant, so you should describe which class defines the control side of this pattern, and which class defines the view side of this pattern.
Additionally, describe how events and a Singleton are used in your code to ensure the view and control aspects of your system are decoupled.
Make sure to cite your code (name specific classes, methods, and/or variables).


### ANS:
The MVC pattern is utilized in my project to help decouple player code from other systems specifically through the view and control portion. My main control avenue is the Player class serving as a central orchestrator for my event utilization. In my `Player` class it contains 3 `Action`s: 
- `Action OnJump`: Called when the player Input's a Jump press with the spacebar
- `Action OnDeath`: Called when the player collides with a `KillZone` tagged Collider2D component holding GameObject
- `Action<int> OnPass`; Called when the player passes through a `Pass` tagged Collider2D component holding GameObject

What the essential reason for doing this is to move `View` portions of the `MVC` code outside of the concrete implementations of the `Controller` portion specifications. This serves as a form of extraction and SRP to increase code understandability scoped to a script's singular funcitonality. In otherwords it de-coupled code that has little or nothing to do with eachother with the exception of initial dependancy handling.

The scripts that handle the `View` portion of the MVC pattern are:
- `AudioManager`
- `UIManager`

Since audio and UI are a form of `View` as its the player facing stuff, these two scripts hook into the `Player` and subscribe to the `Player`'s events. `AudioManager` just handles a limited amount of AudioClips corrosponding to an `enum` and `UIManager` updates the score text and handle's the Losing UI. 

The only negative doing it this way is that some amount of dependency is created, and that when using Events stack tracing becomes slightly more difficult.

To ensure decoupling while allowing for dependancies to link, I've utilized a `Locator` singleton class that inherits from my `Singleton<T>` class. Where T is the child class itself. This allows for depdnent classes to pull the dependancy in when needed without relying on manually applying the depdnancy for each object in the scene.

## Open-Source Assets
If you added any other assets, list them here!
- [Brackey's Platformer Bundle](https://brackeysgames.itch.io/brackeys-platformer-bundle) - sound effects
- [2D pixel art seagull sprites](https://elthen.itch.io/2d-pixel-art-seagull-sprites) - seagull sprites
- [Bird Sprite](https://ma9ici4n.itch.io/pixel-art-bird-16x16) 
