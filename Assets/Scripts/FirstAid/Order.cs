using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Order : MonoBehaviour {

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
			FirstAid.buttons.Add(_clicked);
			int _order = FirstAid.buttons.Count;
			gameObject.GetComponent<Text>().text = _order.ToString();
			clicked = true;
		}
		else{
			int startRemoval = FirstAid.buttons.FindIndex(d => d == _clicked);
			FirstAid.buttons.Remove(_clicked);
			gameObject.GetComponent<Text>().text = "";
			for(int i = startRemoval; i<FirstAid.buttons.Count ; i++){
				Text c = FirstAid.buttons[i].gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
				int order = i+1;
				c.text = order.ToString();
			} 
			clicked = false;
		}
	}
}
