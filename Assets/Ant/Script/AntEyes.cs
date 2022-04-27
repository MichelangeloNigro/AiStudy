using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntEyes : MonoBehaviour {
	private Collider[] colliders;

	private void Update() {
		colliders = Physics.OverlapSphere(transform.position, 20f);
		GetComponentInParent<Ant>().foodDetected = false;
		foreach (var VARIABLE in colliders) {
			if (VARIABLE.CompareTag("Food")) {
				GetComponentInParent<Ant>().foodDetected = true;
				GetComponentInParent<Ant>().lettuce = VARIABLE.gameObject;
			}
		}
	}
	// private void OnTriggerEnter(Collider other) {
	//     if (other.CompareTag("Food")) {
	// 	    GetComponentInParent<Ant>().foodDetected = true;
	//     }
	//    }
	//
	//    private void OnTriggerExit(Collider other) {
	//     if (other.CompareTag("Food")) {
	// 	    GetComponentInParent<Ant>().foodDetected = false;
	//     }
	//    }
}