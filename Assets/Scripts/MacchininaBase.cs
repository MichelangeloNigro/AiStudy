using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacchininaBase : MonoBehaviour {
    public float currentSpeed;
   static protected int totalCheckPoints;
    protected int touchedCheckPoints;
    protected int lap;
    protected List<GameObject> touchedCheckpoints=new List<GameObject>();
    public Action onLap;

    protected void Start() {
        totalCheckPoints = GameObject.FindGameObjectsWithTag("CheckPoint").Length;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Muri")) {
            Debug.Log("bonk");
            currentSpeed = 0;
        }    
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("CheckPoint")&& !touchedCheckpoints.Contains(other.gameObject)) {
            touchedCheckPoints++;
            touchedCheckpoints.Add(other.gameObject);
        }
        if (other.CompareTag("Finish")&&touchedCheckPoints==totalCheckPoints) {
            touchedCheckpoints.Clear();
            touchedCheckPoints = 0;
            lap++;
            onLap();
        }
    }
}
