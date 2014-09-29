using UnityEngine;

public class Player : MonoBehaviour 
{
	bool facingRight = true;							// For determining which way the player is currently facing.
	
	[SerializeField] float maxSpeed = 10f;				// The fastest the player can travel in the x axis.
	[SerializeField] float jumpForce = 400f;			// Amount of force added when the player jumps.	

	[SerializeField] LayerMask whatIsGround;			// A mask determining what is ground to the character

	bool gravity = true;
	Transform groundCheck;								// A position marking where to check if the player is grounded.
	float groundedRadius = .2f;							// Radius of the overlap circle to determine if grounded
	bool grounded = false;								// Whether or not the player is grounded.
	Transform ceilingCheck;								// A position marking where to check for ceilings
	float ceilingRadius = .01f;							// Radius of the overlap circle to determine if the player can stand up
	float gravityScale;
	int gravityCounter = 0;								// counter to determine how many times gravitybutton has been pressed
	float noGravity_start = .0f;						// timer that records when noGravity starts
	float noGravity_current = .0f;						// timer that records surrent noGravity time
	float allowedNoGravityTime = 2f;
	//Animator anim;										// Reference to the player's animator component.
	
	
	void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("GroundCheck");
		ceilingCheck = transform.Find("CeilingCheck");
		gravityScale = rigidbody2D.gravityScale;
		//anim = GetComponent<Animator>();
	}
	
	
	void FixedUpdate()
	{
		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
		if(grounded)
			SetGravityOnOff (true);
		//anim.SetBool("Ground", grounded);
		
		// Set the vertical animation
		//anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
	}
	
	
	public void Move(float move, bool crouch, bool jump)
	{	
		//Current time is updated regularly
		noGravity_current = Time.time;

		//only control the player if grounded is turned on
		if(grounded)
		{	
			gravityCounter = 0;
			// The Speed animator parameter is set to the absolute value of the horizontal input.
			//anim.SetFloat("Speed", Mathf.Abs(move));
			
			// Move the character
			rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
			
			// If the input is moving the player right and the player is facing left...
			if(move > 0 && !facingRight)
				// ... flip the player.
				Flip();
			// Otherwise if the input is moving the player left and the player is facing right...
			else if(move < 0 && facingRight)
				// ... flip the player.
				Flip();
		}
		
		// If the player should jump...
		if (grounded && jump)
		{
			// Add a vertical force to the player.
			//anim.SetBool("Ground", false);
			rigidbody2D.AddForce (new Vector2 (0f, jumpForce));
		}
		// gravitybutton is unable to be pressed more than two times untill player hits the ground again
		else if(!grounded && jump && gravityCounter < 2)
		{
			SetGravityOnOff(!gravity);
			gravityCounter++;
			//when the gravity is set to false for the first time, start timer
			noGravity_start = Time.time;
		}
		// if gravity has been false for more than 2 seconds (allowedNoGravityTime), it is set to true
		else if(gravity == false && noGravity_current - noGravity_start > allowedNoGravityTime)
		{
			SetGravityOnOff(true);
			gravityCounter++;
		}
	}
	
	
	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void SetGravityOnOff (bool g)
	{
		gravity = g;
		rigidbody2D.gravityScale = gravity ? gravityScale : 0.0f;
	}
}
