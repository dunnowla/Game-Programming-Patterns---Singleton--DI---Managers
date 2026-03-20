using Godot;
using System;

public partial class Options : Node3D, ManagedScene
{
	private SceneManager sceneManager;
	public void Setup(SceneManager manager)
	{
		sceneManager = manager;
	}
	// Clears the current highscore
	public void ClearButton()
	{
		var gameManager = GetNode<GameManager>("/root/GameManager");
		gameManager.ClearScore();
	}
	// Loads the menu scene
	public void Back()
	{
		sceneManager.LoadScene(0);
	}
}
