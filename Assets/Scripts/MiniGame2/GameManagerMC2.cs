using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManagerMC2 : MonoBehaviour {
	public bool isPaused;
	private Text textScore;
	private Text waveNum;
	public static bool win;
	public GameObject[] trashComp = new GameObject[4];
	public Vector2 spawnValues;
	public int trashCount;
	public static float spawnWait;
	public float startWait;
	public int trashRandomizer;
	public static bool GameOver;
	public static int Score;
	public static int Waves;
	public static int timesCorrect;
	public static int[] binMistakes = new int[4];
	
	// Use this for initialization
	void Start () {
		GameOver = false;
		isPaused = false;
		binMistakes [0] = 0;
		binMistakes [1] = 0;
		binMistakes [2] = 0;
		binMistakes [3] = 0;
		spawnWait = 2f;
		startWait = 1f;
		trashCount = 1;
		Waves = 1;
		timesCorrect = 0;
		win = false;
		textScore = GameObject.Find ("ScoreText").GetComponent<Text> ();
		waveNum = GameObject.Find ("WavesText").GetComponent<Text> ();
		StartCoroutine (SpawnWaves ());
	}
	
	void Update(){
		textScore.text = "Score: " + Score;
		waveNum.text = "Wave " + Waves;
	}
	
	IEnumerator SpawnWaves () {
		yield return new WaitForSeconds(startWait);
		while(!GameOver){

			if(Waves>1)
				trashCount =Mathf.CeilToInt( Waves/2);
				
			Debug.Log(GameOver);
			yield return new WaitForSeconds(spawnWait);
			for (int i = 0; i<trashCount ; i++) {
				//Debug.Log(GameOver);
				trashRandomizer = Random.Range(0,4);
				Vector2 spawnPosition = new Vector2 (Random.Range (-3.4f, 5.1f), spawnValues.y);
				Quaternion spawnRotation = new Quaternion ();
				Instantiate (trashComp[trashRandomizer], spawnPosition, spawnRotation);
				//yield return new WaitForSeconds(spawnWait);
			}
			
			if(Score>=50){
				GameOver = true;
				win = true;
			}
		}
		if (win) {
			SaveLoad.Load();
			MCData.current.SaveStage(1);
			GameObject.Find ("StageCompletedUI").GetComponent<Canvas> ().enabled = true;
			GameObject.Find ("Canvas").GetComponent<Canvas> ().enabled = false;
			GameObject.Find("Background").GetComponent<Animator>().SetInteger("whichResult",1);
			prepWin ();
		} else {
			GameObject.Find ("GameOverUI").GetComponent<Canvas> ().enabled = true;
			GameObject.Find ("Canvas").GetComponent<Canvas> ().enabled = false;
			GameObject.Find("Background").GetComponent<Animator>().SetInteger("whichResult",2);
			prepFail();

		}
	}
	void prepFail(){
		GameObject.Find ("Score").GetComponent<Text> ().text = "Score: " + Score;
		GameObject.Find ("Waves").GetComponent<Text> ().text = "Waves Finished: " + (Waves - 1);
		GameObject.Find("BioMistakes").GetComponent<Text> ().text = "" + binMistakes[0];
		GameObject.Find("NonBioMistakes").GetComponent<Text> ().text = "" + binMistakes[1];
		GameObject.Find("BulkyMistakes").GetComponent<Text> ().text = "" + binMistakes[2];
		GameObject.Find("HazardousMistakes").GetComponent<Text> ().text = "" + binMistakes[3];
	}
	void prepWin(){
		GameObject.Find("BioMistakesC").GetComponent<Text> ().text = "" + binMistakes[0];
		GameObject.Find("NonBioMistakesC").GetComponent<Text> ().text = "" + binMistakes[1];
		GameObject.Find("BulkyMistakesC").GetComponent<Text> ().text = "" + binMistakes[2];
		GameObject.Find("HazardousC").GetComponent<Text> ().text = "" + binMistakes[3];
	}
	void binsActivate(){
	}

	public void play_pause(Text _text){
		if (!isPaused) {
			//StopAllCoroutines();
			Time.timeScale = 0;
			_text.text = "Paused";
		} else {
			//StartCoroutine("SpawnWaves");
			Time.timeScale = 1;
			_text.text = "";
		}
		isPaused = !isPaused;
	}
}
