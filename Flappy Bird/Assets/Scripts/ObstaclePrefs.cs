using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePrefs : MonoBehaviour 
{
	[Header("Scale and size")]
	[Tooltip("Adjust transform scale of this obstacle.")]
	public Vector3 size;

	[Tooltip("The position the object is placed on upon its creation.")]
	public Vector2 startPosition;
	
	[Header("Modifiers")]
	[Tooltip("Adjust the speed in which the obstacle moves from right to left.")]
	public float speed;

	//This rigidbody will be assigned to refer this GameObjects rigidbody.
	private Rigidbody2D rb2d;

	void OnEnable()
	{
		//Making the rb2d rigidbody equal to rigidbody of this GameObject.
		rb2d = gameObject.GetComponent<Rigidbody2D>();

		//Make the size of this object match the value given.
		gameObject.GetComponent<Transform>().localScale = size;

		//This will check if the variable values have not been changed at all and then print the line below to the console.
		if (size == new Vector3(0, 0, 0) || startPosition == new Vector2(0, 0) || speed == 0)
		{
			Debug.Log("You might have forgotten to set up some variables for an obstacle object.");
		}
	}

	void FixedUpdate()
	{
		//This will start moving the rigidbody of this GameObject to the left and the mathf makes sure that the it moves left.
		rb2d.position = rb2d.position + new Vector2(-Mathf.Abs(speed), 0);
	}
}
