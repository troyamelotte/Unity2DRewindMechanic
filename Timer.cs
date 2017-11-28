using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	// Use this for initialization
	Text txt;
	public GameObject player;
	void Start () {
		txt = this.GetComponent<Text>();
		timeLeft = rewindTime;
	}
	
	public float rewindTime = 8.0f;
	float timeLeft;
	bool isRunning = true;
	void RestartTime()
	{
		timeLeft = rewindTime;
		txt.color = Color.black;
		isRunning = true;
	}

	void Update()
	{
		if (isRunning) {
			
			timeLeft -= Time.deltaTime;
			txt.text = timeLeft.ToString ("0.00");
			if (timeLeft < 0) {
				timeLeft = 0;
				txt.text = timeLeft.ToString ("0.00");
				txt.color = Color.red;
				isRunning = false;
				player.SendMessage ("StartRewind");
			}
		}
	}

}
