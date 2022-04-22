using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ghost : MonoBehaviour {
	public float vel;
	private void Start() {
		vel += Random.Range(0f, 4f);
	}
}
