# Creating Player Movement
To start, create a platform for the player to walk on. To add a game object to the scene, either right-click or click the plus icon in the hierarchy window and select 3D object -> cube. Name this cube "Floor". 

![Hierarchy](Images\Hierarchy.png)

Next, we'll increase the size of the cube to give our player more room to move around. If an object or asset is selected, the inspector window will display all of its properties. At the top of the inspector, there is a component labeled Transform. Set the x axis value for scale to be 25.  

![Scale](Images\Scale.png)

Now that we have a platform, we can add our player to the scene. Create another cube, this time name it "Player". Set the y value for position in the inspector to be 1 so that our player doesn't spawn in the floor.

![Position](Images\Position.png)

For our movement, we're going to want our player to be able to run, jump, and be affected by other objects in the scene. In order to do all of these things, we'll need our player to have physics. To give an object physics, we'll need to attach a Rigidbody. To add a component to a game object, select the "Add Component" button in the bottom of the inspector. We can then search for the component we want to add. Search for "Rigidbody" and select it to add the component to our player.

![Rigidbody](Images\Rigidbody.png)

To test things out, place the player a bit higher in the scene and press the play button. You should see that our player now has gravity!

![Gravity](Images\Gravity.gif)

Now that we have physics, we can create a script that can move our player by adding forces. First, create a folder to hold all of our scripts by right clicking in the project window and selecting Create -> Folder. You can name this folder "Scripts". In the Scripts folder, right-click and create a new C# script by selecting Create -> C# Script. Double-click the script to open it in Visual Studio and add the following code:

![Movement](Images\Movement.png)

This code contains a variable called "_rigidBody" which will store the physics component. Note that the variable has the word "private" in front of it. A private variable can only be used only in the script it's created in, while a public variable can be used anywhere. Public variables can be seen in the inpector of the object the script is attached to. This will be useful for other variables later on. The "Start" function is called when the game object is placed in the scene. We'll use this function to make our "_rigidBody" variable store the Rigidbody component we added earlier. We can use this to add a force to the player every frame. For now, we'll just add a force to the right. For reasons outside the scope of this tutorial, we'll have to change our "Update" function to be a "FixedUpdate" function to ensure our physics works correctly. Back in Unity, attach the movement script to the player in the same way you added the Rigidbody component earlier. If you play the game now, you'll see our player being pushed to the right with a lot of force.

![BadMovement](Images\BadMovement.gif)

![Movement1](Images\Movement1.png)

We can address this weird movement by making some changes to our script. First, a new variable is created that can control the acceleration of the character called "Acceleration". The variable can then be multiplied by the direction of movement to set how quickly the player moves in that direction. This value is then multiplied by "Time.fixedDeltaTime" to make the movement smoother. A variable is also created to set a max speed. If the player exceeds the max speed, their speed is reduced to be the max speed.

Back in the editor, set the acceleration and max speed to be what feels right. For this example my acceleration will be set to 30 while my max speed will be set to 60. Play the game again, and you should that the movement is smoother, but our player is still rolling. 

![SmoothBadMovement](Images\SmoothBadMovement.gif)

To prevent our player from rotating, we can lock its rotation in the Rigidbody component in the player's inspector. Expand the "Contraints" section, and check freeze rotation on the x, y and z axis. 

![Constraints](Images\Constraints.png)

![SmoothMovement](Images\SmoothMovement.gif)


# Adding Movement Input

Our movement is working as intended, but our player has no way of controlling the cube's movement. Acceleration and speed is already handled in code, so we'll just need to add a way for our player to decide which direction to move in. 

![MoveDirection](Images\MoveDirection.png)

In the code above, a new variable is added to store the current direction of movement. That variable will be set in the "SetMoveDirection" function. Note that the "public" keyword is before the function. By default, things in C# are set to private. Having the function set to public allows the move direction to be set by the script for input. Speaking of, create a new script in Unity called "InputBehaviour" and add the following code: 

![InputScript1](Images\InputScript1.png)

The variable "_playerMovement" stores the player movement component. This is so that we can easily update the move direction. In the "Update" function, the direction the player's character should move in is set to be the direction of the current value of the "Horizontal" input axis. By default, the keys bound to this axis are A or the left arrow to move left, and D or the right arrow to move right. Add the component to the player object in Unity, and you will be able to make your player move left and right.

# Adding Jumping

Our game of tag would be over pretty quick if we were only able to move in one dimension. In the current state of the game it would be impossible to avoid the tagger. We can make things more interesting by adding some verticality to our game. To do this we'll have to update the movement script with the following code:

![Jump1](Images\Jump1.png)

Here we've added a new variable to control how much force is exerted on our player when they jump. This force will only be added if the "Jump" function called. The force mode for the jump will be an impulse force. An impulse force adds an instant force to the character using its mass.

Now that the player character has the ability to jump, it's time to set up the input for activating the jump. Unlike movement there isn't a default input axis set up for jumping. Instead, we can simply add a check to see if the "W" key was pressed like so

![Jump2](Images\Jump2.png)

Back in the Unity editor, change the jump power to be something that feels right for your game. For this example I'll set mine to 14. Play the scene, and your player will now be able to jump using the "W" key. The only problem is that or player can jump infinitely.

![BadJump](Images\BadJump.gif)

To fix this, we need a way to check to see if our player is on the ground before they jump. There's several ways to check to see if a character is grounded. The common method that we will use is to create a collider to check if the character is colliding with the floor. Add a new cube to our player object. Set the cube's position on the y axis to be -0.1. We want the collider to barely stick out from under the player so that they aren't allowed to jump until they are close to the ground. 

We only need this object to check if we are on the ground, so we'll need to modify its components. First, disable the "MeshRenderer" component so we aren't able to see the ground collider. You can disable it by clicking the check box in the top left of the component in the inspector window. 

![MeshRenderer](Images\MeshRenderer.png)

The ground collider shouldn't have solid collision. If it did it would look like our player is floating. To remove the solid collision, check the "Is Trigger" checkbox in the Box Collider component.

![BoxCollider](Images\BoxCollider.png)














