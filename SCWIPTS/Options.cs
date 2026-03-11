using Godot;
using System;

public partial class Options : Node3D, ManagedScene
{
	private SceneManager sceneManager;
	public void Setup(SceneManager manager)
	{
		sceneManager = manager;
	}
	public void ClearButton()
	{
		var gameManager = GetNode<GameManager>("/root/GameManager");
		gameManager.ClearScore();
	}

	public void Back()
	{
		sceneManager.LoadScene(0);
	}
}
