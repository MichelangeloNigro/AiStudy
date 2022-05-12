using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class aereo : MonoBehaviour {
	public aereo target;
	public aereo[] otherPlayers;
	public int health;
	public Slider lifeSlider;

	// Start is called before the first frame update
	protected void Start() {
		lifeSlider = GetComponentInChildren<Slider>();
		lifeSlider.maxValue = health;
		lifeSlider.value = health;
		findTarget();
	}

	protected void Update() {
		if (health<=0) {
			Destroy(this.gameObject);
		}
		if (target==null) {
			findTarget();
		}
		if (otherPlayers.Length==0) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

	public void findTarget() {
		otherPlayers = FindObjectsOfType<aereo>();
		var tempList = otherPlayers.ToList();
		tempList.Remove(this);
		otherPlayers = tempList.ToArray();
		var temp = Random.Range(0, otherPlayers.Length);
		target = otherPlayers[temp];
	}
}