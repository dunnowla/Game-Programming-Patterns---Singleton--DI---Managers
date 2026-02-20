using Godot;
using System;

public partial class Game : Node3D
{
	[Export] public Label timerText;
	private float timer = 10;
	int stops = 0;


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		timerText.Text = "Timer: " + timer.ToString();
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
		if(stops > 0)
		{
			scoreCalc();
			var scenemanager = GetNode<SceneManager>("/root/SceneManager");
			scenemanager.LoadScene("Menu");
		}
		if(timer <= 0)
		{
			var scenemanager = GetNode<SceneManager>("/root/SceneManager");
			scenemanager.LoadScene("Menu");
		}
	}

	public void scoreCalc()
	{
		var gameManager = GetNode<GameManager>("/root/GameManager");
		if(timer < gameManager.LoadScore())
		{
			gameManager.SaveScore(timer);
		}
	}
}
