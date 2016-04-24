using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExtinguishFire : MonoBehaviour {

	public Button _button;
	public GameObject targetFire;
	
	public static ExtinguishFire instance{get;private set;}

	public GameObject instanceOfFirePanel;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		_button.enabled = false;
		_button.GetComponent<Image>().enabled = false;
		Debug.Log ("fsalkjaslkdja false");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.transform.tag == "Player"){
			Debug.Log ("DSLAKDJASKLDJSALKJASKLDAS");
			_button.enabled = true;
			_button.GetComponent<Image>().enabled = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.transform.tag == "Player"){
			_button.enabled = false;
			_button.GetComponent<Image>().enabled = false;
		}
	}

	public void SetTarget(){
		if(EaroStatus.instance.transform.position.y >6.9f && EaroStatus.instance.transform.position.y <8.4f)
			targetFire = GameObject.Find("Fire1");
		else
			targetFire = GameObject.Find("Fire");
		Instantiate(instanceOfFirePanel);
	}
}
