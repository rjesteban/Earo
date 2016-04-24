using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class breathClicked : MonoBehaviour {
	public Slider breathSlider;
	// Use this for initialization
	void Start () {
		StartCoroutine (minusConstant());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator minusConstant(){
		while(breathSlider.value<breathSlider.maxValue-.1f){
			yield return new WaitForSeconds(0.3f);
			breathSlider.value -=0.05f;
		}
		StopCoroutine(minusConstant());
	}

	public void isClicked(){
		breathSlider.value +=0.10f;
		if(breathSlider.value == breathSlider.maxValue){
			CPRManager.CurrentStep=4;
			CPRManager.instance.startGame();
		}
	}
}
