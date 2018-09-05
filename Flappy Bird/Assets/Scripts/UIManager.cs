using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
	private GameState gs;

	[SerializeField]
	private GameObject startUI, playUI, pauseUI, deadUI;

	[SerializeField]
	private Button pauseButton, resumeButton, quitButton;

	[SerializeField]
	private Text scoreText, deadScoreText;

	private void Start()
	{
		gs = GameObject.Find("Manager").GetComponent<GameState>();
		pauseButton.onClick.AddListener(() => {gs.state = STATE.pause;});
		resumeButton.onClick.AddListener(() => {gs.state = STATE.play;});
		quitButton.onClick.AddListener(() => {Application.Quit();});
	}

	private void Update()
	{
		toggleCurrentUI();

		switch(gs.state)
		{
			case STATE.start:
				break;

			case STATE.play:
				scoreText.text = gs.score.ToString();
				break;

			case STATE.dead:
				deadScoreText.text = "You survived for " + gs.score + " seconds";
				break;

			case STATE.pause:
				break;
		}
	}

	private void toggleCurrentUI()
	{
		if (gs.state == STATE.start && !startUI.activeSelf){startUI.SetActive(true);}
		else if (gs.state != STATE.start){startUI.SetActive(false);}

		if (gs.state == STATE.play && !playUI.activeSelf){playUI.SetActive(true);}
		else if (gs.state != STATE.play){playUI.SetActive(false);}

		if (gs.state == STATE.dead && !deadUI.activeSelf){deadUI.SetActive(true);}
		else if (gs.state != STATE.dead){deadUI.SetActive(false);}

		if (gs.state == STATE.pause && !pauseUI.activeSelf){pauseUI.SetActive(true);}
		else if (gs.state != STATE.pause){pauseUI.SetActive(false);}
	}
}