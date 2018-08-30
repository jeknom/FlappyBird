using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePrefs : MonoBehaviour 
{
	//This rigidbody will be assigned to refer this GameObjects rigidbody.
	private Rigidbody2D rb2d;

	[Header("SIZE")]
	[Tooltip("Adjust transform scale of this obstacle.")]
	public Vector3 transformScale;

	[Header("MODIFIERS")]
	[Tooltip("The position the object is placed on upon its creation.")]
	public Vector2 startPosition;

	[Tooltip("The position on the X axis where the object gets deleted.")]
	public float endPosition;

	[Tooltip("Adjust the speed in which the obstacle moves from right to left.")]
	public float speed;

	[Header("OPTIONS")]
	[Tooltip("Toggle debugging on/off"), SerializeField]
	private bool toggleDebug = true;

	[Tooltip("Toggle on or off, obstacle randomizing."), SerializeField]
	private bool toggleRandoming = true;

	void Start()
	{
		//This randomizer method will be ran if the randoming has been enabled.
		obstacleRandomizer();

		//Making the rb2d rigidbody equal to rigidbody of this GameObject.
		rb2d = gameObject.GetComponent<Rigidbody2D>();

		//Set the obstacles starting location match that of the startPosition variable.
		rb2d.position = startPosition;

		//Make the size of this object match the value given.
		gameObject.GetComponent<Transform>().localScale = transformScale;

		//This will check if the variable values have not been changed at all and then print the line below to the console.
		if (transformScale == new Vector3(0, 0, 0) || startPosition == new Vector2(0, 0) || speed == 0)
		{
			Debug.Log("You might have forgotten to set up some variables for an obstacle object.");
		}
	}

	void FixedUpdate()
	{
		// This will start moving the rigidbody of this GameObject to the left and the mathf makes sure that the it moves left.
		// The if statement will only move this GameObject if it has not crossed the end position on the X axis.
		// This is also safeguarded by the Mathf Abs so that positive or negative values can safely be added in editor.
		if (rb2d.position.x > -Mathf.Abs(endPosition) && !GameObject.Find("Manager").GetComponent<GameState>().isDead())
		{
			rb2d.position = rb2d.position + new Vector2(-Mathf.Abs(speed), 0);
			// This method will debug the ending position of the obstacle.
			debugDeathZone();
		}
		// If the GameObjects Rigidbody2D crosses the X axis line and the player is not dead, the GameObject will be destroyed.
		else if (!GameObject.Find("Manager").GetComponent<GameState>().isDead())
		{
			Destroy(gameObject);
		}
	}

	// If debugging has been enabled, this method will draw the deathzone lines to demonstrate the places that the player object is not allowed to cross without dying.
	void debugDeathZone()
	{
		if (toggleDebug)
			Debug.DrawLine(new Vector3(-Mathf.Abs(endPosition), -10, 0), new Vector3(-Mathf.Abs(endPosition), 10, 0), Color.blue);
	}

	// Here's a method that will randomize the obstacle characteristics if the feature has been enabled.
	void obstacleRandomizer()
	{
		if(toggleRandoming)
		{
			Vector3[] topBottomPositions = new Vector3[] {new Vector3(startPosition.x, -6, 0), new Vector3(startPosition.x, 6, 0)};
			System.Random rnd = new System.Random();
			startPosition = topBottomPositions[rnd.Next(0, topBottomPositions.Length)];
		}
	}
}
