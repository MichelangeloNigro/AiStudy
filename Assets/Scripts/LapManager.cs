using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Riutilizzabile;
using TMPro;
using UnityEngine;

public class LapManager : Singleton<LapManager> {
	public int maxLap;
	public static int maxLapstatic;
	public TMP_Text text;
	public TMP_Text giro;
	public TMP_Text winnerText;
	public TMP_Text countDown;
	public TMP_Text Position;
	private MacchininaPlayer player;
	public AudioClip lastLap;
	public AudioClip playerLose;
	public AudioClip congratulation;
	public AudioClip start;
	public AudioSource sfx;
	public AudioSource music;
	public List<MacchininaBase> allMacchinina = new List<MacchininaBase>();

	private void Start() {
		maxLap = maxLapstatic;
		player = FindObjectOfType<MacchininaPlayer>();
		player.onLap += UpdateUi;
		giro.CrossFadeAlpha(0, 0, false);
		sfx.PlayOneShot(start);
		text.text = $"Lap: {player.lap} / {maxLap}";
		StartCoroutine(CountDown());
		allMacchinina = FindObjectsOfType<MacchininaBase>().ToList();
	}

	private void Update() {
		allMacchinina.Sort((x, y) => y.touchedCheckpoints.Count.CompareTo(x.touchedCheckpoints.Count));
		for (int i = 0; i < allMacchinina.Count; i++) {
			allMacchinina[i].position = i+1;

		}
		for (int j = 1; j < allMacchinina.Count; j++) {
			if (allMacchinina[j].touchedCheckpoints.Count==allMacchinina[j-1].touchedCheckpoints.Count) {
				if (allMacchinina[j].distanceToNextCheckPoint>allMacchinina[j-1].distanceToNextCheckPoint) {
					if (allMacchinina[j].position<allMacchinina[j-1].position) {
						int temp = allMacchinina[j].position;
						allMacchinina[j].position = allMacchinina[j - 1].position;
						allMacchinina[j - 1].position = temp;
					}
				}
				if (allMacchinina[j-1].distanceToNextCheckPoint>allMacchinina[j].distanceToNextCheckPoint) {
					if (allMacchinina[j-1].position<allMacchinina[j].position) {
						int temp = allMacchinina[j-1].position;
						allMacchinina[j-1].position = allMacchinina[j].position;
						allMacchinina[j].position = temp;
					}
				}
			}
		}
		Position.text = player.position.ToString();
		
	}

	private void OnDisable() {
		player.onLap -= UpdateUi;
	}

	public void UpdateUi() {
		text.text = $"Lap: {player.lap} / {maxLap}";
		if (player.lap == maxLap - 1) {
			giro.text = "Ultimo giro!";
			sfx.PlayOneShot(lastLap);
			music.pitch = 1.2f;
		}
		StartCoroutine(TextOn());
	}

	private IEnumerator TextOn() {
		giro.CrossFadeAlpha(1, 2f, false);
		yield return new WaitForSeconds(2f);
		giro.CrossFadeAlpha(0, 2f, false);
		Debug.Log(giro.alpha);
	}

	private IEnumerator CountDown() {
		for (int i = 0; i < 4; i++) {
			countDown.CrossFadeAlpha(0, 0.5f, false);
			yield return new WaitForSeconds(0.5f);
			countDown.text = $"{3 - i}";
			countDown.CrossFadeAlpha(1, 0.5f, false);
			yield return new WaitForSeconds(0.5f);
		}
		countDown.CrossFadeAlpha(0, 0.5f, false);
	}
}