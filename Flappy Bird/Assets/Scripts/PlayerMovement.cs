using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D rb2d;
	public Vector2 jumpForce;

	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	void Update () 
	{
		if (Input.GetMouseButtonDown(0) && !GameObject.Find("Manager").GetComponent<GameState>().isDead())
		{
			rb2d.velocity = Vector2.zero;
			rb2d.AddForce(jumpForce, ForceMode2D.Impulse);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.layer == 8)
		{
			GameObject.Find("Manager").GetComponent<GameState>().setDead();
			Vector2 oppositeForce = new Vector2(-5, rb2d.velocity.y * 2);
			rb2d.velocity = new Vector2(0, 0);
			rb2d.AddForce(oppositeForce, ForceMode2D.Impulse);
		}
	}
}
