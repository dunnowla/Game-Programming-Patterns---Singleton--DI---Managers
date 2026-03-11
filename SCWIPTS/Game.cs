using Godot;
using System;

public partial class Game : Node3D, ManagedScene
{
	[Export] public Label timerText;
	private float timer = 10;
	int stops = 0;
	private SceneManager sceneManager;
	public void Setup(SceneManager manager)
	{
		sceneManager = manager;
	}
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
			sceneManager.LoadScene(0);
		}
		if(timer <= 0)
		{
			sceneManager.LoadScene(0);
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
