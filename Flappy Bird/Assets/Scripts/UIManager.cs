using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
	public Text scoreText;
	public Button pauseButton, resumeButton, quitButton;
	public GameObject pauseMenu;


	void Start()
	{
		pauseButton = pauseButton.GetComponent<Button>();
		resumeButton = resumeButton.GetComponent<Button>();
		quitButton = quitButton.GetComponent<Button>();
		pauseButton.onClick.AddListener(pausePopup);
		togglePauseMenu(false);
	}

	public void setScoreText(string text)
	{
		scoreText.text = text;
	}
	public void togglePauseMenu(bool isVisible)
	{
		pauseButton.transform.gameObject.SetActive(!isVisible);
		pauseMenu.SetActive(isVisible);
	}
	public void pausePopup()
	{
		togglePauseMenu(true);
		GameObject.Find("Manager").GetComponent<GameState>().state = STATE.PAUSE;
		resumeButton.onClick.AddListener(() => {
			GameObject.Find("Manager").GetComponent<GameState>().state = STATE.PLAY;
			togglePauseMenu(false);
		});
	}
}
