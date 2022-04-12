using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacchininaBase : MonoBehaviour {
    public float currentSpeed;
   static protected int totalCheckPoints;
    protected int touchedCheckPoints;
    public int lap;
    protected List<GameObject> touchedCheckpoints=new List<GameObject>();
    public Action onLap;
    protected ParticleSystem particleSystem;
    protected AudioSource bonk;

    protected void Start() {
        totalCheckPoints = GameObject.FindGameObjectsWithTag("CheckPoint").Length;
        onLap += CheckWin;
        particleSystem = GetComponent<ParticleSystem>();
        bonk = GetComponent<AudioSource>();

    }

    protected void Update() {
        var emission = particleSystem.emission;
        emission.rateOverTime = currentSpeed;
    }

    protected void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Muri")) {
            bonk.Play();
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

    protected void OnDisable() {
        onLap -= CheckWin;
    }

    private void CheckWin() {
        if (lap==LapManager.Instance.maxLap) {
            Time.timeScale = 0;
            Debug.Log(gameObject.name+" Won");
            LapManager.Instance.music.Stop();
        }
    }
}
