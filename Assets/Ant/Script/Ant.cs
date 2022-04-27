using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Ant : MonoBehaviour {

	public bool eatingFood = false;
	public bool foodDetected = false;
	public bool isDetected;
	public bool carryingFood;
	public GameObject lettuce;
	public GameObject spider;

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Food")) {
			if (gameObject.CompareTag("Player")) {
				other.gameObject.SetActive(false);
				eatingFood = true;
				carryingFood = true;
				StartCoroutine(turnoff());
			}
		}
		if (other.gameObject.CompareTag("Base")) {
			carryingFood = false;
		}
	}

	private IEnumerator turnoff() {
		yield return null;
		eatingFood = false;
	}
}