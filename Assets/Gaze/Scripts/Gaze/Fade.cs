using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Fade : MonoBehaviour
{
    [Header ("Fade")]
	public Image imgFade;
	[Range (0f, 5f)] public float timeFade = 2;
	[Range (0f, 5f)] public float delayFade = 1;

	void Start ()
	{
		FadeMethod (false);
	}

	public void FadeMethod (bool isFadeIn)
	{
		if (isFadeIn) Invoke ("Fade_In", delayFade);
		else Invoke ("Fade_Out", delayFade);
	}

	private void Fade_Out ()
	{
		imgFade.CrossFadeAlpha (0, timeFade, true);
	}

	private void Fade_In ()
	{
		imgFade.CrossFadeAlpha (1, timeFade, true);
	}
}
