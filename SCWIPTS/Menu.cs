using Godot;
using System;

public partial class Menu : Node3D, ManagedScene
{
	[Export] public Label highScoreText;
	float highScore;

	private SceneManager sceneManager;
	public void Setup(SceneManager manager)
	{
		sceneManager = manager;
	}
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
		sceneManager.LoadScene(2);
	}

	public void Play()
	{
		sceneManager.LoadScene(1);
	} 

	public void Exit()
	{
		var gameManager = GetNode<GameManager>("/root/GameManager");
		gameManager.ExitGame();
	}
}
