using UnityEngine;
using System.Collections;

public class Storage : MonoBehaviour {

	public static Storage instance{get; private set;}

	void Awake(){
		instance = this;
	}

	public static Sprite[] mistakesSprite;
	public static int[] mistakeKind;
	public static int[] mistakeBinNum;
	public static int finScore;
	public static int finWave;
	public static int Counter;
	public enum mistakeBin {
		Biodegradable, 
		Hazardous, 
		Bulky,
		NonBiodegradable
	}
	// Use this for initialization
	void Start () {
		Counter = 0;
		instantiate();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		finScore = ScoreManager.score;
		finWave = WaveManager.Waves;
	}

	public static void storeInfo(Sprite sprite, int kind, int binNum){
		if (GameManager.Store) {
			Debug.Log ("ThisKind: " + kind);
			mistakesSprite [Counter] = sprite;
			mistakeKind [Counter] = kind;
			mistakeBinNum [Counter] = binNum;
			Debug.Log (Counter);
			Counter++;
		}
	}

	public void instantiate(){
		mistakesSprite = new Sprite[3];
		mistakeKind = new int[3];
		mistakeBinNum = new int[3];
	}
}
