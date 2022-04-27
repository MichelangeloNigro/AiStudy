using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour {

    public bool hasFood;
    public bool isDetected;
    public AntEyes eyes;

    private void OnTriggerEnter(Collider other) {
	    if (other.gameObject.CompareTag("Food")) {
		    hasFood = true;
	    }
    }
}
