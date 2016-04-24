using UnityEngine;
using System.Collections;

[System.Serializable]
public class MCData {
	public static MCData current = new MCData();
	public bool isCompleted;

	public void SaveStage(int stageNumber){
		SaveLoad.Load();
		MCData data = null;
		
		try{
			data  = SaveLoad.savedMCs[stageNumber];
		}catch{
			isCompleted = true;
			SaveLoad.AddMC();
			Debug.Log ("here else");
		}
		
		if(data != null){
			if(!data.isCompleted)
				data.isCompleted = true;
			SaveLoad.SaveMC(stageNumber);
			Debug.Log ("here if");
		}
	}

}
