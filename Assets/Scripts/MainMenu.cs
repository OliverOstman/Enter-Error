using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	private RawImage earth;
	private RawImage text;
	private RawImage station;
	private Button startGameButton;
	private Button exitGameButton;
	private byte a  = 0;
	private byte gb = 255;
	private bool red = false;

	void Start () {
		station = GameObject.Find ("BackgroundSpaceStation").GetComponent<RawImage> ();
		earth = GameObject.Find ("BackgroundEarth").GetComponent<RawImage> ();
		text = GameObject.Find ("BackgroundText").GetComponent<RawImage> ();
		startGameButton = GameObject.Find ("ButtonStartGame").GetComponent<Button> ();
		exitGameButton = GameObject.Find ("ButtonExitGame").GetComponent<Button> ();
		startGameButton.onClick.AddListener (() => StartGame ());
		exitGameButton.onClick.AddListener (() => ExitGame ());
	}

	void Update () {
		if (gb <= 1) {
			red = true;
		}
		else if (gb >= 255) {
			red = false;
		} 
		if (red == false) {
			earth.GetComponent<RawImage> ().color = new Color32 (255, gb, gb, 255);
			text.GetComponent<RawImage> ().color = new Color32 (255, gb, gb, 255);
			station.GetComponent<RawImage> ().color = new Color32 (255, gb, gb, a);
			startGameButton.GetComponent<Image> ().color = new Color32 (255, gb, gb, 255);
			exitGameButton.GetComponent<Image> ().color = new Color32 (255, gb, gb, 255);
			gb -= 2;
			a += 1;
		}
		else if(red == true) {
			earth.GetComponent<RawImage> ().color = new Color32 (255, gb, gb, 255);
			text.GetComponent<RawImage> ().color = new Color32 (255, gb, gb, 255);
			station.GetComponent<RawImage> ().color = new Color32 (255, gb, gb, a);
			startGameButton.GetComponent<Image> ().color = new Color32 (255, gb, gb, 255);
			exitGameButton.GetComponent<Image> ().color = new Color32 (255, gb, gb, 255);
			gb += 2;
			a -= 1;
		}
	}

	/// <summary>
	/// Starts the game & loads in to the first level.
	/// </summary>
	private void StartGame () {
		SceneManager.LoadScene("First Level");
	}


	/// <summary>
	/// Exits the game.
	/// </summary>
	private void ExitGame () {
		Application.Quit();
	}
}
