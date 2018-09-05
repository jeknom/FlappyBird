using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STATE
{
	start,
	play,
	dead,
	pause,
}

public class GameState : MonoBehaviour 
{
	public STATE state;
	public int score;

	[SerializeField, Tooltip("This needs to be the player prefab.")]
	private GameObject player;

	[Header("Obstacle Spawner")]
	[SerializeField, Tooltip("The obstacle game object that gets spawned.")]
	private GameObject obstacle;
	[SerializeField, Tooltip("In seconds, the space of time between obstacle spawn.")]
	private float spawnFrequency;

	private void Start()
	{
		StartCoroutine(obstacleSpawner());
		StartCoroutine(scoreCounter());
	}

	IEnumerator obstacleSpawner()
	{
		while(true)
		{
			Instantiate(obstacle, new Vector3(40, 0, 0), Quaternion.identity);
			yield return new WaitForSeconds(spawnFrequency);
		}
	}

	IEnumerator scoreCounter()
	{
		while(true)
		{
			if (state == STATE.play)
			{
				score++;
				yield return new WaitForSeconds(1f);
			}
		}
	}

	private void Update()
	{
		switch(state)
		{
			case STATE.start:
				if (GameObject.Find("Player")) {Destroy(GameObject.Find("Player"));}
				GameObject[] activeObstacles = GameObject.FindGameObjectsWithTag("obstacle");
				foreach(var item in activeObstacles) Destroy(item);
				Time.timeScale = 0;
				if (Input.GetKeyDown(KeyCode.Space))
				{
					Instantiate(player); 
					state = STATE.play;
				}
				break;

			case STATE.play:
				Debug.Log(score);
				Time.timeScale = 1;
				break;
				
			case STATE.dead:
				state = STATE.start;
				break;

			case STATE.pause:
				Time.timeScale = 0;
				break;
		}
	}
}
