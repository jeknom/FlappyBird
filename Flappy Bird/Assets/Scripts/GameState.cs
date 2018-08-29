using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STATE 
{
	START, PLAY, DEAD
}

public class GameState : MonoBehaviour 
{
	public Rigidbody2D playerBody;
	public float deathPosition, deathPositionDebugLineWidth;
	private float score;
	private UIManager uiController;

	//The GameState switch case will keep the right game sequence playing with this enum.
	private STATE state = STATE.PLAY;

	void Start()
	{
		playerBody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
		uiController = GameObject.Find("UI").GetComponent<UIManager>();
		
		StartCoroutine(scoreCounter());
	}

	void Update()
	{
		debug();

		//The previously mentioned GameState switch case.
		switch(state)
		{
			case STATE.START:
				break;
			case STATE.PLAY:
				uiController.setScoreText("Score: " + score);
				if (isDead())
				{
					state = STATE.DEAD;
					Debug.Log("Player is dead!");
				}
				break;
			case STATE.DEAD:
				break;
		}
	}

	//Checks if the player is dead.
	public bool isDead()
	{
		if(Mathf.Abs(playerBody.position.y) > deathPosition || state == STATE.DEAD)
		{
			return true;
		}
		return false;
	}

	void debug()
	{
		//Debug deathzone if player is alive.
		if (!isDead())
		{
			Debug.DrawLine(new Vector3(deathPositionDebugLineWidth, deathPosition, 0), new Vector3(-deathPositionDebugLineWidth, deathPosition, 0), Color.green);
			Debug.DrawLine(new Vector3(deathPositionDebugLineWidth, -deathPosition, 0), new Vector3(-deathPositionDebugLineWidth, -deathPosition, 0), Color.green);
		}
	}

	//Keeps count of the score.
	IEnumerator scoreCounter()
	{
		while(true)
		{
			score += 0.1f;
			yield return new WaitForSeconds(0.1f);
		}
	}
}
