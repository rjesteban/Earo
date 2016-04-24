using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountDownTimer : MonoBehaviour {

	public static CountDownTimer instance{get; private set;}

	public  float time;
	public GameObject timer;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		//time = 60;
	}
	
	// Update is called once per frame
	void Update () {
		if(time>0)
			time -= Time.deltaTime;
		timer.GetComponent<Text>().text = time.ToString("00.00");
		if (time <= 0)
			AnimationService.instance.StartCoroutine ("TimesUp");
	}

	void addTime(){
		time += 10.0f;
	}
}
