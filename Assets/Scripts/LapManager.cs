using System;
using System.Collections;
using System.Collections.Generic;
using Riutilizzabile;
using TMPro;
using UnityEngine;

public class LapManager : SingletonDDOL<LapManager> {
    public int maxLap;
    public TMP_Text text;
    public TMP_Text giro;
    public TMP_Text winnerText;
    private MacchininaPlayer player;
    public AudioClip lastLap;
    public AudioClip playerLose;
    public AudioClip congratulation;
    public AudioClip start;
    public AudioSource sfx;
    public AudioSource music;

    private void Start() {
	    player = FindObjectOfType<MacchininaPlayer>();
	    player.onLap += UpdateUi;
	    giro.CrossFadeAlpha(0,0,false);
	    sfx.PlayOneShot(start);

    }

    private void OnDisable() {
	    player.onLap -= UpdateUi;
    }

    public void UpdateUi() {
	    text.text = $"Lap: {player.lap}";
	    if (player.lap==maxLap-1) {
		    giro.text = "Ultimo giro!";
		    sfx.PlayOneShot(lastLap);
		    music.pitch = 1.3f;
	    }
	    StartCoroutine(TextOn());
    }

    private IEnumerator TextOn() {
	    giro.CrossFadeAlpha(1,2f,false);
	    yield return new WaitForSeconds(2f);
	    giro.CrossFadeAlpha(0,2f,false);
	    Debug.Log(giro.alpha);

    }

}
