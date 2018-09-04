using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
	private Rigidbody2D rb2d;
	private GameObject topCollider, botCollider;
	private GameState gs;
	private bool deathSequence = false;

	[Header("Modifiers")]
	[SerializeField, Tooltip("Adjust the jump force of the player.")]
	private float jumpForce = 9.5f;

	// This creates the top and bottom Colliders and initialize some variables.
	private void Start()
	{
		topCollider = new GameObject();
		topCollider.name = "Top Collider";
		topCollider.layer = 8;
		topCollider.GetComponent<Transform>().position = new Vector3(0f, 5f, 0f);
		topCollider.GetComponent<Transform>().localScale = new Vector3(22f ,0f ,0f);
		topCollider.AddComponent<EdgeCollider2D>();

		botCollider = new GameObject();
		botCollider.name = "Bottom Collider";
		botCollider.layer = 8;
		botCollider.GetComponent<Transform>().position = new Vector3(0f, -4.1f, 0f);
		botCollider.GetComponent<Transform>().localScale = new Vector3(22f ,0f ,0f);
		botCollider.AddComponent<EdgeCollider2D>();

		rb2d = gameObject.GetComponent<Rigidbody2D>();
		rb2d.position = new Vector2(0, 0);
		gs = GameObject.Find("Manager").GetComponent<GameState>();
	}

	// This resets the players velocity and then adds force to its Y axis.
	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && gs.state == STATE.play && !deathSequence)
		{
			gameObject.GetComponent<Animator>().SetTrigger("flap");
			rb2d.velocity = new Vector2(0, 0);
			rb2d.AddForce(new Vector2(0, Mathf.Abs(jumpForce)), ForceMode2D.Impulse);
		}
	}

	// This checks if the player collides with an obstacle and then starts the death sequence.
	private IEnumerator OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.layer == 8)
		{
			deathSequence = true;
			Destroy(gameObject.GetComponent<PolygonCollider2D>());
			gameObject.GetComponent<Animator>().SetTrigger("dead");
			rb2d.velocity = new Vector2(0, 0);
			rb2d.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
			yield return new WaitForSeconds(3f);
			gs.state = STATE.dead;
			Destroy(topCollider);
			Destroy(botCollider);
			Destroy(gameObject);
		}
	}
}
