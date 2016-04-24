using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad {

	public static List<StageData> savedStages = new List<StageData>();
	public static List<MCData> savedMCs = new List<MCData>();
	public static string gender;
	public static FileStream _file = null;

	//---------------------USER CHARACTER--------------------

	public static void SetUserCharacter(string _gender){
		if(_gender.Equals("B") || _gender.Equals("G")){
			Debug.Log("success");
			gender = _gender;
		}
		else
			gender = "";
		serializeFile();
		_file.Close();
	}

	//--------------------------STAGES-----------------------

	public static void AddStage() {
		SaveLoad.savedStages.Add(StageData.current);
		serializeFile ();
		_file.Close();
	}

	//it's static so we can call it from anywhere
	public static void SaveStage(int index) {
		SaveLoad.savedStages[index] = StageData.current;
		Debug.Log ("saveload "+SaveLoad.savedStages[index].gemitesCollected);
		Debug.Log ("current "+StageData.current.gemitesCollected);
		serializeFile ();
		_file.Close();
	}

	//------------------------MINICHALLENGES-------------------

	public static void AddMC() {
		SaveLoad.savedMCs.Add(MCData.current);
		serializeFile ();
		_file.Close();
	}

	//it's static so we can call it from anywhere
	public static void SaveMC(int index) {
		SaveLoad.savedMCs[index] = MCData.current;
		serializeFile ();
		_file.Close();
	}


	//---------------------LOAD----------------------------

	public static void Load() {
		Debug.Log(Application.persistentDataPath);
		if(File.Exists(Application.persistentDataPath + "/savedGames.gd")) {
			BinaryFormatter bf = new BinaryFormatter();
			loadOrCreateFile();
			//FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
			SaveLoad.gender = (string)bf.Deserialize(_file);
			SaveLoad.savedStages = (List<StageData>)bf.Deserialize(_file);
			SaveLoad.savedMCs = (List<MCData>)bf.Deserialize(_file);
			_file.Close();
		}
	}

	public static void loadOrCreateFile(){
		if(File.Exists(Application.persistentDataPath + "/savedGames.gd"))
			_file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
		else
			_file = File.Create(Application.persistentDataPath + "/savedGames.gd");

	}

	public static void serializeFile(){
		BinaryFormatter bf = new BinaryFormatter();
		loadOrCreateFile();
		bf.Serialize(_file, SaveLoad.gender);
		bf.Serialize(_file, SaveLoad.savedStages);
		bf.Serialize(_file, SaveLoad.savedMCs);
	}
}