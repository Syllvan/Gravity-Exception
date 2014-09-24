using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerControls : MonoBehaviour 
{
	private Player character;
	private bool jump, swap;
	
	
	void Awake()
	{
		character = GetComponent<Player>();
	}
	
	void Update ()
	{
		jump = Input.GetButtonDown ("Jump");
		swap = Input.GetButtonDown ("Fire1");
	}
	
	void FixedUpdate()
	{
		// Read the inputs.
		bool crouch = Input.GetKey(KeyCode.LeftControl);
		float h = Input.GetAxis("Horizontal");
		//if (Input.GetButtonDown("Jump")) jump = true;
		 

		// Pass all parameters to the character control script.
		character.Move( h, crouch , jump );

		// Swap gravity
		if (swap) character.SwapGravity ();
		
		// Reset the jump input once it has been used.
		jump = false;
	}
}
