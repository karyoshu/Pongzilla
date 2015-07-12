using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour {
	public bool jump;
	int jumpValue = 2;
	[SerializeField] bool airControl = false;			// Whether or not a player can steer while jumping;
	[SerializeField] float maxSpeed = 10f;				// The fastest the player can travel in the x axis.
	[SerializeField] float jumpVel = 10f;			// Amount of force added when the player jumps.	
	[SerializeField] Transform groundCheck;								// A position marking where to check if the player is grounded.
	float groundedRadius = 0.09f;							// Radius of the overlap circle to determine if grounded
	[SerializeField] bool grounded = false;								// Whether or not the player is grounded.
	[SerializeField] LayerMask whatIsGround;			// A mask determining what is ground to the character
	public AudioClip jump01;
	public AudioClip jump02;
	public AudioClip jump03;
	public AudioClip jump04;
	// Use this for initialization
	void Awake () {

	}
	
	// Update is called once per frame
	void Update () {
		#if CROSS_PLATFORM_INPUT
		if (CrossPlatformInput.GetButtonDown("Jump")) jump = true;
		#else
		if (Input.GetButtonDown("Jump")) jump = true;
		#endif
	}



	void FixedUpdate(){
		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
		if (grounded)
			jumpValue = 2;
		#if CROSS_PLATFORM_INPUT
		float h = CrossPlatformInput.GetAxis("Horizontal");
		#else
		float h = Input.GetAxis("Horizontal");
		#endif

		Move( h, jump );
		jump = false;
	}

	void Move(float move, bool jump)
	{
		if (grounded) {
			rigidbody2D.AddTorque(-1*move*maxSpeed*Time.deltaTime);
		}
		if(!grounded && airControl)
		{
			// Move the character
			rigidbody2D.AddTorque(-1*move*maxSpeed*Time.deltaTime);
			rigidbody2D.velocity = new Vector2(move * maxSpeed * Time.deltaTime, rigidbody2D.velocity.y);
		}
		
		// If the player should jump...
		if (jumpValue > 0 && jump) {
						// Add a vertical force to the player.
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, jumpVel);
			jumpValue--;
			int rand = Random.Range (0, 4);
			switch (rand) {
			case 0:
					audio.clip = jump01;
					break;
			case 1:
					audio.clip = jump01;
					break;
			case 2:
					audio.clip = jump01;
					break;
			case 3:
					audio.clip = jump01;
					break;
			}
			audio.pitch = Random.Range(0.9f,1.1f);
			audio.Play();
		}
	}
}
