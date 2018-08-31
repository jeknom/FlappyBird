using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
	public Text scoreText;
	public GameObject pauseMenu, pauseButton, resumeButton, quitButton;

	public void setUISequence(STATE state)
	{
		switch(state)
		{
			case STATE.START:
				break;
			case STATE.PLAY:
				togglePlayUI(true);
				togglePauseMenu(false);
				break;
			case STATE.PAUSE:
				togglePauseMenu(true);
				togglePlayUI(false);
				break;
			case STATE.DEAD:
				break;
		}
	}

	private void togglePlayUI(bool isEnabled)
	{
		pauseButton.SetActive(isEnabled);
		pauseButton.GetComponent<Button>().onClick.AddListener(() =>
		{
			GameObject.Find("Manager").GetComponent<GameState>().state = STATE.PAUSE;
		});
	}

	private void togglePauseMenu(bool isEnabled)
	{
		pauseMenu.SetActive(isEnabled);
		if (isEnabled)
		{
			resumeButton.GetComponent<Button>().onClick.AddListener(() =>
			{
				GameObject.Find("Manager").GetComponent<GameState>().state = STATE.PLAY;
			});
		}
	}

	public void setScoreText(string text)
	{
		scoreText.text = text;
	}
}
