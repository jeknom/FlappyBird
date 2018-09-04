using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
	private GameState gs;

	[SerializeField]
	private GameObject startUI, playUI, pauseUI, deadUI;

	private void Start()
	{
		gs = GameObject.Find("Manager").GetComponent<GameState>();
	}

	private void Update()
	{
		disableUnused();

		switch(gs.state)
		{
			case STATE.start:
				startUI.SetActive(true);
				break;

			case STATE.play:
				break;

			case STATE.dead:
				break;

			case STATE.pause:
				break;
		}
	}

	private void disableUnused()
	{
		if (gs.state != STATE.start){startUI.SetActive(false);}
		if (gs.state != STATE.play){playUI.SetActive(false);}
		if (gs.state != STATE.dead){deadUI.SetActive(false);}
		if (gs.state != STATE.pause){pauseUI.SetActive(false);}
	}
}
