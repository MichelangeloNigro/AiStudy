using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFunction : MonoBehaviour {
	public void feedRecepit(RecipeSO so) {
		FindObjectOfType<Worker>().isBusy = true;
		FindObjectOfType<Worker>().current = so;
	}
}
