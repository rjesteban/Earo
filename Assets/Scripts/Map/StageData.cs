using UnityEngine;
using System.Collections;

[System.Serializable]
public class StageData {

	private static StageData currents;
	public int gemitesCollected;
	public int totalGemites;
	public float personalBestTime;
	
	private StageData(){
		gemitesCollected = 0;
		totalGemites = 0;
		personalBestTime = 0;
	}

	public static StageData current{
		get {
			if (currents == null){
				currents = new StageData();
			}
			return currents;
		}
	}


	
	public void SaveStage(int stageNumber){
		Debug.Log (Application.persistentDataPath);
		SaveLoad.Load();
		StageData data = null;
		
		try{
			data  = SaveLoad.savedStages[stageNumber];
		}catch{
			gemitesCollected = GemCollectionStatus.instance.collected;
			totalGemites = GemCollectionStatus.instance.toCollect;
			personalBestTime = CountDownTimer.instance.time;
			SaveLoad.AddStage();
			Debug.Log ("here else");
		}
		
		if(data != null){
			if(data.gemitesCollected < GemCollectionStatus.instance.collected){
				data.gemitesCollected = GemCollectionStatus.instance.collected;
				Debug.Log("data.gemitescollected: " + data.gemitesCollected);
				Debug.Log("instance: " + GemCollectionStatus.instance.collected);
			}
			if(data.personalBestTime < CountDownTimer.instance.time){
				data.personalBestTime = CountDownTimer.instance.time;
				Debug.Log("pbt: " + data.personalBestTime);
				Debug.Log("instance: " + CountDownTimer.instance.time);
			}
			SaveLoad.SaveStage(stageNumber);
			Debug.Log ("here if");
		}
	}

	public void SaveSpecialStage(int stageNumber){
		Debug.Log (Application.persistentDataPath);
		SaveLoad.Load();
		Debug.Log ("-----------after-----------");
		StageData data = null;
		
		try{
			data = SaveLoad.savedStages[stageNumber];
		}catch{
			gemitesCollected = 3;
			totalGemites = 3;
			personalBestTime = -1;
			SaveLoad.AddStage();
			Debug.Log ("here else");
		}
	}
}
