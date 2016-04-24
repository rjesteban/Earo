using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	public static SceneManager instance{get; private set;}

	public GameObject pausePanel;
	public GameObject pauseStagePanel;


	void Awake(){
		instance = this;
	}

	public void changeSceneTo(string _scene){
		Application.LoadLevel (_scene);
	}

	public  void closeApp(){
		Application.Quit ();
	}

	public  void GoToMenu(){
		Time.timeScale = 1;
		Application.LoadLevel ("Menu");
	}

	public  void GoToStage1(){
		Time.timeScale = 1;
		Application.LoadLevel ("Stage1");
	}

	public  void GoToStage2(){
		Time.timeScale = 1;
		Application.LoadLevel ("Stage2");
	}

	public  void GoToStage3(){
		Time.timeScale = 1;
		Application.LoadLevel ("Stage3");
	}

	public void GoToMap(){
		SaveLoad.Load();
		if(SaveLoad.gender == null)
			Application.LoadLevel("ChooseCharacter");
		else
			Application.LoadLevel ("Map");
	}

	public void GoToMiniChallenge1(){
		Time.timeScale = 1;
		Application.LoadLevel ("MiniGame1_InGame");
	}

	public void GoToMiniChallenge2(){
		Time.timeScale = 1;
		Application.LoadLevel ("MiniGame2_InGame");
	}

	public void SetEaro(string _gender){
		SaveLoad.Load();
		SaveLoad.SetUserCharacter(_gender);
		GoToMap();
	}

	public void resumeGame(){
		Time.timeScale = 1;
		PlayPause.instance.DestroyPanel();
	}

	public void pauseGame(){
		Time.timeScale = 0;
		Instantiate(pausePanel);
	}

	public void reload(){
		Time.timeScale = 1;
		Application.LoadLevel(Application.loadedLevel);
	}

	public void resumeStage(){
		Time.timeScale = 1;
		StageGameController.instance.StartCoroutine(StageGameController.instance.SpawnWaves());
		PlayPause.instance.DestroyPanel();
	}

	public void pauseStage(){
		//StageGameController.instance.StopAllCoroutines();
		CameraShake.instance.StopAllCoroutines();
		Time.timeScale = 0;
		Instantiate(pauseStagePanel);
	}

	public void Retry(){
		Application.LoadLevel(Application.loadedLevel);
	}


	public void GoToFinale(){
		Application.LoadLevel("Finale");
	}

	public void GoToSpecialFirstAid(){
		Application.LoadLevel("CPR");
	}
}
