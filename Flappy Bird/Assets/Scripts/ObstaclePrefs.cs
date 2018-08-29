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
	[Tooltip("Toggle debugging on/off")]
	public bool toggleDebug;

	void OnEnable()
	{
		//Make the size of this object match the value given.
		gameObject.GetComponent<Transform>().localScale = transformScale;

		//Making the rb2d rigidbody equal to rigidbody of this GameObject.
		rb2d = gameObject.GetComponent<Rigidbody2D>();

		//Set the obstacles starting location match that of the startPosition variable.
		rb2d.position = startPosition;

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
		if (rb2d.position.x > -Mathf.Abs(endPosition))
		{
			rb2d.position = rb2d.position + new Vector2(-Mathf.Abs(speed), 0);
			// This method will debug the ending position of the obstacle.
			debug();
		}
		// If the GameObjects Rigidbody2D crosses the X axis line, the GameObject will be destroyed.
		else
		{
			Destroy(gameObject);
		}
	}

	void debug()
	{
		if (toggleDebug)
			Debug.DrawLine(new Vector3(-Mathf.Abs(endPosition), -10, 0), new Vector3(-Mathf.Abs(endPosition), 10, 0), Color.blue);
	}
}
