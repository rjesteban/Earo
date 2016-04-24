using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets._2D;

public class FirstAid : MonoBehaviour {

	public static List<Button> buttons;

	public List<Button> allButtons;

	public List<int> _orderOfButtons;
	public List<Sprite> randomSprites;
	
	// Use this for initialization
	void Start () {
		buttons = new List<Button>();
		_orderOfButtons = new List<int>();

		StageGameController.instance.StopAllCoroutines();
		CameraShake.instance.StopAllCoroutines();

		Time.timeScale = 0;

		loadSprites();
	}


	//load sprites randomly
	//assign sprites and then render
	private void loadSprites(){
		int random = -1;
		for(int i = 0 ; i< allButtons.Count ; i++){
			while(random ==-1 || _orderOfButtons.Contains(random)){
				random = Random.Range(1,randomSprites.Count+1);
			}
			if(random!=-1){
				_orderOfButtons.Add(random);
			}
		}

		for(int i=0 ; i<_orderOfButtons.Count ; i++){
			//int index = _orderOfButtons.FindIndex(d => d == i);
			//int index = _orderOfButtons.IndexOf(i+1);
			int index = _orderOfButtons[i]-1;
			allButtons[i].GetComponent<Image>().sprite = randomSprites[index];
		}
	}
	

	public void match(){
		string expected = "";
		string answer = "";
		for(int i = 0; i<_orderOfButtons.Count; i++){
			expected += allButtons[i].GetComponent<Image>().sprite.ToString()[2];
			answer += allButtons[i].gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text;
		}

		Debug.Log("Expected: " + expected);
		Debug.Log("Answer: " + answer);

		if(expected.Equals(answer)){
			AnimationService.instance.StartCoroutine("EaroWasSaved");
			PlatformerCharacter2D.instance.m_Anim.SetBool("Hit", false);
		}
		else
			AnimationService.instance.StartCoroutine("EaroWasNotSaved");

		Time.timeScale = 1;
		StageGameController.instance.StartCoroutine (StageGameController.instance.SpawnWaves ());
		Destroy(gameObject);
	}

}
