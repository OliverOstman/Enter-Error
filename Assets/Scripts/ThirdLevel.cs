﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ThirdLevel : MonoBehaviour {
	private GameObject box;
	private Vector3 range;
	private Vector3 playerStart;
	private List<Vector3> coordinates;
	public GameObject player;
	private GameObject enemy;
	private GameObject fourthLevel;
	private int v = 0;
	private int z = 0;
	private Button MenuButton;

	void Start () {
		MenuButton = GameObject.Find ("MenuButton").GetComponent<Button> ();
		MenuButton.onClick.AddListener (() => SceneManager.LoadScene ("Menu Screen"));
		coordinates = new List<Vector3> ();
		box =  GameObject.Find ("Box");
		enemy = GameObject.Find ("Enemy");
		fourthLevel = GameObject.Find ("Fourth Level");
		playerStart = new Vector3(Random.Range(-13, 14), Random.Range(-6, 7) , 0);
		while (true) {
			if (coordinates.Contains (playerStart)) {
				playerStart = new Vector3 (Random.Range(-13, 14), Random.Range(-6, 7) , 0);
			} else {
				player.transform.Translate (playerStart);
				coordinates.Add (playerStart);
				break;
			}
		} 
		FourthLevel ();
		Box (42);
		range = new Vector3(Random.Range(-13, 14), Random.Range(-6, 7) , 0);
		while (true) {
			if (coordinates.Contains (range)) {
				range = new Vector3 (Random.Range(-13, 14), Random.Range(-6, 7) , 0);
				v++;
			} else {
				box.transform.Translate (range);
				coordinates.Add (range);
				break;
			} if (v == 10) {
				box.SetActive (false);
				break;
			}
		} 
		Enemy (5);
		range = new Vector3(Random.Range(-13, 14), Random.Range(-6, 7) , 0);
		while (true) {
			if (coordinates.Contains (range)) {
				range = new Vector3 (Random.Range(-13, 14), Random.Range(-6, 7) , 0);
				z++;
			} else {
				enemy.transform.Translate (range);
				coordinates.Add (range);
				break;
			} if (z == 10) {
				enemy.SetActive (false);
				break;
			}
		}
	}

	/// <summary>
	/// Creates copies of box as many as given on howMany. Places the boxes on random places with Random.Range witch range is specified on the code.
	/// Makes sure that no box is placed on top of another object.
	/// </summary>
	/// <param name="howMany">How many boxes.</param>
	private void Box (int howMany) {
		int times = 0;
		while (times < howMany) {
			GameObject temp;
			Vector3 temprange;
			int i = 0;
			temp = Instantiate (box);
			temprange = new Vector3 (Random.Range (-13, 14), Random.Range (-6, 7), 0);
			while (true) {
				if (coordinates.Contains (temprange)) {
					temprange = new Vector3 (Random.Range (-13, 14), Random.Range (-6, 7), 0);
					i++;
				} else {
					temp.transform.Translate (temprange);
					coordinates.Add (temprange);
					times++;
					break;
				}
				if (i == 10) {
					temp.SetActive (false);
					times++;
					break;
				}
			}
		}
	}

	/// <summary>
	/// Creates copies of enemy as many as given on howMany. Places the enemies on random places with Random.Range witch range is specified on the code.
	/// Makes sure that no enemy is placed on top of another object.
	/// </summary>
	/// <param name="howMany">How many enemies.</param>
	private void Enemy (int howMany) {
		int times = 0;
		while (times < howMany) {
			GameObject temp;
			Vector3 temprange;
			int i = 0;
			temp = Instantiate (enemy);
			temprange = new Vector3 (Random.Range (-13, 14), Random.Range (-6, 7), 0);
			while (true) {
				if (coordinates.Contains (temprange)) {
					temprange = new Vector3 (Random.Range (-13, 14), Random.Range (-6, 7), 0);
					i++;
				}
				else {
					temp.transform.Translate (temprange);
					coordinates.Add (temprange);
					times++;
					break;
				}
				if (i == 10) {
					temp.SetActive (false);
					times++;
					break;
				}
			}
		}
	}

	/// <summary>
	/// Places the object that takes the player to the fourth level on a random place with Random.Range witch range is specified on the code.
	/// Makes sure that it is not placed on top of another object.
	/// </summary>
	private void FourthLevel () {
		Vector3 temprange = new Vector3(Random.Range(-13, 14), Random.Range(-6, 7) , 0);
		while (true) {
			if (coordinates.Contains (temprange)) {
				temprange = new Vector3 (Random.Range(-13, 14), Random.Range(-6, 7) , 0);
			} else {
				fourthLevel.transform.Translate (temprange);
				coordinates.Add (temprange);
				break;
			}
		}
	}
}
