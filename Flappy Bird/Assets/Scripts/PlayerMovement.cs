using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D rb2d;
	public Vector2 jumpForce;
	public float maxSpeed;

	public Vector2 pvelocity;

	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () 
	{
		pvelocity = rb2d.velocity;

		if (Input.GetKeyDown(KeyCode.Space) && !GameObject.Find("Manager").GetComponent<GameState>().isDead())
		{
			rb2d.AddForce(jumpForce, ForceMode2D.Impulse);
		}

		// if (rb2d.velocity.y > maxSpeed)
		// {
		// 	rb2d.AddForce(new Vector2(0, -Mathf.Abs(rb2d.velocity.y - maxSpeed) / 2));
		// }
	}
}
