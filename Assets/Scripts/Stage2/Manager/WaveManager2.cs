using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveManager2 : MonoBehaviour {
	public static int Waves;
	public static float waveSpeed;
	public static bool updateWave;

	// Use this for initialization
	void Start () {
		Waves = 1;
		waveSpeed = 10f;
	}
	
	// Update is called once per frame
	void Update () {
		if (updateWave) {
			Waves += 1;
			waveSpeed += 1f;
			updateWave = false;
		}

	}
}
