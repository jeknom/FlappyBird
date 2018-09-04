using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObstaclePrefs
{
	public string name;
	public float moveSpeed;
	public Vector2 startPoint;
	public Vector3 obstacleScale;
	public Vector2 colliderScale;
	public Sprite obstacleSprite;
}

public class Obstacle : MonoBehaviour
{
	[Header("Obstacles")]
	[SerializeField, Tooltip("Contains all of the used Obstacles.")]
	private ObstaclePrefs[] obstacleList = new ObstaclePrefs[0];
	private ObstaclePrefs selectedPrefs;

	// Assigning randomly picked obstacle preferences to this GameObject.
	void OnEnable()
	{
		System.Random rnd = new System.Random();
		selectedPrefs = obstacleList[rnd.Next(0, obstacleList.Length)];
		gameObject.name = selectedPrefs.name;
		gameObject.tag = "obstacle";
		gameObject.GetComponent<SpriteRenderer>().sprite = selectedPrefs.obstacleSprite;
		gameObject.GetComponent<Transform>().localScale = selectedPrefs.obstacleScale;
		gameObject.GetComponent<Rigidbody2D>().position = selectedPrefs.startPoint;
		gameObject.GetComponent<BoxCollider2D>().size = selectedPrefs.colliderScale;
	}

	// This will make the GameObject move to the left.
	// The GameObject gets deleted when it goes too far on the X axis.
	void FixedUpdate()
	{
		gameObject.GetComponent<Rigidbody2D>().position += new Vector2( - Mathf.Abs(selectedPrefs.moveSpeed), 0);

		if (gameObject.GetComponent<Rigidbody2D>().position.x < -15f)
		{
			Destroy(gameObject);
		}
	}
}