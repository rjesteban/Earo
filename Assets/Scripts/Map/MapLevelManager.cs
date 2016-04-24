using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MapLevelManager : MonoBehaviour {

	public List<Button> Stages;

	public List<Button> MCs;

	public Text gemiteStatus;

	public int gemitesCollected;


	// Use this for initialization
	void Start () {
		gemitesCollected = 0;

		SaveLoad.Load();
		for(int i = 0; i<=SaveLoad.savedStages.Count; i++){
			if(i==Stages.Count)
				break;
			Stages[i].interactable = true;
			if(i<SaveLoad.savedStages.Count){
				Debug.Log("gemites: " + SaveLoad.savedStages[i].gemitesCollected);
				gemitesCollected += SaveLoad.savedStages[i].gemitesCollected;
			}
		}
		for(int i = 0; i<=SaveLoad.savedMCs.Count; i++){
			if(i==MCs.Count)
				break;
			Debug.Log(Stages[i+1].interactable);
			if(Stages[i+1].interactable){
				MCs[i].interactable = true;
			}
		}

		gemiteStatus.text = gemitesCollected + "/10";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
