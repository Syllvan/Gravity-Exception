using UnityEngine;

public class MenuScript : MonoBehaviour
{
	private GUISkin skin;
	private string[] menuOptions;
	private int selectedIndex;
	
	void Start()
	{
		// Load a skin for the buttons
		skin = Resources.Load("GUIskin") as GUISkin;

		menuOptions = new string[4];
		menuOptions[0] = "Start";
		menuOptions[1] = "Settings";
		menuOptions[2] = "About";
		menuOptions[3] = "Exit";
	
		selectedIndex = 0;
	}

	// Function to scroll through possible menu items array, looping back to start/end depending on direction of movement.
	int menuSelection (string[] menuItems, int selectedItem, string direction)
	{
		if (direction == "up") {
			if (selectedItem == 0) {
				selectedItem = menuItems.Length - 1;
			} else {
				selectedItem -= 1;
			}
		}
		
		if (direction == "down") {
			if (selectedItem == menuItems.Length - 1) {
				selectedItem = 0;
			} else {
				selectedItem += 1;
			}
		}
		
		return selectedItem;
	}

	void Update ()
	{
		if(Input.GetKeyDown("down")) {
			selectedIndex = menuSelection(menuOptions, selectedIndex, "down");
		}
		
		if(Input.GetKeyDown("up")) {
			selectedIndex = menuSelection(menuOptions, selectedIndex, "up");
		}
	}

	void OnGUI ()
	{
		int buttonWidth = (int)(Screen.height*0.5f);
		int buttonHeight = (int)(Screen.height*0.1f);
		int buttonMargin = (int)(Screen.height*0.04f);
		int startHeight = (int)(Screen.height * 0.4f);
		int startWidth = (int)(Screen.width * 0.2f);
		
		// Set the skin to use
		GUI.skin = skin;
		skin.button.fontSize = (int)(buttonHeight*0.6f);
		
		// Draw a button to start the game
		GUI.SetNextControlName ("Start");
		if (GUI.Button(
			new Rect(startWidth - buttonWidth/2, startHeight, buttonWidth, buttonHeight),
			"START"
			))
		{
			// On Click, load the first level.
			Application.LoadLevel("level1"); // "Stage1" is the scene name
		}

		GUI.SetNextControlName ("Settings");
		if (GUI.Button(
			new Rect(startWidth - buttonWidth/2, startHeight + buttonHeight + buttonMargin, buttonWidth, buttonHeight),
			"SETTINGS"
			))
		{

		}

		GUI.SetNextControlName ("About");
		if (GUI.Button(
			new Rect(startWidth - buttonWidth/2, startHeight + 2*(buttonHeight + buttonMargin), buttonWidth, buttonHeight),
			"ABOUT"
			))
		{

		}

		GUI.SetNextControlName ("Exit");
		if (GUI.Button(
			new Rect(startWidth - buttonWidth/2, startHeight + 3*(buttonHeight + buttonMargin), buttonWidth, buttonHeight),
			"Exit"
			))
		{
			
		}

		
		GUI.FocusControl (menuOptions[selectedIndex]);
	}
}

/*using UnityEngine;

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
*/