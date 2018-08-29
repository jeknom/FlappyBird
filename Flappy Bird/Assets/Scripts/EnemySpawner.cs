using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour 
{
	public GameObject obstacle;

	void OnEnable()
	{
		StartCoroutine(spawner());
	}

	IEnumerator spawner()
	{
		Instantiate(obstacle);
		yield return new WaitForSeconds(1f);
	}
}
