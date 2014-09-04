using UnityEngine;
using System.Collections;

public class Rhythm : MonoBehaviour {
	
	public Renderer myCircle;
	public Renderer myCircleTwo;
	
	public bool buttonUp;
	public bool buttonDown;

	public bool setTime;
	public bool setTime2;

	public bool rhythmIsOn;
	public bool quickRhythm;
	
	public float timerTime;
	public float timerTime2;

	public float timeContainer;
	public float timeContainer2;

	// Use this for initialization
	void Start () {
		buttonUp = true;
		buttonDown = false;

		timerTime = 0.0F;
		timerTime2 = 0.0F;

		rhythmIsOn = false;

		audio.Play();
		audio.loop = true;
	}
	
	// Update is called once per frame
	void Update () {



		if (Input.GetButtonDown("Jump"))
		{	
			setTime = true;
			setTime2 = false;
			timerTime2 = timeContainer2;
			print (timerTime2);
			myCircleTwo.material.color = Color.yellow;
			
		}
		
		if (Input.GetButtonUp("Jump"))
		{
			setTime = false;
			setTime2 = true;
			timerTime = timeContainer;
			print(timerTime);
			myCircleTwo.material.color = Color.gray;
			
		}

		if (((timerTime > 0.8F) && (timerTime < 1.2F)) || ((timerTime2 > 0.8F) && (timerTime2 < 1.2F)))
		{
			rhythmIsOn = true;
		}
		else if (((timerTime > 0.2F) && (timerTime < 0.4F)) || ((timerTime2 > 0.2F) && (timerTime2 < 0.4F)))
		{
			quickRhythm = true;
			rhythmIsOn = false;
		}

		else
		{
			quickRhythm = false;
			rhythmIsOn = false;
		}
	}
	
	void FixedUpdate () {

		if (timeContainer > 2.0F || timeContainer2 > 2.0F)
		{
			timerTime = 0.0F;
			timerTime2 = 0.0F;
		}

		/*if (timeContainer < 0.2 || timeContainer2 < 0.2)
		{
			timerTime = 0.0F;
			timerTime2 = 0.0F;
		}*/


		if (buttonUp)
		{
			Invoke("buttonIsDown", 1);
		}
		else if (buttonDown)
		{
			Invoke("buttonIsUp", 1);
		}

		if (setTime)
		{
			timeContainer += Time.deltaTime;
		}
		else if (!setTime)
		{
			timeContainer = 0.0F;
		}

		if (setTime2)
		{
			timeContainer2 += Time.deltaTime;
		}
		else if (!setTime2)
		{
			timeContainer2 = 0.0F;
		}


	

	}
	
	void buttonIsUp () {
		buttonUp = true;
		buttonDown = false;
		myCircle.material.color = Color.red;
	}
	
	void buttonIsDown () {
		buttonDown = true;
		buttonUp = false;
		myCircle.material.color = Color.blue;
	}

}