using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	public GameObject tempEnemy;
	private bool enemyMoved = false;
	public int i = 0;

	private bool canMoveUp = true;
	private bool canMoveRight = true;
	private bool canMoveLeft = true;
	private bool canMoveDown = true;

	void Start () {
		
	}

	void Update () {
		EnemyMovement ();
		Timer ();
	}

	/// <summary>
	/// Enemies the movement. Enemies move to a random direction if they can move there and if enough time has passed.
	/// </summary>
	private void EnemyMovement () {
		int r = Random.Range (1, 5);
		if (enemyMoved == false && r == 1 && canMoveLeft == true) {
			tempEnemy.transform.Translate (-1, 0, 0, 0);
			enemyMoved = true;
		}
		else if (r == 1) {
			r = Random.Range (1, 5);
		}
		if (enemyMoved == false && r == 2 && canMoveRight == true) {
			tempEnemy.transform.Translate (1, 0, 0, 0);
			enemyMoved = true;
		}
		else if (r == 2) {
			r = Random.Range (1, 5);
		}
		if (enemyMoved == false && r == 3 && canMoveDown == true) {
			tempEnemy.transform.Translate (0, -1, 0, 0);
			enemyMoved = true;
		}
		else if (r == 3) {
			r = Random.Range (1, 5);
		}
		if (enemyMoved == false && r == 4 && canMoveUp == true) {
			tempEnemy.transform.Translate (0, 1, 0, 0);
			enemyMoved = true;
		}
		else if (r == 4) {
			r = Random.Range (1, 5);
		}
		if (i == 35) {
			enemyMoved = false;
			i = 0;
		}
	}

	/// <summary>
	/// a Timer.
	/// </summary>
	private void Timer () {
		i++;
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
