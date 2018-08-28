using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle
{
	GameObject obstacleObject = new GameObject();
	Rigidbody2D rb2d = new Rigidbody2D();
	BoxCollider2D bc2d = new BoxCollider2D();
	SpriteRenderer sr;
	Vector2 startPosition;
	float height, width, speed;

	public Obstacle(float h, float w, float spd , Vector2 startPos)
	{
		//Initializing components with right values
		height = h;
		width = w;
		speed = spd;
		sr.sprite = GameObject.Find("Player").GetComponent<SpriteRenderer>().sprite;

		//Adding the components to the game object itself.
		sr = obstacleObject.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
		rb2d = obstacleObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
		bc2d = obstacleObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
	}
}
