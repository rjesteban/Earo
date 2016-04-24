using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClickScript : MonoBehaviour {
	//public Text segText;
	// Use this for initialization
	public Image[] binKind;
	void Start () {
		//mistakeButton = GetComponent<Button> ();
		binKind = new Image[4];
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Clicked(GameObject mistakeButton){

		GameObject.Find ("Canvas").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("ClickedCanvas").GetComponent<Canvas> ().enabled = true;
		GameObject.Find ("TrashImage").GetComponent<Image>().sprite = mistakeButton.GetComponent<Button>().image.sprite;
		if (mistakeButton.name == "FirstMistake") {
			if(Storage.mistakeKind[0]==0){
				GameObject.Find("SegregationText").GetComponent<Text>().text = "Segregation: Biodegradable";
				GameObject.Find("BinImage").GetComponent<Image>().sprite = GameObject.Find("Bio").GetComponent<SpriteRenderer>().sprite;
			}
			else if(Storage.mistakeKind[0]==1){
				GameObject.Find("SegregationText").GetComponent<Text>().text = "Segregation: Hazardous";
				GameObject.Find("BinImage").GetComponent<Image>().sprite = GameObject.Find("Hazardous").GetComponent<SpriteRenderer>().sprite;
			}
			else if(Storage.mistakeKind[0]==2){
				GameObject.Find("SegregationText").GetComponent<Text>().text = "Segregation: Bulky";
				GameObject.Find("BinImage").GetComponent<Image>().sprite = GameObject.Find("Bulky").GetComponent<SpriteRenderer>().sprite;
			}
			else if(Storage.mistakeKind[0]==3){
				GameObject.Find("SegregationText").GetComponent<Text>().text = "Segregation: Non-Biodegradable";
				GameObject.Find("BinImage").GetComponent<Image>().sprite = GameObject.Find("NonBio").GetComponent<SpriteRenderer>().sprite;
			}
		}
		else if (mistakeButton.name == "SecondMistake") {
			if(Storage.mistakeKind[1]==0){
				GameObject.Find("SegregationText").GetComponent<Text>().text = "Segregation: Biodegradable";
				GameObject.Find("BinImage").GetComponent<Image>().sprite = GameObject.Find("Bio").GetComponent<SpriteRenderer>().sprite;
			}
			else if(Storage.mistakeKind[1]==1){
				GameObject.Find("SegregationText").GetComponent<Text>().text = "Segregation: Hazardous";
				GameObject.Find("BinImage").GetComponent<Image>().sprite = GameObject.Find("Hazardous").GetComponent<SpriteRenderer>().sprite;
			}
			else if(Storage.mistakeKind[1]==2){
				GameObject.Find("SegregationText").GetComponent<Text>().text = "Segregation: Bulky";
				GameObject.Find("BinImage").GetComponent<Image>().sprite = GameObject.Find("Bulky").GetComponent<SpriteRenderer>().sprite;
			}
			else if(Storage.mistakeKind[1]==3){
				GameObject.Find("SegregationText").GetComponent<Text>().text = "Segregation: Non-Biodegradable";
				GameObject.Find("BinImage").GetComponent<Image>().sprite = GameObject.Find("NonBio").GetComponent<SpriteRenderer>().sprite;
			}
		}
		else if (mistakeButton.name == "ThirdMistake") {
			if(Storage.mistakeKind[2]==0){
				GameObject.Find("SegregationText").GetComponent<Text>().text = "Segregation: Biodegradable";
				GameObject.Find("BinImage").GetComponent<Image>().sprite = GameObject.Find("Bio").GetComponent<SpriteRenderer>().sprite;
			}
			else if(Storage.mistakeKind[2]==1){
				GameObject.Find("SegregationText").GetComponent<Text>().text = "Segregation: Hazardous";
				GameObject.Find("BinImage").GetComponent<Image>().sprite = GameObject.Find("Hazardous").GetComponent<SpriteRenderer>().sprite;
			}
			else if(Storage.mistakeKind[2]==2){
				GameObject.Find("SegregationText").GetComponent<Text>().text = "Segregation: Bulky";
				GameObject.Find("BinImage").GetComponent<Image>().sprite = GameObject.Find("Bulky").GetComponent<SpriteRenderer>().sprite;
			}
			else if(Storage.mistakeKind[2]==3){
				GameObject.Find("SegregationText").GetComponent<Text>().text = "Segregation: Non-Biodegradable";
				GameObject.Find("BinImage").GetComponent<Image>().sprite = GameObject.Find("NonBio").GetComponent<SpriteRenderer>().sprite;
			}
		}

	}
}
