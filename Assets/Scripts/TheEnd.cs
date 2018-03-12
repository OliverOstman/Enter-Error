using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour {
	public Text TheEndText;

	private int t = 0;
	private byte red = 0;

	void Start () {
		
	}

	void Update () {
		TheEndText.GetComponent<Text>().color = new Color32 (red, 0, 0, 255);
		t++;
		if (t >= 70) {
			TheEndText.text = "The End?";
			red += 2;
			if (red >= 254) {
				SceneManager.LoadScene ("Menu Screen");
			}
		}
	}
}
