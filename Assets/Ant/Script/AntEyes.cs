using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntEyes : MonoBehaviour
{
    public bool foodInSight;

    private void OnTriggerEnter(Collider other) {
	    if (other.CompareTag("Food")) {
		    foodInSight = true;
	    }
    }

    private void OnTriggerExit(Collider other) {
	    if (other.CompareTag("Food")) {
		    foodInSight = false;
	    }
    }
}
