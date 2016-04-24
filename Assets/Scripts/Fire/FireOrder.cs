using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FireOrder : MonoBehaviour {
	
	public bool clicked;
	
	// Use this for initialization
	void Start () {
		clicked = false;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void labelOrder(Button _clicked){
		if(!clicked){
			FireScript.buttons.Add(_clicked);
			int _order = FireScript.buttons.Count;
			gameObject.GetComponent<Text>().text = _order.ToString();
			clicked = true;
		}
		else{
			int startRemoval = FireScript.buttons.FindIndex(d => d == _clicked);
			FireScript.buttons.Remove(_clicked);
			gameObject.GetComponent<Text>().text = "";
			for(int i = startRemoval; i<FireScript.buttons.Count ; i++){
				Text c = FireScript.buttons[i].gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
				int order = i+1;
				c.text = order.ToString();
			} 
			clicked = false;
		}
	}
}
