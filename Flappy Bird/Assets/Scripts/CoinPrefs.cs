using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPrefs : MonoBehaviour 
{
	[Header("MODIFIERS")]
	[Tooltip("This will modify the amount of score gained from collecting a coin.")]
	public int coinValue;

	[Tooltip("Adjust the speed in which the coin moves from right to left.")]
	public float speed;

	[Tooltip("The position on the X axis where the object gets deleted.")]
	public float endPosition;

	private Rigidbody2D rb2d;

	void OnEnable()
	{
		rb2d = gameObject.GetComponent<Rigidbody2D>();
	}


	void FixedUpdate()
	{
		if (rb2d.position.x > -Mathf.Abs(endPosition) && !GameObject.Find("Manager").GetComponent<GameState>().isDead())
		{
			rb2d.position = rb2d.position + new Vector2(-Mathf.Abs(speed), 0);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == "Player")
		{
			Physics2D.IgnoreCollision(GameObject.Find("Player").GetComponent<BoxCollider2D>(), gameObject.GetComponent<CircleCollider2D>(), true);
			GameObject.Find("Manager").GetComponent<GameState>().score += coinValue;
			Destroy(gameObject);
			Physics2D.IgnoreCollision(GameObject.Find("Player").GetComponent<BoxCollider2D>(), gameObject.GetComponent<CircleCollider2D>(), false);
		}
	}
}
