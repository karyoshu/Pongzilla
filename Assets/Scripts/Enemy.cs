using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	Animator anim;
	public bool alive = true;
	public float moveSpeed = 10f;		// The speed the enemy moves at.
	public int HP = 1;					// How many times the enemy can be hit before it dies.
	public Transform target;
	private SpriteRenderer ren;			// Reference to the sprite renderer.
	private bool facingRight = false;	// Reference to the position of the gameobject used for checking if something is in front.
	private bool dead = false;			// Whether or not the enemy is dead.
	public GameObject hundredPointsUI;	// A prefab of 100 that appears when the enemy dies.
	private guiSetup score;				// Reference to the Score script.
	private Transform frontCheck;
	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator>();
		ren = GetComponent<SpriteRenderer> ();
		score = GameObject.Find("guiSetup").GetComponent<guiSetup>();
		frontCheck = transform.Find("FrontCheck").transform;
	}
	void Start(){
		InvokeRepeating ("Move", 0f, 1f);
	}
	// Update is called once per frame
	void FixedUpdate () {
		anim.SetBool ("IsAlive", alive);
		// Create an array of all the colliders in front of the enemy.

	}
	
	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "Player") {
			alive = false;
			Invoke("DieMinion",0.5f);
		}
	}

	void Move(){
		float move = Random.Range (-0.5f, 0.6f);
		if(move >0.1)
			rigidbody2D.velocity = new Vector2(moveSpeed, rigidbody2D.velocity.y);
		else if(move <-0.1)
			rigidbody2D.velocity = new Vector2(-moveSpeed, rigidbody2D.velocity.y);
		else
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 4f);
		if (move > 0.1 && !facingRight)
		// ... flip the player.
				Flip ();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if (move <= -0.1 && facingRight)
		// ... flip the player.
				Flip ();
	}

	void DieMinion() {
		//Add to Score
		score.score += 100;
		// Create a vector that is just above the enemy.
		Vector3 scorePos;
		scorePos = transform.position;
		scorePos.y += 1.5f;
		
		// Instantiate the 100 points prefab at this point.
		Instantiate(hundredPointsUI, scorePos, Quaternion.identity);
		Destroy(target.gameObject);
		Destroy(gameObject);
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
}