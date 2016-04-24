using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class loadPrevInfos : MonoBehaviour {

	public static loadPrevInfos instance{get; private set;}

	void Awake(){
		instance = this;
	}

	public static Sprite[] mistakesSprite;
	public static int[] mistakeKind;
	public static int[] mistakeBinNum;
	public static int finScore;
	public static int finWave;
	public static int Counter;
	// Use this for initialization
	void Start () {
		Counter = 0;
		GameObject.Find ("WaveText").GetComponent<Text> ().text = "Waves: " + Storage.finWave;
		GameObject.Find ("ScoreText").GetComponent<Text> ().text = "Score: " + Storage.finScore;

		GameObject.Find ("FirstMistake").GetComponent<Image> ().sprite = Storage.mistakesSprite [Counter];
		Counter++;
		GameObject.Find ("SecondMistake").GetComponent<Image> ().sprite = Storage.mistakesSprite[Counter];
		Counter++;
		GameObject.Find ("ThirdMistake").GetComponent<Image> ().sprite = Storage.mistakesSprite[Counter];
		Counter++;


	}
	
	// Update is called once per frame
	void Update () {

		//Counter++;
	}
}
