using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class SceneManager : Node
{
	[Export] PackedScene[] scenes;
	private Node currentScene;

	public override void _Ready()
	{
		LoadScene(0);
	}

	public void LoadScene(int index)
	{
		if(currentScene != null)
		{
			currentScene.QueueFree();
		}

		PackedScene newScene = scenes[index];
		currentScene = newScene.Instantiate();

		if(currentScene is ManagedScene managedScene)
		{
			managedScene.Setup(this);
		}

		AddChild(currentScene);
	}
}
