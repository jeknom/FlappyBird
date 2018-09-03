using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObstaclePrefs
{
	public string name;
	public Sprite obstacleSprite;
	public Vector2 startPoint;
	public float moveSpeed;
}

public class Obstacle : MonoBehaviour
{
	[Header("Obstacles")] 
	[Tooltip("The randomly spawned obstacles will use this objects components.")] 
	public GameObject templateObject;
	[SerializeField, Tooltip("Add all obstacles to this list.")]
	private ObstaclePrefs[] obstacleList = new ObstaclePrefs[1];

	//This method randomly selects one item from obstaclePrefs and creates an obstacle based on what it receives from there.
	public GameObject generateObstacle()
	{
		System.Random rnd = new System.Random();
		ObstaclePrefs selectedPrefs = obstacleList[0];

		templateObject.name = "Random " + selectedPrefs.name;
		templateObject.GetComponent<SpriteRenderer>().sprite = selectedPrefs.obstacleSprite;
		templateObject.GetComponent<Rigidbody2D>().position = selectedPrefs.startPoint;

		return templateObject;
	}

	IEnumerator Start()
	{
		while(true)
		{
			Instantiate(generateObstacle(), new Vector3(40f, 0f, 0f), Quaternion.identity);
			yield return new WaitForSeconds(5f);
		}
	}

	void FixedUpdate()
	{
		gameObject.GetComponent<Rigidbody2D>().position += new Vector2(-.1f, 0);
	}
}