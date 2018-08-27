using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour 
{
	public Rigidbody2D playerBody;
	public float deathPosition, deathPositionDebugLineWidth;
	private float score;
	private UIManager uiController;

	void Start()
	{
		if (GameObject.Find("Player"))
		{
			playerBody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
		}
		else
		{
			Debug.Log("Player object has not been placed to the scene!");
			playerBody = new Rigidbody2D();
		}

		if (GameObject.Find("UI"))
		{
			uiController = GameObject.Find("UI").GetComponent<UIManager>();
		}
		else
		{
			Debug.Log("UI Object has not been placed to the scene!");
			uiController = new UIManager();
		}
		
		StartCoroutine(scoreCounter());
	}

	void Update()
	{
		uiController.setScoreText("Score: " + score);
		if (isDead())
		{
			Debug.Log("Player is dead!");
		}
	}

	bool isDead()
	{
		Debug.DrawLine(new Vector3(deathPositionDebugLineWidth, deathPosition, 0), new Vector3(-deathPositionDebugLineWidth, deathPosition, 0), Color.green);
		Debug.DrawLine(new Vector3(deathPositionDebugLineWidth, -deathPosition, 0), new Vector3(-deathPositionDebugLineWidth, -deathPosition, 0), Color.green);

		if(Mathf.Abs(playerBody.position.y) > deathPosition)
		{
			return true;
		}
		return false;
	}

	IEnumerator scoreCounter()
	{
		while(true)
		{
			score += 0.1f;
			yield return new WaitForSeconds(0.1f);
		}
	}
}
