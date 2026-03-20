using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class SceneManager : Node
{
	[Export] PackedScene[] scenes; // Array of all the scenes
	private Node currentScene;

	public override void _Ready()
	{
		LoadScene(0); // Loads the menu scene
	}

	public void LoadScene(int index)
	{
		if(currentScene != null)
		{
			currentScene.QueueFree(); // Deletes the current scene before loading the next one
		}

		PackedScene newScene = scenes[index]; // Gets the scene to spawn
		currentScene = newScene.Instantiate(); // Spawns the scene

		if(currentScene is ManagedScene managedScene)
		{
			managedScene.Setup(this); // calls the setup function in the current scene
		}

		AddChild(currentScene); // Makinf the scene a child to the scene mangaer
	}
}
