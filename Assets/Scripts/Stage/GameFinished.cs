using UnityEngine;
using System.Collections;

public class GameFinished : MonoBehaviour {

	public static GameFinished instance{get; private set;}
	

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.transform.tag == "Player") {
			if(Application.loadedLevelName == "Stage1"){
				SaveLoad.Load();
				StageData.current.SaveStage(0);
				Application.LoadLevel("MissionAccomplished");
			}
			else if (Application.loadedLevelName == "Stage3"){
				StageData.current.SaveStage(2);
				Application.LoadLevel("MissionAccomplished2");
			}
			//SceneManager.instance.previousLevel = 
			//	Application.loadedLevelName;

		}
	}
}
