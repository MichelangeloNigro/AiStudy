using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lattuga : MonoBehaviour
{
	private void OnDisable() {
		FindObjectOfType<Ant>().eatingFood = false;
	}
}
