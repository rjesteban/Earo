using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets._2D;

public class StageGameController : MonoBehaviour {

	public static StageGameController instance{get; private set;}
	


	public float spawn_earthquake;
	float min, max;
	public bool isPaused;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		isPaused = false;
		min = 2.0f;
		max = 4.0f;
		StartCoroutine (SpawnWaves ());
	}

	public IEnumerator SpawnWaves(){
		while (EaroStatus.isAlive && CountDownTimer.instance.time>0) {
			Debug.Log ("Alive: " + EaroStatus.isAlive);
			float waitforseconds = Random.Range(10.0f, 30.0f);
			yield return new WaitForSeconds (waitforseconds);
			float random = Random.Range(min, max);
			max+=2;
			min+=2;
			if(max >= 10.0f){
				max = 9.0f;
			}

			QuakeService.instance.spawnQuake(random);

			yield return new WaitForSeconds(3.0f);

			QuakeService.instance.startQuake();
			CameraShake.instance.magnitude = random;
			CameraShake.instance.PlayShake(Random.Range(1.0f, waitforseconds));
		}

	}

	public void play_pause(Text _text){
		if (!isPaused) {
			Time.timeScale = 0;
			_text.text = "Paused";
			StopAllCoroutines();
			CameraShake.instance.StopAllCoroutines();
		} else {
			Time.timeScale = 1;
			_text.text = "";
			StartCoroutine(SpawnWaves());
		}
		isPaused = !isPaused;
	}
}



