using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public Image titleImage;
	public float titleImageMaxScale;
	public Vector3 titleImageScaleSpeed;
	public Vector3 titleImageRotationSpeed;
	public Button startButton, quitButton;
	private RectTransform titleImageTransform;
	

	// Use this for initialization
	void Start () 
	{
		titleImageTransform = titleImage.GetComponent<RectTransform>();
		StartCoroutine(titlePulser());

		startButton.onClick.AddListener(() => 
		{
			SceneManager.LoadScene("Play", LoadSceneMode.Single);
		});
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	IEnumerator titlePulser()
	{
		Vector3 currentRotation = new Vector3(0,0,0);
		bool reachedPeak = false;
		while(true)
		{
			if (titleImageTransform.localScale.x < titleImageMaxScale && !reachedPeak)
			{
				titleImageTransform.localScale = titleImageTransform.localScale + titleImageScaleSpeed;
				titleImageTransform.rotation = Quaternion.Euler(currentRotation += titleImageRotationSpeed);
				if (titleImageTransform.localScale.x >= titleImageMaxScale)
					reachedPeak = !reachedPeak;

			}
			else if (titleImageTransform.localScale.x > 1 && reachedPeak)
			{
				titleImageTransform.localScale = titleImageTransform.localScale - titleImageScaleSpeed;
				titleImageTransform.rotation = Quaternion.Euler(currentRotation -= titleImageRotationSpeed);
				if (titleImageTransform.localScale.x <= 1)
					reachedPeak = !reachedPeak;
			}
			yield return new WaitForEndOfFrame();
		}
	}
}
