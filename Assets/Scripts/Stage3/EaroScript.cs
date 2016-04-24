using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets._2D;

public class EaroScript : MonoBehaviour {
	public static bool isRising;
	private SpriteRenderer sprite;
	public const string LAYER_NAME = "BehindWall";

	// Use this for initialization
	void Start () {
		isRising = false;
		sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Platformer2DUserControl.m_Jump == true && RiseElevator.instance.touch == true) {
			Debug.Log("Spaced out");
			isRising = !isRising;
			sprite.sortingLayerName = LAYER_NAME;
			if(!isRising && RiseElevator.instance.time>18.0f){
				sprite.sortingLayerName = "Player";
			}
		}
	}
}
