using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour 
{
	public Rigidbody2D playerBody;
	public float deathPosition;
	private float score;
	private UIManager uiController;

	void Start()
	{
		uiController = GameObject.Find("UI").GetComponent<UIManager>();
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
