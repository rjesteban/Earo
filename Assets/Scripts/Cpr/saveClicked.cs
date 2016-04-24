using UnityEngine;
using System.Collections;

public class saveClicked : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void isClicked(){
//		GameManager2.instance.StartCoroutine("SpawnWaves");
//		CPRManager.instance.DestroyAll();
		Application.Quit();
	}
}
