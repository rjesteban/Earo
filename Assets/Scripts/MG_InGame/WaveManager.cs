using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveManager : MonoBehaviour {
	public static int Waves;
	public static float waveSpeed;
	public static bool updateWave;
	public Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		Waves = 1;
		waveSpeed = 10f;
	}
	
	// Update is called once per frame
	void Update () {
		if (updateWave) {
			Waves += 1;
			waveSpeed += 1f;
			text.text = "Wave " + Waves;
			updateWave = false;
		}

	}
}
