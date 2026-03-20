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
		UpdateScore(); // Updates the score when the menu loads
	}
	public override void _Process(double delta)
	{
		highScoreText.Text = "Highscore: " + highScore; // Prints the current highscore
	}
	// Gets the highscore
	void UpdateScore()
	{
		var gameManager = GetNode<GameManager>("/root/GameManager");
		highScore = gameManager.LoadScore();
	}
	// Loads the options scene
	public void Options()
	{
		sceneManager.LoadScene(2);
	}
	// Loads the game scene
	public void Play()
	{
		sceneManager.LoadScene(1);
	} 
	// Closes the application
	public void Exit()
	{
		var gameManager = GetNode<GameManager>("/root/GameManager");
		gameManager.ExitGame();
	}
}
