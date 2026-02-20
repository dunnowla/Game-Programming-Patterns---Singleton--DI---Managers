using Godot;
using System;

public partial class GameManager : Node
{	
	private string savePath = "user://highscore.txt";

	public override void _Ready()
	{
		if(LoadScore() <= 0){SaveScore(10.0f);}
	}
	public void SaveScore(float newScore)
	{
		float shortScore = Mathf.Round(newScore*1000f)/1000f;
		using var file = FileAccess.Open(savePath,FileAccess.ModeFlags.Write);
		file.StoreString(GD.VarToStr(shortScore));
	}
	public float LoadScore()
	{
		if(!FileAccess.FileExists(savePath)){ GD.Print("fucekr");return 0.0f;}

		using var file = FileAccess.Open(savePath,FileAccess.ModeFlags.Read);

		return (float)GD.StrToVar(file.GetAsText()); 
	}

	public void ClearScore()
	{
		SaveScore(10.0f);
	}

	public void ExitGame()
	{
		GetTree().Quit(); 
	}
}
