using UnityEngine;
using System.Collections;

public class StoreAndRemove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void saveAndRemove(){
		Destroy(FindObjectOfType<Storage>().gameObject);
	}

	public void saveAndRemoveRetry(){
		Destroy(FindObjectOfType<Storage>().gameObject);
		SceneManager.instance.GoToMiniChallenge1();
	}
}
