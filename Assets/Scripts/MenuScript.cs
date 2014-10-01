using UnityEngine;

public class MenuScript : MonoBehaviour
{
	private GUISkin skin;
	
	void Start()
	{
		// Load a skin for the buttons
		skin = Resources.Load("GUIskin") as GUISkin;
	}
	
	void OnGUI()
	{
		const int buttonWidth = 420;
		const int buttonHeight = 80;
		const int buttonMargin = 35;
		
		// Set the skin to use
		GUI.skin = skin;
		
		// Draw a button to start the game
		if (GUI.Button(
			new Rect(Screen.width / 5 - (buttonWidth / 2), (Screen.height / 2), buttonWidth, buttonHeight),
			"START"
			))
		{
			// On Click, load the first level.
			Application.LoadLevel("level1"); // "Stage1" is the scene name
		}

		if (GUI.Button(
			new Rect(Screen.width / 5 - (buttonWidth / 2), (Screen.height / 2) + buttonHeight + buttonMargin, buttonWidth, buttonHeight),
			"SETTINGS"
			))
		{
			// On Click, load the first level.
			//Application.LoadLevel("level1"); // "Stage1" is the scene name
		}

		if (GUI.Button(
			new Rect(Screen.width / 5 - (buttonWidth / 2), (Screen.height / 2) + 2*(buttonHeight + buttonMargin), buttonWidth, buttonHeight),
			"ABOUT"
			))
		{
			// On Click, load the first level.
			//Application.LoadLevel("level1"); // "Stage1" is the scene name
		}
	}
}