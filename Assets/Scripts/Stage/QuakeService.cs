using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class QuakeService : MonoBehaviour {

	public static QuakeService instance{get; private set;}

	void Awake(){
		instance = this;
	}

	public GameObject _intensityScale;
	public GameObject _magnitudeScale;
	public int _intensityValue;
	public List<GameObject> hazards;
	public GameObject[] _sharpee;

	// Use this for initialization
	void Start () {
		_intensityValue = 1;
		hazards = new List<GameObject>(GameObject.FindGameObjectsWithTag ("Bruiser"));
		_sharpee = GameObject.FindGameObjectsWithTag ("Sharpee");
		hazards.AddRange(_sharpee);
	}

	public void spawnQuake(float random){
		_intensityScale.GetComponent<Image>().color = setIntensityColor(random);
		_magnitudeScale.GetComponent<Text>().text = random.ToString("0.00");
		StartCoroutine(DropCoverHoldOn());
	}

	public void startQuake(){
		foreach(GameObject hazard in hazards){
			if (_intensityValue == 1) {
				// none
			} else if (_intensityValue == 2) {
				// none
			} else if (_intensityValue == 3) {
				// none
			} else if (_intensityValue == 4) {
				// SOUNDS ONLY!!!!
			} else if (_intensityValue == 5) {
				if(hazard.GetComponent<Rigidbody2D>().mass < 5){
					hazard.GetComponent<Rigidbody2D>().isKinematic = false;
					setTriggerToFalse(hazard);
				}
			} else if (_intensityValue == 6) {
				if(hazard.GetComponent<Rigidbody2D>().mass >= 5 && hazard.GetComponent<Rigidbody2D>().mass < 15){
					hazard.GetComponent<Rigidbody2D>().isKinematic = false;
					setTriggerToFalse(hazard);
				}
			} else if (_intensityValue == 7) {
				if(hazard.GetComponent<Rigidbody2D>().mass >= 15 && hazard.GetComponent<Rigidbody2D>().mass < 30){
					hazard.GetComponent<Rigidbody2D>().isKinematic = false;
					setTriggerToFalse(hazard);
				}
			} else if (_intensityValue == 8) {
				if((hazard.GetComponent<Rigidbody2D>().mass >= 30 && hazard.GetComponent<Rigidbody2D>().mass < 50) ||
				   (hazard.GetComponent<Rigidbody2D>().mass <5)){
					hazard.GetComponent<Rigidbody2D>().isKinematic = false;
					setTriggerToFalse(hazard);
				}
			} else if (_intensityValue == 9) {
				if((hazard.GetComponent<Rigidbody2D>().mass >= 50 && hazard.GetComponent<Rigidbody2D>().mass < 100) ||
				   (hazard.GetComponent<Rigidbody2D>().mass >= 5 && hazard.GetComponent<Rigidbody2D>().mass < 15)){
					hazard.GetComponent<Rigidbody2D>().isKinematic = false;
					setTriggerToFalse(hazard);
				}
			} else if (_intensityValue == 10) {
				if(hazard.GetComponent<Rigidbody2D>().mass < 1300){
					hazard.GetComponent<Rigidbody2D>().isKinematic = false;
					setTriggerToFalse(hazard);
				}
			}
		}
	}

	Color setIntensityColor(float _random){
		int intensityPicker = 0;

		if (_random < 3) {
			_intensityValue = 1;
			return new Color32 (255, 255, 255, 255); //I
		} else if (_random >= 3 && _random < 4) {
			//randomize
			intensityPicker = Random.Range(0,2);

			if(intensityPicker == 0){
				_intensityValue = 2;
				return new Color32 (191, 204, 255, 255);  // II
			}
			else{
				_intensityValue = 3;
				return new Color32 (153, 153, 255, 255); // III
			}
		} else if (_random >= 4 && _random < 5) {
			intensityPicker = Random.Range(0,2);

			if(intensityPicker == 0){
				_intensityValue = 4;
				return new Color32 (136, 255, 255, 255); // IV
			}
			else{
				_intensityValue = 5;
				return new Color32 (125, 248, 148, 255); // V
			}

		} else if (_random >= 5 && _random < 6) {
			intensityPicker = Random.Range(0,2);

			if(intensityPicker == 0){
				_intensityValue = 6;
				return new Color32 (255, 255, 0, 255); // VI
			}
			else{
				_intensityValue = 7;
				return new Color32 (255, 221, 0, 255); // VII
			}

		} else if (_random >= 6 && _random < 7) {
			intensityPicker = Random.Range(0,3);

			if(intensityPicker == 0){
				_intensityValue = 7;
				return new Color32 (255, 221, 0, 255); // VII
			}else if(intensityPicker == 1){
				_intensityValue = 8;
				return new Color32 (255, 145, 0, 255); //VIII
			}else{
				_intensityValue = 9;
				return new Color32 (255, 0, 0, 255); // IX
			}
		} else if (_random >= 7) {
			intensityPicker = Random.Range(0,3);
			if(intensityPicker == 0){
				_intensityValue = 8;
				return new Color32 (255, 145, 0, 255); // VIII
			}else if (intensityPicker == 1){
				_intensityValue = 9;
				return new Color32 (255, 0, 0, 255); // IX
			}else{
				_intensityValue = 10;
				return new Color32 (221, 0, 0, 255); // X
			}
		}
		return new Color (0.0f, 0.0f, 0.0f, 1.0f); // 0 otherwise
	}

	private void setTriggerToFalse(GameObject obj){
		if(obj.GetComponent<Collider2D>() != null)
			obj.GetComponent<Collider2D>().isTrigger = false;
	}

	public int getIntensityValue(){
		return _intensityValue;
	}

	public IEnumerator DropCoverHoldOn(){
		if(_intensityValue >=4){
			AnimationService.instance.text.text = "Duck!";
			yield return new WaitForSeconds(0.5f);
			AnimationService.instance.text.text = "Cover!";
			yield return new WaitForSeconds(0.5f);
			AnimationService.instance.text.text = "Hold On!";
			yield return new WaitForSeconds(0.5f);
			AnimationService.instance.text.text = "";
		}
	}

}
