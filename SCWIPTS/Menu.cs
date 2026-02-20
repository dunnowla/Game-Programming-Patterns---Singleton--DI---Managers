using Godot;
using System;

public partial class Menu : Node3D
{
	[Export] public Label highScoreText;
	float highScore;
	public override void _Ready()
	{
		UpdateScore();
	}
	public override void _Process(double delta)
	{
		highScoreText.Text = "Highscore: " + highScore;
	}
	void UpdateScore()
	{
		var gameManager = GetNode<GameManager>("/root/GameManager");
		highScore = gameManager.LoadScore();
	}
	public void Options()
	{
		var scenemanager = GetNode<SceneManager>("/root/SceneManager");
		scenemanager.LoadScene("Options");
	}

	public void Play()
	{
		var scenemanager = GetNode<SceneManager>("/root/SceneManager");
		scenemanager.LoadScene("Game");
	} 

	public void Exit()
	{
		var gameManager = GetNode<GameManager>("/root/GameManager");
		gameManager.ExitGame();
	}
}
