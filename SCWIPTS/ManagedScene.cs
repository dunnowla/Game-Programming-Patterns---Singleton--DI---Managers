using Godot;
using System;

public interface ManagedScene
{
	// Makes sure all scripts that need the scenemanager uses the setup function
	void Setup(SceneManager manager);
}
