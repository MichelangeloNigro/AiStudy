using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proiettile : MonoBehaviour {
    public float timer;
    public int damage;
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(death());
    }

    private IEnumerator death() {
        yield return new WaitForSeconds(timer);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            other.GetComponent<aereo>().health -= damage;
            other.GetComponent<aereo>().lifeSlider.value = other.GetComponent<aereo>().health;
            Destroy(gameObject);
        }
    }
}
