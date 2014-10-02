using UnityEngine;
using System.Collections;

public class Minion : MonoBehaviour
{
	public float moveSpeed = 2f;		// The speed the enemy moves at.
	//public int HP = 2;					// How many times the enemy can be hit before it dies.
	//public Sprite deadEnemy;			// A sprite of the enemy when it's dead.
	//public Sprite damagedEnemy;			// An optional sprite of the enemy when it's damaged.
	//public AudioClip[] deathClips;		// An array of audioclips that can play when the enemy dies.
	//public GameObject hundredPointsUI;	// A prefab of 100 that appears when the enemy dies.
	//public float deathSpinMin = -100f;			// A value to give the minimum amount of Torque when dying
	//public float deathSpinMax = 100f;			// A value to give the maximum amount of Torque when dying
	
	
	private SpriteRenderer ren;			// Reference to the sprite renderer.
	private Transform frontCheck;		// Reference to the position of the gameobject used for checking if something is in front.
	//private bool dead = false;			// Whether or not the enemy is dead.
	//private Score score;				// Reference to the Score script.
	
	
	void Awake()
	{
		// Setting up the references.
		ren = transform.Find("MinionBody").GetComponent<SpriteRenderer>();
		frontCheck = transform.Find("frontCheck").transform;
		//score = GameObject.Find("Score").GetComponent<Score>();
	}
	
	void FixedUpdate ()
	{
		// Create an array of all the colliders in front of the enemy.
		Collider2D[] frontHits = Physics2D.OverlapPointAll(frontCheck.position);

		// Check each of the colliders.
		foreach(Collider2D c in frontHits)
		{
			Debug.Log("hej");
			// If any of the colliders is an Obstacle...
			if(c.tag == "Obstacle")
			{
				Debug.Log("hej");
				// ... Flip the enemy and stop checking the other colliders.
				Flip ();

				break;
			}
		}
		
		// Set the enemy's velocity to moveSpeed in the x direction.
		rigidbody2D.velocity = new Vector2(transform.localScale.x * moveSpeed, rigidbody2D.velocity.y);	
		
		// If the enemy has one hit point left and has a damagedEnemy sprite...
		//if(HP == 1 && damagedEnemy != null)
			// ... set the sprite renderer's sprite to be the damagedEnemy sprite.
			//ren.sprite = damagedEnemy;
		
		// If the enemy has zero or fewer hit points and isn't dead yet...
		//if(HP <= 0 && !dead)
			// ... call the death function.
			//Death ();
	}
	
	public void Flip()
	{
		// Multiply the x component of localScale by -1.
		Vector3 enemyScale = transform.localScale;
		enemyScale.x *= -1;
		transform.localScale = enemyScale;
	}
}