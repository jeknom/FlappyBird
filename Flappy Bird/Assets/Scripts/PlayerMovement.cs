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
}
