using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	public bool playerMoved;

	private bool canMoveUp = true;
	private bool canMoveRight = true;
	private bool canMoveLeft = true;
	private bool canMoveDown = true;

	private GameObject player;
	public Text HealthText;
	public Text GameOverText;

	private bool gameOver = false;
	private byte gb = 255;

	public int PlayerHealth = 100;

	void Start () {
		player = GameObject.Find ("Player");
		HealthText.text = PlayerHealth + "/" + "100";
	}

	void Update () {
		PlayerMovement ();
		HealthUpdate ();
		CheckIfGameOver ();
	}

	/// <summary>
	/// Moves the player.
	/// if player presses one of the arrows in the keyboard and player can move to that direction and hasn't moved yet on the same key press.
	/// </summary>
	private void PlayerMovement () {
		if (canMoveLeft == true && playerMoved == false && Input.GetKey (KeyCode.LeftArrow)) {
			player.transform.Translate (-1, 0, 0, 0);
			playerMoved = true;
		}
		if (canMoveRight == true && playerMoved == false && Input.GetKey (KeyCode.RightArrow)) {
			player.transform.Translate (1, 0, 0, 0);
			playerMoved = true;
		}
		if (canMoveUp == true && playerMoved == false && Input.GetKey (KeyCode.UpArrow)) {
			player.transform.Translate (0, 1, 0, 0);
			playerMoved = true;
		}
		if (canMoveDown == true && playerMoved == false && Input.GetKey (KeyCode.DownArrow)) {
			player.transform.Translate (0, -1, 0, 0);
			playerMoved = true;
		}
		else if (Input.GetKey (KeyCode.LeftArrow).Equals (false) && Input.GetKey (KeyCode.RightArrow).Equals (false)
		           && Input.GetKey (KeyCode.UpArrow).Equals (false) && Input.GetKey (KeyCode.DownArrow).Equals (false)) {
			playerMoved = false;
		}
	}
		
	/// <summary>
	/// Checks if game is over. If game is over starts the game over process.
	/// </summary>
	private void CheckIfGameOver () {
		if (PlayerHealth <= 0) {
			GameOverText.GetComponent<Text> ().color = new Color32 (255, 255, 255, 255);
			gameOver = true;
			if ( gameOver == true) {
				GameOverText.GetComponent<Text> ().color = new Color32 (255, gb, gb, 255);
				gb -= 2;
				playerMoved = true;
				if (gb <= 1) {
					SceneManager.LoadScene("Menu Screen");
				}
			}
		}
	}

	/// <summary>
	/// Updates the health bar on player.
	/// </summary>
	private void HealthUpdate () {
		if (PlayerHealth >= 0) {
			HealthText.text = PlayerHealth + "/" + "100";
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "TriggerBelow") {
			canMoveUp = false;
		} 
		if (other.tag == "TriggerRightSide") {
			canMoveLeft = false;
		}
		if (other.tag == "TriggerLeftSide") {
			canMoveRight = false;
		} 
		if (other.tag == "TriggerAbove") {
			canMoveDown = false;
		}
		if (other.tag == "TriggerEnemy") {
			PlayerHealth = 0;
		}
		if (other.tag == "SecondLevel") {
			SceneManager.LoadScene("Second Level");
		}
		if (other.tag == "ThirdLevel") {
			SceneManager.LoadScene("Third Level");
		} 
		if (other.tag == "FourthLevel") {
			SceneManager.LoadScene("Fourth Level");
		} 
		if (other.tag == "LastLevel") {
			SceneManager.LoadScene("Last Level");
		}
		if (other.tag == "TheEnd") {
			SceneManager.LoadScene("The End");
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "TriggerBelow") {
			canMoveUp = true;
		}
		if (other.tag == "TriggerRightSide") {
			canMoveLeft = true;
		} 
		if (other.tag == "TriggerLeftSide") {
			canMoveRight = true;
		} 
		if (other.tag == "TriggerAbove") {
			canMoveDown = true;
		}
	}
}