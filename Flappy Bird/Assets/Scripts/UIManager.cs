using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
	public Text scoreText;
	public GameObject startUI, pauseMenu, pauseButton, resumeButton, quitButton;

	public void setUISequence(STATE state)
	{
		switch(state)
		{
			case STATE.START:
				toggleStartUI(true);
				togglePlayUI(false);
				togglePauseUI(false);
				break;
			case STATE.PLAY:
				toggleStartUI(false);
				togglePlayUI(true);
				togglePauseUI(false);
				break;
			case STATE.PAUSE:
				toggleStartUI(false);
				togglePlayUI(false);
				togglePauseUI(true);
				break;
			case STATE.DEAD:
				break;
		}
	}

	private void toggleStartUI(bool isEnabled)
	{
		startUI.SetActive(isEnabled);
	}

	private void togglePlayUI(bool isEnabled)
	{
		pauseButton.SetActive(isEnabled);
		pauseButton.GetComponent<Button>().onClick.AddListener(() =>
		{
			GameObject.Find("Manager").GetComponent<GameState>().state = STATE.PAUSE;
		});
	}

	private void togglePauseUI(bool isEnabled)
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
