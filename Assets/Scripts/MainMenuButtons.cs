using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour {
	public RawImage fade;
	public AudioClip marioKart;
	public AudioSource source;
	public AudioMixer sfx;
	public AudioMixer music;
	private bool startGame=false;

	private void Start() {
		Time.timeScale = 1;
		fade.CrossFadeAlpha(0, 2f, true);
	}

	public void Quit() {
		Application.Quit();
	}

	public void Play() {
		StartCoroutine(startPlay());
		startGame = true;
	}

	IEnumerator startPlay() {
		if (!startGame) {
			fade.CrossFadeAlpha(1, 4, true);
			yield return new WaitForSeconds(1);
			source.PlayOneShot(marioKart);
			yield return new WaitForSeconds(3);
			SceneManager.LoadScene("Macchinina");
		}
	}

	public void setLap(TMP_InputField field) {
		LapManager.maxLapstatic = int.Parse(field.text);
	}

	public void PlayOn(Button button) {
		if (LapManager.maxLapstatic > 0) {
			button.interactable = true;
		}
	}

	public void SetSfx(float value) {
		sfx.SetFloat("Volume", value);
	}

	public void SetMusic(float value) {
		music.SetFloat("Volume", value);
	}
}