using Godot;
using System;

public partial class Game : Node3D, ManagedScene
{
	[Export] public Label timerText;
	private float timer = 10;
	int stops = 0;
	private SceneManager sceneManager;
	// Tells the script to use the scenemanager
	public void Setup(SceneManager manager)
	{
		sceneManager = manager;
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		timerText.Text = "Timer: " + timer.ToString(); // Updates the text
		// Starts the countdown
		if(stops == 0)
		{
			timer -= (float)delta;
		}
		// Stops the countdown 
		if(Input.IsKeyPressed(Key.Space))
		{
			stops += 1;
		}
		// Runs the menu scene when u stop the timer
		// Updates score if neccessary
		if(stops > 0)
		{
			scoreCalc();
			sceneManager.LoadScene(0);
		}
		// Loads the menu scene if the timer runs out
		if(timer <= 0)
		{
			sceneManager.LoadScene(0);
		}
	}

	public void scoreCalc()
	{
		// Saves the score if the score is smaller than the current "highscore"
		var gameManager = GetNode<GameManager>("/root/GameManager");
		if(timer < gameManager.LoadScore())
		{
			gameManager.SaveScore(timer);
		}
	}
}
