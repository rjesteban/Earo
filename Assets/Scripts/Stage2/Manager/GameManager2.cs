using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager2 : MonoBehaviour {

	public static GameManager2 instance{get; private set;}

	public bool isPaused;
	public Canvas failed;
	public Canvas accomplished;
	public static bool transitionNow;
	public static bool finishInstructions;
	public GameObject[] spawnComp=new GameObject[2];
	public Vector2 spawnValues; 
	private int whichObject;
	private int objectRandomizer;
	public float[] lanePosition  = new float[4];
	//public GameObject[] firstAidInstance;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		transitionNow = false;
		isPaused = false;
		GameObject.Find ("InstructionCanvas").GetComponent<Canvas> ().enabled = true; 
		lanePosition[0] = -3.54f;
		lanePosition[1] = -1.59f;
		lanePosition[2] =  0.34f;
		lanePosition[3] =  2.34f;

	}
	// Update is called once per frame
	void Update () {

		if(finishInstructions){
			StartCoroutine(SpawnWaves());
			Debug.Log("here" + finishInstructions);
		}
		finishInstructions = false;

	}

	IEnumerator SpawnWaves(){
			for ( ; LifeSaver.rightAnswer < 15 ;){
				yield return new WaitForSeconds(4f);
				objectRandomizer = Random.Range(0,2);
				Vector2 spawnPosition = new Vector2(lanePosition[Random.Range(0,4)], spawnValues.y);
				Quaternion spawnRotation = new Quaternion();

				Instantiate(spawnComp[objectRandomizer],spawnPosition,spawnRotation);
			}

	}
	public void isMissionFailed(){
		StopAllCoroutines();
		failed.enabled = true;
	}
	public void isAccomplished(){
		StopAllCoroutines();
		SaveLoad.Load();
		StageData.current.SaveSpecialStage(1);
		accomplished.enabled = true;
	}

	public void play_pause(Text _text){
		if (!isPaused) {
			Time.timeScale = 0;
			_text.text = "Paused";
		} else {
			Time.timeScale = 1;
			_text.text = "";
		}
		isPaused = !isPaused;
	}
	
}