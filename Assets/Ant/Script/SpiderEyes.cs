using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEyes : MonoBehaviour {
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            GetComponentInParent<Spider>().antInSight = true;
            other.GetComponent<Ant>().isDetected = true;
            other.GetComponent<Ant>().spider = transform.root.gameObject;
            if (GetComponentInParent<Spider>().ant==null) {
                GetComponentInParent<Spider>().ant = other.gameObject;

            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            GetComponentInParent<Spider>().antInSight = false;
            other.GetComponent<Ant>().isDetected = false;
            other.GetComponent<Ant>().spider = null;
            if (GetComponentInParent<Spider>().ant!=null) {
                GetComponentInParent<Spider>().ant = null;
            }
        }
    }
}
