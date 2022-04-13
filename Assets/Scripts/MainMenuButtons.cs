using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour {
    public RawImage fade;
    public AudioClip marioKart;
    public AudioSource source;
    private Coroutine coru;
    public AudioMixer sfx;
    public AudioMixer music;

    private void Start() {
        Time.timeScale = 1;
        fade.CrossFadeAlpha(0,2f,true);
    }

    public void Quit() {
        Application.Quit();
    }

    public void Play() {
        coru=StartCoroutine(startPlay());
    }

    IEnumerator startPlay() {
        if (coru==null) {
            fade.CrossFadeAlpha(1,4,true);
            yield return new WaitForSeconds(1);
            source.PlayOneShot(marioKart);
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene("Macchinina");
        }
    }

    public void SetSfx(float value) {
        sfx.SetFloat("Volume", value);
    }
    public void SetMusic(float value) {
        music.SetFloat("Volume", value);
    }
}
