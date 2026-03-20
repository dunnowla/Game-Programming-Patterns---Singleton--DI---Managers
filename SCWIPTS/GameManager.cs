using Godot;
using System;

public partial class GameManager : Node
{	
	private string savePath = "user://highscore.txt"; // Where to save the highscore

	public override void _Ready()
	{
		// If there is no saved score the highscore becomes 10
		if(LoadScore() <= 0){SaveScore(10.0f);} 
	}
	// Saves the highscore in the txt file
	public void SaveScore(float newScore)
	{
		float shortScore = Mathf.Round(newScore*1000f)/1000f;
		using var file = FileAccess.Open(savePath,FileAccess.ModeFlags.Write);
		file.StoreString(GD.VarToStr(shortScore));
	}
	// Gets the highscore if there is one
	public float LoadScore()
	{
		if(!FileAccess.FileExists(savePath)){ GD.Print("fucekr");return 0.0f;}

		using var file = FileAccess.Open(savePath,FileAccess.ModeFlags.Read);

		return (float)GD.StrToVar(file.GetAsText()); 
	}
	// Sets the score to the worst it can be	
	public void ClearScore()
	{
		SaveScore(10.0f);
	}
	// Quits the game
	public void ExitGame()
	{
		GetTree().Quit(); 
	}
}
