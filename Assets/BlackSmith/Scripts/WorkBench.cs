using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkBench : MonoBehaviour {
  public int metal;
  public int wood;
  public int cloth;
  public int missingMetal;
  public int missingWood;
  public int missingCloth;
  private Worker worker;
  private void Start() {
    worker = FindObjectOfType<Worker>();
  }

  public void setMissingMaterials() {
    missingCloth = worker.current.cloth - cloth;
    missingWood = worker.current.wood - wood;
    missingMetal = worker.current.metal - metal;
  }
}
