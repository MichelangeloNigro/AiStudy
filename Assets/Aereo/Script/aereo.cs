using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

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
		otherPlayers = FindObjectsOfType<aereo>();
		var tempList = otherPlayers.ToList();
		tempList.Remove(this);
		otherPlayers = tempList.ToArray();
		var temp = Random.Range(0, otherPlayers.Length);
		target = otherPlayers[temp];
	}
}