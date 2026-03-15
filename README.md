# Brick Breaker


<img width="300" height="200" alt="Screenshot 2025-09-10 at 1 59 52 PM" src="/BrickBreaker.gif" />

Unity-based reimagining of the classic Brick Breaker / Breakout arcade game. This project was created as a learning exercise to deepen familiarity with Unity, game physics, UI systems, and general game architecture.

-------

**🕹️ Gameplay Overview**

The player controls a paddle at the bottom of the screen, bouncing a physics-driven ball to break rows of bricks at the top.

* The ball moves freely across the XY-plane and bounces based on Rigidbody physics.
* If the ball collides with the bottom “Danger Zone,” the player loses and is shown the Game Over screen.
* Destroy all bricks to win the game and activate the Win Panel.

**🎮 How to Play / Controls**

* Move Paddle: Arrow Keys / A & D
* Launch Ball: Spacebar
* Restart / Exit: ESC key

**📃 Features**

* Main Menu: Title screen with Start Game and Instructions options; instructions shown via pop-up panel.
* Paddle: Moves horizontally using player input; constrained within walls.
* Ball: Physics-based movement using Rigidbody, SphereCollider, and bouncy material; destroys bricks on impact.
* Bricks: Automatically generated grid ```(BrickManager.cs)```; each brick reports destruction through a Brick script.
* Walls: Box colliders on left, right, and top boundaries to contain gameplay.
* Danger Zone: Bottom trigger plane that detects missed balls and triggers Game Over.
* Win Panel: Activated when all bricks are destroyed, offering restart/home options.
* Game Over Panel: Activated when ball enters danger zone; allows retry or return to home screen.
