using System;
using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTopDown : PlayerMovement {
	private Player player;

	public void Start() {
		base.Start();
		player = ReInput.players.GetPlayer(0);
		player.AddInputEventDelegate(Movex, UpdateLoopType.Update, InputActionEventType.Update, RewiredConsts.Action.MoveX);
		player.AddInputEventDelegate(Movey, UpdateLoopType.Update, InputActionEventType.Update, RewiredConsts.Action.MoveY);
	}

	private void OnDisable() {
		player.RemoveInputEventDelegate(Movex, UpdateLoopType.Update, InputActionEventType.Update, RewiredConsts.Action.MoveX);
		player.RemoveInputEventDelegate(Movey, UpdateLoopType.Update, InputActionEventType.Update, RewiredConsts.Action.MoveY);
	}

	private void Update() {
		x = -player.GetAxis(RewiredConsts.Action.MoveX);
		y = player.GetAxis(RewiredConsts.Action.MoveY);
	}

	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag("Enemy")) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Enemy")) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}