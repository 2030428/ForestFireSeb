# GameOfLife Seb's Version

This is my personal version with additions of the forest fire 3D game, which was released to the students of VR MSC as broken code example. Any one using this not in the university will be disappionted as its incomplete.

The first addition I made to the game was that of a health and damage system. A health bar slider has been applied to the hand model, and when the player is within the collider of an active fire cell, damage is received and represented on the slider. As damage is recieved a visual cue is applied, which is a semi translucent red sphere around the camera. Should the player's health reach zero, then the game ends and changes scene to a game over scene.

The second addition applied is a scoring system. As the player moves around the area, they can collide with blue balloons. Once this occurs, the balloon accelerates into the sky, and the player receives a score which is represented in text shown on the player hand model above the healthbar. Should the player get the maximum score, set to 100 points (10 points per balloon) then the scene changes to a game win screen.

Classes created: PlayerIsOnFire, BalloonContact, ExitGame, ScoreTally, HealthBar, TryAgain, StillInTheFire.

Classes modified: ForestFire3D - created Balloon state, added fire collider enabled/disabled for appropriate states

                  Minimap - add a representation for the balloon state cells so they show as blue on minimap
