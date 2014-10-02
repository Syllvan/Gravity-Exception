using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerControls : MonoBehaviour 
{
	private Player character;
	private bool jump;
	
	
	void Awake()
	{
		character = GetComponent<Player>();
	}
	
	void Update ()
	{
		if (Input.GetButtonDown("Jump")) jump = true;
		//swap = Input.GetButtonDown ("Fire1");
	}
	
	void FixedUpdate()
	{
		// Read the inputs.
		float h = Input.GetAxis("Horizontal");
		//if (Input.GetButtonDown("Jump")) jump = true;
		 

		// Pass all parameters to the character control script.
		character.Move( h, jump );

		// Reset the jump input once it has been used.
		jump = false;
	}
}
