using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour {
    public RecipeSO current;
    public bool isBusy;
    public materiale carrying;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("WorkBench")) {
            var bench=other.GetComponent<WorkBench>();
            switch (carrying) {
                case materiale.wood:
                    bench.wood++;    
                    break;
                case materiale.metal:
                    bench.metal++;
                    break;
                case materiale.cloth:
                    bench.cloth++;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            bench.setMissingMaterials();
        }
        if (other.CompareTag("Metal")) {
            carrying = materiale.metal;
        }
        if (other.CompareTag("Wood")) {
            carrying = materiale.wood;
        }
        if (other.CompareTag("Cloth")) {
            carrying = materiale.cloth;
        }
    }
}


public enum materiale {
    wood,
    metal,
    cloth
}