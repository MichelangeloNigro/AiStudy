using System;
using System.Collections;
using System.Collections.Generic;
using Riutilizzabile;
using TMPro;
using UnityEngine;

public class LapManager : SingletonDDOL<LapManager> {
    public int maxLap;
    public TMP_Text text;
    private MacchininaPlayer player;

    private void Start() {
	    player = FindObjectOfType<MacchininaPlayer>();
	    player.onLap += UpdateUi;
	  
    }

    private void OnDisable() {
	    player.onLap -= UpdateUi;
    }

    public void UpdateUi() {
	    text.text = $"Lap: {player.lap}";
    }

    
}
